using FastKeySimulator.Structure.DwFlags.Mouse;
using FastKeySimulator.Structure.Input;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using static FastKeySimulator.Structure.Input.Input;

namespace FastKeySimulator.Keystrokes.Mouse.Domain.Motion
{
    
    internal class CursorMotion
    {

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint SendInput(uint nInputs, [In] INPUT[] pInputs, int cbSize);

        INPUT[] mouse = new INPUT[2];
        public CursorMotion()
        {
            mouse[0].type = 0;
            mouse[1].type = 0;
        }
        public async Task ShowMouse(int x, int y, int steps, int timeDelay)
        {
            if (timeDelay < 0)
            {
                timeDelay = 0;
            }
            float stepXTemp = (float)x / steps;
            float stepYTemp = (float)y / steps;
            float stepX = 0;
            float stepY = 0;
            mouse[0].U.mi.dwFlags = DwFlagsMouse.MOUSEEVENTF_MOVE;
            for (int i = 0; i < steps; i++)
            {
                stepX += stepXTemp;
                stepY += stepYTemp;
                int XTemp = (int)stepX;
                int YTemp = (int)stepY;
                stepX -= XTemp;
                stepY -= YTemp;
                mouse[0].U.mi.dx = XTemp;
                mouse[0].U.mi.dy = YTemp;
                SendInput(1, mouse, Marshal.SizeOf(typeof(Input.INPUT)));
                await Task.Delay(timeDelay);

            }


        }


    }
}
