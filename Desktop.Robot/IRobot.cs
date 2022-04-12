using System.Drawing;
using System.Drawing.Imaging;
using Desktop.Robot.Clicks;

namespace Desktop.Robot
{
    public interface IRobot
    {
        uint AutoDelay { get; set; }
        Image CreateScreenCapture(Rectangle screenRect, PixelFormat pixelFormat);
        Color GetPixelColor(uint x, uint y, PixelFormat pixelFormat);
        void KeyPress(Key key);
        void KeyPress(char key);
        void KeyDown(Key key);
        void KeyDown(char key);
        void KeyUp(Key key);
        void KeyUp(char key);
        void Click(IClick click);
        void MouseDown(IClick click);
        void MouseUp(IClick click);
        void Delay(uint ms);
        void MouseMove(uint x, uint y);
        void MouseMove(Point p);
        Point GetMousePosition();
    }
}
