﻿using Desktop.Robot.Clicks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;

namespace Desktop.Robot
{
    public abstract class AbstractRobot : IRobot
    {
        public uint AutoDelay { get; set; }

        public abstract Point GetMousePosition();

        public abstract void KeyPress(Key key);

        public abstract void KeyPress(char key);

        public abstract void KeyDown(Key key);

        public abstract void KeyDown(char key);

        public abstract void KeyUp(Key key);

        public abstract void KeyUp(char key);

        public abstract void MouseMove(uint x, uint y);

        public void MouseMove(Point p) 
        {
            MouseMove((uint)p.X, (uint)p.Y);
        }

        public virtual Image CreateScreenCapture(Rectangle screenRect, PixelFormat pixelFormat)
        {
            var bmp = new Bitmap(screenRect.Width, screenRect.Height, pixelFormat);
            using Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(screenRect.Left, screenRect.Top, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);

            return bmp;
        }

        public virtual Color GetPixelColor(uint x, uint y, PixelFormat pixelFormat)
        {
            var rect = new Rectangle(new Point((int)x, (int)y), new Size(1, 1));
            return (CreateScreenCapture(rect, pixelFormat) as Bitmap).GetPixel(0, 0);
        }

        public void Click(IClick click)
        {
            ApplyAutoDelay();
            click.ExecuteClick(new MouseContext(GetMousePosition()));
        }

        public void MouseDown(IClick click)
        {
            ApplyAutoDelay();
            click.ExecuteMouseDown(new MouseContext(GetMousePosition()));
        }

        public void MouseUp(IClick click)
        {
            ApplyAutoDelay();
            click.ExecuteMouseUp(new MouseContext(GetMousePosition()));
        }

        public void Delay(uint ms)
        {
            Thread.Sleep((int)ms);
        }

        protected void ApplyAutoDelay()
        {
            if (AutoDelay > 0)
            {
                Thread.Sleep((int)AutoDelay);
            }
        }

    }
}
