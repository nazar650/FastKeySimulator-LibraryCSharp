using FastKeySimulator.Structure.DwFlags.Mouse;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Windows.Devices.Lights;
using static FastKeySimulator.Structure.Input.Input;

namespace FastKeySimulator.Keystrokes.Mouse.Domain.Click
{
    
    internal class MouseClick
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern uint SendInput(uint nInputs, [In] INPUT[] pInputs, int cbSize);

        INPUT[] mouse = new INPUT[2];
        public MouseClick()
        {
            mouse[0].type = 0;
            mouse[1].type = 0;
        }
        public void Click(string nameKey,bool ToHold)
        {

            if (nameKey.ToLower() == "left")
            {
                mouse[0].U.mi.dwFlags = DwFlagsMouse.MOUSEEVENTF_LEFTDOWN;
                if (!ToHold)
                {
                mouse[1].U.mi.dwFlags = DwFlagsMouse.MOUSEEVENTF_LEFTUP;

                }
            }
            if (nameKey.ToLower() == "right")
            {
                mouse[0].U.mi.dwFlags = DwFlagsMouse.MOUSEEVENTF_RIGHTDOWN;
                if (!ToHold)
                {
                    mouse[1].U.mi.dwFlags = DwFlagsMouse.MOUSEEVENTF_RIGHTUP;
                }
            }
            if (nameKey.ToLower() == "middle")
            {
                mouse[0].U.mi.dwFlags = DwFlagsMouse.MOUSEEVENTF_MIDDLEDOWN;
                if (!ToHold)
                {

                mouse[1].U.mi.dwFlags = DwFlagsMouse.MOUSEEVENTF_MIDDLEUP;
                }
            }
            else
            {
                return;
            }

            SendInput((uint)mouse.Length, mouse, Marshal.SizeOf(typeof(INPUT)));
        }
        public void ClickRelease()
        {
            mouse[1].U.mi.dwFlags = DwFlagsMouse.MOUSEEVENTF_MIDDLEUP;
            SendInput((uint)mouse.Length, mouse, Marshal.SizeOf(typeof(INPUT)));
            mouse[1].U.mi.dwFlags = DwFlagsMouse.MOUSEEVENTF_RIGHTUP;
            SendInput((uint)mouse.Length, mouse, Marshal.SizeOf(typeof(INPUT)));
            mouse[1].U.mi.dwFlags = DwFlagsMouse.MOUSEEVENTF_LEFTUP;
            SendInput((uint)mouse.Length, mouse, Marshal.SizeOf(typeof(INPUT)));

        }
    }

}