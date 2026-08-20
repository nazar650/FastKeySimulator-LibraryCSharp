using System.Runtime.InteropServices;


namespace FastKeySimulator.Keystrokes.Mouse.Domain.SetCursorPos
{

    internal class MouseSetCursorPos
    {
        [DllImport("user32.dll")]
        static extern uint SetCursorPos(int x, int y);
        [DllImport("user32.dll")]
        private static extern int GetSystemMetrics(int nIndex);

        public void SetCursorPosition(object x, object y)
        {
            if (x is int xValue && y is int yValue)
            {
                SetCursorPos(xValue, yValue);
            }
            else if (x is float xFloat && y is float yFloat)
            {
                int width = GetSystemMetrics(0);
                int height = GetSystemMetrics(1);
                SetCursorPos((int)(width * xFloat), (int)(height * yFloat));

            }
        }
    }
}
