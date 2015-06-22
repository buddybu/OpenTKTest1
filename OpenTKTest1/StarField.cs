using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenTKTest1
{
    class StarField
    {
        private bool active;
        private bool go;
        private int numStars;
        private byte[] starArray;

        public StarField(int numStars, byte[] starData)
        {
            throw new System.NotImplementedException();
        }

        ~StarField()
        {
            throw new System.NotImplementedException();
        }

        public bool Active
        {
            get
            {
                return active;
            }

            set
            {
                active = value;
            }
        }

        public Boolean Go
        {
            get
            {
                return go;
            }

            set
            {
                go = value;
            }
        }

        public int NumStars
        {
            get
            {
                return numStars;
            }

        }

        public byte[] StarArray
        {
            get
            {
                return starArray;
            }
        }

        public void Draw()
        {
            throw new System.NotImplementedException();
        }

        public void StartScroll()
        {
            throw new System.NotImplementedException();
        }

        public void StopScroll()
        {
            throw new System.NotImplementedException();
        }
    }
}
