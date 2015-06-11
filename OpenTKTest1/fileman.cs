using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenTKTest1
{
    class database
    {
        // database header
        private byte[] header;
        private int mode;
        private int nfiles;
        private filestrc[] entries;
        
        // db structure fields
        private byte[] basename;
        private BinaryReader dbFile;

        public struct filestrc 
        {
            public String      name;       // Name of file.
            public UInt32      size;       // It's size.
            public Int16       flags;      // Buffering flags.
            public Byte[]      data;       // File pointer to access it's data.
        }

        public database(string filename)
        {
            try
            {
                using (dbFile = new BinaryReader(File.Open(filename, FileMode.Open)))
                {

                    basename = Encoding.ASCII.GetBytes(filename);

                    // read all files into an entry array
                    header = dbFile.ReadBytes(30);

                    mode = dbFile.ReadByte();
                    mode += (dbFile.ReadByte() << 8);

                    nfiles = dbFile.ReadByte();
                    nfiles += (dbFile.ReadByte() << 8);

                    entries = new filestrc[nfiles];

                    for (int i = 0; i < nfiles; i++)
                    {
                        long fpos;
                        long curpos;

                        // read the name and convert it to a string
                        entries[i].name = System.Text.Encoding.UTF8.GetString(dbFile.ReadBytes(14));

                        // read the file size
                        entries[i].size = dbFile.ReadByte();
                        entries[i].size += (UInt32)dbFile.ReadByte() << 8;
                        entries[i].size += (UInt32)dbFile.ReadByte() << 16;
                        entries[i].size += (UInt32)dbFile.ReadByte() << 24;

                        // read the file flags
                        entries[i].flags = dbFile.ReadByte();
                        entries[i].flags += (Int16)(dbFile.ReadByte() << 8);

                        // read the position in the database of the file data
                        fpos = dbFile.ReadByte();
                        fpos += dbFile.ReadByte() << 8;
                        fpos += dbFile.ReadByte() << 16;
                        fpos += dbFile.ReadByte() << 24;

                        // read the data into the entries array
                        // get current position
                        // seek to the data position
                        // read the data
                        // restore position
                        curpos = dbFile.BaseStream.Seek(0, SeekOrigin.Current);
                        dbFile.BaseStream.Seek(fpos, SeekOrigin.Begin);
                        entries[i].data = dbFile.ReadBytes((int)entries[i].size);
                        dbFile.BaseStream.Seek(curpos, SeekOrigin.Begin);

                        Console.WriteLine("[{0}]{1}: Read {2} bytes from pos {3}",
                            i.ToString(), entries[i].name, entries[i].size.ToString(), fpos.ToString());
                    }


                }
            }
            catch(Exception Ex)
            {
                Console.WriteLine("IOException source: {0}", Ex.Message);
            }
        }

        ~database()
        {
            // nothing to cleanup
        }

        public filestrc findentry(string file)
        {
            int    i;
            filestrc result ;

            result.name = null;
            result.data = null;
            result.flags = 0;
            result.size = 0;

            for (i = 0; i < nfiles; i++)
            {
                if (file.CompareTo(entries[i].name) == 0)
                {
                    result = entries[i];
                    break;
                }
            }
            return result;
        }

    }

    class fileman
    {

        public delegate void errorHandler(string text, int code, params object[] args);
        private errorHandler error;
        public errorHandler ErrorFunc
        {
            get
            {
                return error;
            }
            set 
            {
                if (value != null)
                    error = value;
            }
        }

        private database db;

        // initfilemanager
        public fileman(string filename, errorHandler err = null)
        {
            if (err != null)
                error = err;
            else
                error = errf;

            db = new database(filename);
            
        }

        // shutfilemanager
        ~fileman()
        {

        }

        // load file
        public void LoadFile(String file, out Byte[] buffer)
        {
            database.filestrc fh;
            fh = db.findentry(file);

            if (fh.size == 0 && fh.flags == 0)
            {
                // did not find the file in the file list, 
                // it must not be in the database... error!
                error("Not in File!", 2 );
                buffer = null;
            }
            else
                buffer = fh.data;
        }

        // free allocated buffer?
        public void UnloadFile(Byte[] buffer)
        {
            // nothing to do -- will be removed when app exits...
        }

        static void errf(string text, int code, params object[] args)
        {
            Console.WriteLine("ERROR: {0}: {1}");
            Environment.Exit(code);
        }   

    }
}
