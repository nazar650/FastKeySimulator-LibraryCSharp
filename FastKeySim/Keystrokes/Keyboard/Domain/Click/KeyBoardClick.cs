using FastKeySimulator.Structure.DwFlags.KeyBoard;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using static FastKeySimulator.Structure.Input.Input;
namespace FastKeySimulator.Keystrokes.Keyboard.Domain.Click
{
    
    internal class KeyBoardClick
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern uint SendInput(uint nInputs, [In] INPUT[] pInputs, int cbSize);
        public async Task Click(ushort[] name, int timeDelay)
        {

            int count = name.Length;
            INPUT[] keyboardDown = new INPUT[count];
            INPUT[] keyboardUp = new INPUT[count];
            for (int i = 0; i < count; i++)
            {
                keyboardDown[i].type = 1;
                keyboardDown[i].U.ki.wScan = name[i];
                keyboardDown[i].U.ki.dwFlags = DwFlagsKeyBoard.KEYEVENTF_SCANCODE;
            }
            if (timeDelay >= 5.5)
            {


                for (int i = 0; i < timeDelay; i++)
                {
                    if (i % 5.5 == 0)
                    {
                        SendInput((uint)keyboardDown.Length, keyboardDown, Marshal.SizeOf(typeof(INPUT)));
                    }
                    await Task.Delay(1);
                }
            }
            else
            {
                SendInput((uint)keyboardDown.Length, keyboardDown, Marshal.SizeOf(typeof(INPUT)));
            }
            for (int i = 0; i < count; i++)
            {
                keyboardUp[i].type = 1;
                keyboardUp[i].U.ki.wScan = name[i];
                keyboardUp[i].U.ki.dwFlags = DwFlagsKeyBoard.KEYEVENTF_SCANCODE | DwFlagsKeyBoard.KEYEVENTF_KEYUP;
            }
            SendInput((uint)keyboardUp.Length, keyboardUp, Marshal.SizeOf(typeof(INPUT)));
        }


    }
}
