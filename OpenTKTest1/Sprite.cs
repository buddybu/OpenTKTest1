﻿using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace OpenTKTest1
{
    class Sprite
    {
        struct Palette
        {
            public int r;
            public int g;
            public int b;

            public Palette(int pR, int pG, int pB)
            {
                r = pR;
                g = pG;
                b = pB;
            }
        }

        static Palette[] myPalette = new Palette[] { 
            new Palette(0x00,0x00,0x00), new Palette(0x00,0x00,0x2A), new Palette(0x00,0x2A,0x00), new Palette(0x00,0x2A,0x2A),
            new Palette(0x2A,0x00,0x00), new Palette(0x2A,0x00,0x2A), new Palette(0x2A,0x15,0x00), new Palette(0x2A,0x2A,0x2A),
            new Palette(0x15,0x15,0x15), new Palette(0x15,0x15,0x3F), new Palette(0x15,0x3F,0x15), new Palette(0x15,0x3F,0x3F),
            new Palette(0x3F,0x15,0x15), new Palette(0x3F,0x15,0x3F), new Palette(0x3F,0x3F,0x15), new Palette(0x3F,0x3F,0x3F),
            new Palette(0x3B,0x3B,0x3B), new Palette(0x37,0x37,0x37), new Palette(0x34,0x34,0x34), new Palette(0x30,0x30,0x30),
            new Palette(0x2D,0x2D,0x2D), new Palette(0x2A,0x2A,0x2A), new Palette(0x26,0x26,0x26), new Palette(0x23,0x23,0x23),
            new Palette(0x1F,0x1F,0x1F), new Palette(0x1C,0x1C,0x1C), new Palette(0x19,0x19,0x19), new Palette(0x15,0x15,0x15),
            new Palette(0x12,0x12,0x12), new Palette(0x0E,0x0E,0x0E), new Palette(0x0B,0x0B,0x0B), new Palette(0x08,0x08,0x08),
            new Palette(0x3F,0x00,0x00), new Palette(0x3B,0x00,0x00), new Palette(0x38,0x00,0x00), new Palette(0x35,0x00,0x00),
            new Palette(0x32,0x00,0x00), new Palette(0x2F,0x00,0x00), new Palette(0x2C,0x00,0x00), new Palette(0x29,0x00,0x00),
            new Palette(0x26,0x00,0x00), new Palette(0x22,0x00,0x00), new Palette(0x1F,0x00,0x00), new Palette(0x1C,0x00,0x00),
            new Palette(0x19,0x00,0x00), new Palette(0x16,0x00,0x00), new Palette(0x13,0x00,0x00), new Palette(0x10,0x00,0x00),
            new Palette(0x3F,0x36,0x36), new Palette(0x3F,0x2E,0x2E), new Palette(0x3F,0x27,0x27), new Palette(0x3F,0x1F,0x1F),
            new Palette(0x3F,0x17,0x17), new Palette(0x3F,0x10,0x10), new Palette(0x3F,0x08,0x08), new Palette(0x3F,0x00,0x00),
            new Palette(0x3F,0x2A,0x17), new Palette(0x3F,0x26,0x10), new Palette(0x3F,0x22,0x08), new Palette(0x3F,0x1E,0x00),
            new Palette(0x39,0x1B,0x00), new Palette(0x33,0x18,0x00), new Palette(0x2D,0x15,0x00), new Palette(0x27,0x13,0x00),
            new Palette(0x3F,0x3F,0x36), new Palette(0x3F,0x3F,0x2E), new Palette(0x3F,0x3F,0x27), new Palette(0x3F,0x3F,0x1F),
            new Palette(0x3F,0x3E,0x17), new Palette(0x3F,0x3D,0x10), new Palette(0x3F,0x3D,0x08), new Palette(0x3F,0x3D,0x00),
            new Palette(0x39,0x36,0x00), new Palette(0x33,0x31,0x00), new Palette(0x2D,0x2B,0x00), new Palette(0x27,0x27,0x00),
            new Palette(0x21,0x21,0x00), new Palette(0x1C,0x1B,0x00), new Palette(0x16,0x15,0x00), new Palette(0x10,0x10,0x00),
            new Palette(0x34,0x3F,0x17), new Palette(0x31,0x3F,0x10), new Palette(0x2D,0x3F,0x08), new Palette(0x28,0x3F,0x00),
            new Palette(0x24,0x39,0x00), new Palette(0x20,0x33,0x00), new Palette(0x1D,0x2D,0x00), new Palette(0x18,0x27,0x00),
            new Palette(0x36,0x3F,0x36), new Palette(0x2F,0x3F,0x2E), new Palette(0x27,0x3F,0x27), new Palette(0x20,0x3F,0x1F),
            new Palette(0x18,0x3F,0x17), new Palette(0x10,0x3F,0x10), new Palette(0x08,0x3F,0x08), new Palette(0x00,0x3F,0x00),
            new Palette(0x00,0x3F,0x00), new Palette(0x00,0x3B,0x00), new Palette(0x00,0x38,0x00), new Palette(0x00,0x35,0x00),
            new Palette(0x01,0x32,0x00), new Palette(0x01,0x2F,0x00), new Palette(0x01,0x2C,0x00), new Palette(0x01,0x29,0x00),
            new Palette(0x01,0x26,0x00), new Palette(0x01,0x22,0x00), new Palette(0x01,0x1F,0x00), new Palette(0x01,0x1C,0x00),
            new Palette(0x01,0x19,0x00), new Palette(0x01,0x16,0x00), new Palette(0x01,0x13,0x00), new Palette(0x01,0x10,0x00),
            new Palette(0x36,0x3F,0x3F), new Palette(0x2E,0x3F,0x3F), new Palette(0x27,0x3F,0x3F), new Palette(0x1F,0x3F,0x3E),
            new Palette(0x17,0x3F,0x3F), new Palette(0x10,0x3F,0x3F), new Palette(0x08,0x3F,0x3F), new Palette(0x00,0x3F,0x3F),
            new Palette(0x00,0x39,0x39), new Palette(0x00,0x33,0x33), new Palette(0x00,0x2D,0x2D), new Palette(0x00,0x27,0x27),
            new Palette(0x00,0x21,0x21), new Palette(0x00,0x1C,0x1C), new Palette(0x00,0x16,0x16), new Palette(0x00,0x10,0x10),
            new Palette(0x17,0x2F,0x3F), new Palette(0x10,0x2C,0x3F), new Palette(0x08,0x2A,0x3F), new Palette(0x00,0x27,0x3F),
            new Palette(0x00,0x23,0x39), new Palette(0x00,0x1F,0x33), new Palette(0x00,0x1B,0x2D), new Palette(0x00,0x17,0x27),
            new Palette(0x36,0x36,0x3F), new Palette(0x2E,0x2F,0x3F), new Palette(0x27,0x27,0x3F), new Palette(0x1F,0x20,0x3F),
            new Palette(0x17,0x18,0x3F), new Palette(0x10,0x10,0x3F), new Palette(0x08,0x09,0x3F), new Palette(0x00,0x01,0x3F),
            new Palette(0x00,0x00,0x3F), new Palette(0x00,0x00,0x3B), new Palette(0x00,0x00,0x38), new Palette(0x00,0x00,0x35),
            new Palette(0x00,0x00,0x32), new Palette(0x00,0x00,0x2F), new Palette(0x00,0x00,0x2C), new Palette(0x00,0x00,0x29),
            new Palette(0x00,0x00,0x26), new Palette(0x00,0x00,0x22), new Palette(0x00,0x00,0x1F), new Palette(0x00,0x00,0x1C),
            new Palette(0x00,0x00,0x19), new Palette(0x00,0x00,0x16), new Palette(0x00,0x00,0x13), new Palette(0x00,0x00,0x10),
            new Palette(0x3C,0x36,0x3F), new Palette(0x39,0x2E,0x3F), new Palette(0x36,0x27,0x3F), new Palette(0x34,0x1F,0x3F),
            new Palette(0x32,0x17,0x3F), new Palette(0x2F,0x10,0x3F), new Palette(0x2D,0x08,0x3F), new Palette(0x2A,0x00,0x3F), 
            new Palette(0x26,0x00,0x39), new Palette(0x20,0x00,0x33), new Palette(0x1D,0x00,0x2D), new Palette(0x18,0x00,0x27),
            new Palette(0x14,0x00,0x21), new Palette(0x11,0x00,0x1C), new Palette(0x0D,0x00,0x16), new Palette(0x0A,0x00,0x10), 
            new Palette(0x3F,0x36,0x3F), new Palette(0x3F,0x2E,0x3F), new Palette(0x3F,0x27,0x3F), new Palette(0x3F,0x1F,0x3F),
            new Palette(0x3F,0x17,0x3F), new Palette(0x3F,0x10,0x3F), new Palette(0x3F,0x08,0x3F), new Palette(0x3F,0x00,0x3F),
            new Palette(0x38,0x00,0x39), new Palette(0x32,0x00,0x33), new Palette(0x2D,0x00,0x2D), new Palette(0x27,0x00,0x27),
            new Palette(0x21,0x00,0x21), new Palette(0x1B,0x00,0x1C), new Palette(0x16,0x00,0x16), new Palette(0x10,0x00,0x10),
            new Palette(0x3F,0x3A,0x37), new Palette(0x3F,0x38,0x34), new Palette(0x3F,0x36,0x31), new Palette(0x3F,0x35,0x2F),
            new Palette(0x3F,0x33,0x2C), new Palette(0x3F,0x31,0x29), new Palette(0x3F,0x2F,0x27), new Palette(0x3F,0x2E,0x24),
            new Palette(0x3F,0x2C,0x20), new Palette(0x3F,0x29,0x1C), new Palette(0x3F,0x27,0x18), new Palette(0x3C,0x25,0x17),
            new Palette(0x3A,0x23,0x16), new Palette(0x37,0x22,0x15), new Palette(0x34,0x20,0x14), new Palette(0x32,0x1F,0x13), 
            new Palette(0x2F,0x1E,0x12), new Palette(0x2D,0x1C,0x11), new Palette(0x2A,0x1A,0x10), new Palette(0x28,0x19,0x0F),
            new Palette(0x27,0x18,0x0E), new Palette(0x24,0x17,0x0D), new Palette(0x22,0x16,0x0C), new Palette(0x20,0x14,0x0B),
            new Palette(0x1D,0x13,0x0A), new Palette(0x1B,0x12,0x09), new Palette(0x17,0x10,0x08), new Palette(0x15,0x0F,0x07),
            new Palette(0x12,0x0E,0x06), new Palette(0x10,0x0C,0x06), new Palette(0x0E,0x0B,0x05), new Palette(0x0A,0x08,0x03),
            new Palette(0x00,0x00,0x00), new Palette(0x00,0x00,0x00), new Palette(0x00,0x00,0x00), new Palette(0x00,0x00,0x00),
            new Palette(0x00,0x00,0x00), new Palette(0x00,0x00,0x00), new Palette(0x00,0x00,0x00), new Palette(0x00,0x00,0x00), 
            new Palette(0x31,0x0A,0x0A), new Palette(0x31,0x13,0x0A), new Palette(0x31,0x1D,0x0A), new Palette(0x31,0x27,0x0A),
            new Palette(0x31,0x31,0x0A), new Palette(0x27,0x31,0x0A), new Palette(0x1D,0x31,0x0A), new Palette(0x13,0x31,0x0A),
            new Palette(0x0A,0x31,0x0C), new Palette(0x0A,0x31,0x17), new Palette(0x0A,0x31,0x22), new Palette(0x0A,0x31,0x2D),
            new Palette(0x0A,0x2A,0x31), new Palette(0x0A,0x1F,0x31), new Palette(0x0A,0x14,0x31), new Palette(0x0B,0x0A,0x31), 
            new Palette(0x16,0x0A,0x31), new Palette(0x21,0x0A,0x31), new Palette(0x2C,0x0A,0x31), new Palette(0x31,0x0A,0x2B),
            new Palette(0x31,0x0A,0x20), new Palette(0x31,0x0A,0x15), new Palette(0x31,0x0A,0x0A), new Palette(0x3F,0x3F,0x3F)
            };


        private short xSize;
        private short ySize;
        private short numFrames;
        private byte[] data;
        public byte[] spriteBuffer;
        private fileman fileMgr;

        // low sprite 
        int nadd;
        int maxn;
        int xSizeAlign;
        int picSize;
        int seqSize;
        int fullSize;
        Bitmap[] bmp;
        Bitmap[] bmp_silhouette;

        public Sprite(fileman fm)
        {
            fileMgr = fm;
        }


        // load a named sprite or library from the database
        public void LoadSprite(String spriteName, UInt16 flags)
        {
            int size;
            int align;

            fileMgr.LoadFile(spriteName, out data);
            xSize = (short)(data[0] + (data[1] << 8));
            ySize = (short)(data[2] + (data[3] << 8));
            numFrames = (short)(data[4] + (data[5] << 8));
            spriteBuffer = new byte[data.Length-6];

            for (int i = 0; i < spriteBuffer.Length; i++)
                spriteBuffer[i] = data[i+6];
//            data.CopyTo(spriteBuffer,6,);

            align = 4 - (flags & 7);

            size = (xSize / 4) * ySize;
            xSizeAlign = xSize;
            picSize = size;
            maxn = numFrames * 2;

            if ((flags & 0x08) != 0)
                nadd = 1;
            else
                nadd = 2;

            seqSize = size * maxn * (align / 2);
            fullSize = size * maxn * ((align / 2) + 1);

            bmp = new Bitmap[numFrames];
            bmp_silhouette = new Bitmap[numFrames];

            int dataPos = 0;
            Color flash = Color.FromArgb(myPalette[230].r, myPalette[230].g, myPalette[230].b);

            for (int n = 0; n < numFrames; n++)
            {
                bmp[n] = new Bitmap(xSize, ySize, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                bmp_silhouette[n] = new Bitmap(xSize, ySize, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                //                ColorPalette pal = bmp[n].Palette;

//                for (int i = 0; i < pal.Entries.Length; i++)
//                {
//                    pal.Entries[i] = Color.FromArgb(255, standardpal[i].r, standardpal[i].g, standardpal[i].b);
//                }



                for (int y=0; y < ySize; y++)
                {
                    for (int x=0; x < xSize; x+=1)
                    {
                        byte value = spriteBuffer[x + dataPos];
                        Color col = Color.FromArgb(myPalette[value].r, myPalette[value].g, myPalette[value].b);
                        bmp[n].SetPixel(x, y, col);
                        if (value != 0)
                            bmp_silhouette[n].SetPixel(x, y, flash);
                        else
                            bmp_silhouette[n].SetPixel(x, y, Color.Black);
                    }

                    dataPos += xSize;
                }
            }
        }


        // load a sprite frame from a sprite
        public void LoadSpriteFrame(int frame)
        {

        }

        // display sprite on page
        public void PutSprite(Screen scr, int xPos, int yPos, int frame)
        {

        }

        public void PutSpriteDirect(Screen scr, int xPos, int yPos, int frame)
        {

        }

        public void PutSpriteOutline(Screen scr, int xPos, int yPos, int frame)
        {

        }

        public void RemoveSprite(Screen scr, int xPos, int yPos)
        {

        }
    }

    class SpriteLibrary
    {
        private Sprite sprite;

        public SpriteLibrary(Sprite spr)
        {
            sprite = spr;
        }

    }

}
