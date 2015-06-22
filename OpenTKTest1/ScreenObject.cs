using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenTKTest1
{
    class ScreenObject
    {
        int objXPos;        // horizontal position on screen(x)
        int objYPos;        // vertical position on screen(y)

        int scrXPos;        // horizontal position on displayed screen(xa)
        int scrYPos;        // vertial position on displayed screen(ya)

        int hidXPos;        // horizonal position on hidden screen(xb)
        int hidYPos;        // horizonal position on hidden screen(yb)

        int objXSize;       // horizontal size of object (xs)
        int objYSize;       // vertical size of object (ys)

        int objState;       // State flags
        bool objActive;     //	true if active, false if not

        int sprFrame;       // sprite frame number
        int sprFrameInc;    // sprite frame increment
        Sprite objSprite;    // sprite object

        public int ObjXPos
        {
            get
            {
                return objXPos;
            }

            set
            {
                objXPos = value;
            }
        }

        public int ObjYPos
        {
            get
            {
                return objYPos;
            }

            set
            {
                objYPos = value;
            }
        }

        public int ScrXPos
        {
            get
            {
                return scrXPos;
            }

            set
            {
                scrXPos = value;
            }
        }

        public int ScrYPos
        {
            get
            {
                return scrYPos;
            }

            set
            {
                scrYPos = value;
            }
        }

        public int HidXPos
        {
            get
            {
                return hidXPos;
            }

            set
            {
                hidXPos = value;
            }
        }

        public int HidYPos
        {
            get
            {
                return hidYPos;
            }

            set
            {
                hidYPos = value;
            }
        }

        public int ObjXSize
        {
            get
            {
                return objXSize;
            }

            set
            {
                objXSize = value;
            }
        }

        public int ObjYSize
        {
            get
            {
                return objYSize;
            }

            set
            {
                objYSize = value;
            }
        }

        public int ObjState
        {
            get
            {
                return objState;
            }

            set
            {
                objState = value;
            }
        }

        public bool ObjActive
        {
            get
            {
                return objActive;
            }

            set
            {
                objActive = value;
            }
        }

        public int SprFrame
        {
            get
            {
                return sprFrame;
            }

            set
            {
                sprFrame = value;
            }
        }

        public int SprFrameInc
        {
            get
            {
                return sprFrameInc;
            }

            set
            {
                sprFrameInc = value;
            }
        }

        internal Sprite ObjSprite
        {
            get
            {
                return objSprite;
            }

            set
            {
                objSprite = value;
            }
        }

        /*
            Constructor ScreenObject(Sprite spr, int xPos, int yPos, int flags)
            public void Move(int x, int y)
            public void MoveDelta(int deltaX, int deltaY)
            public void Flash();
            public void ChangeSprite(Sprite newSprite)
            public void AbandonObject()
            public void KillObject()
            public void CrashTest(Object objCrash)
            public bool OutOfWindow()
        */
    }
}
