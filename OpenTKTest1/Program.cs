using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using OpenTK.Audio;

namespace OpenTKTest1
{
    class MyApplication : GameWindow
    {

        
        [STAThread]
        public static void Main()
        {
//            using (var game = new GameWindow())
            using (MyApplication app = new MyApplication())
            {
                app.Run(60.0);
            }
        }

        #region OnLoad override
        protected override void OnLoad(EventArgs e)
        {
            VSync = VSyncMode.On;
            WindowBorder = WindowBorder.Fixed;
            Width = 640;
            Height = 480;
        }
        #endregion

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            // add game logic, input handling
            if (Keyboard[Key.Escape])
            {
                Exit();
            }
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
   
            
            // render graphics
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-1.0, 1.0, -1.0, 1.0, 0.0, 4.0);

            GL.Begin(PrimitiveType.Triangles);

            GL.Color3(Color.MidnightBlue);
            GL.Vertex2(-1.0f, 1.0f);
            GL.Color3(Color.SpringGreen);
            GL.Vertex2(0.0f, -1.0f);
            GL.Color3(Color.Ivory);
            GL.Vertex2(1.0f, 1.0f);

            GL.End();

            SwapBuffers();
        }
    }
}
