using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Windows.Forms;

namespace FastKeySimulator.Keystrokes.Mouse.Domain.SetCursorPos
{
    
    internal class MouseSetCursorPos
    {
        [DllImport("user32.dll")]
        static extern uint SetCursorPos(int x, int y);
        public void SetCursorPosition(object x, object y)
        {
            if (x is int xValue && y is int yValue)
            {
                SetCursorPos(xValue, yValue);
            }
            else if (x is float xFloat && y is float yFloat)
            {
                Screen? screen = Screen.PrimaryScreen;

                if (screen != null)
                {
                    int width = screen.Bounds.Width;
                    int height = screen.Bounds.Height;
                    SetCursorPos((int)(width * xFloat), (int)(height * yFloat));
                }
            }
        }
    }
}
