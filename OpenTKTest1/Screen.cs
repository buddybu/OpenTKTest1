using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Text;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace OpenTKTest1
{

    class Screen
    {

        private int windowX0;
        private int windowY0;
        private int windowX1;
        private int windowY1;

        const int PAGES = 2;
        // Definiton of graphics window.
        const int XMIN = 0;
        const int XMAX = 319;
        const int YMIN = 0;
        const int YMAX = 219;

        private int         page;
        private Bitmap[]    pages;
        private Bitmap[]    fullPages;

        public Screen()
        {
            windowX0 = XMIN; 
            windowY0 = YMIN;
            windowX1 = XMAX; 
            windowY1 = YMAX;
            OpenTK.Graph
            pages = new Bitmap[PAGES];
            fullPages = new Bitmap[PAGES];
        }
    
    }
}
