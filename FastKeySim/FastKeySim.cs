using FastKeySimulator.Keystrokes.Keyboard.Domain.Click;
using FastKeySimulator.Keystrokes.Mouse.Domain.Click;
using FastKeySimulator.Keystrokes.Mouse.Domain.ScrollWheel;
using FastKeySimulator.Keystrokes.Mouse.Domain.SetCursorPos;
using FastKeySimulator.Keystrokes.Mouse.Domain.Show;

namespace FastKeySimulator
{
    public class FastKeySim
    {


        private KeyBoardClick keyboard = new KeyBoardClick();
        private MouseClick mouseClick = new MouseClick();
        private CursorMotion mouseMotion = new CursorMotion();
        private MouseScrollWheel mouseScrollWheel = new MouseScrollWheel();
        private MouseSetCursorPos mouseSetCursorPos = new MouseSetCursorPos();
        public async Task KeyBoardClick(int timeDelay, params ushort[] scanCode)
        {

            await keyboard.Click(scanCode, timeDelay);

        }
      
        public void MouseClick(string name)
        {

            mouseClick.Click(name);

        }
       
        public async Task MouseScrollWheel(int count, int timeDelay)
        {

            await mouseScrollWheel.ScrollWheelAsync(count, timeDelay);

        }
      
        public void MouseSetCursorPos(int x, int y)
        {
            mouseSetCursorPos.SetCursorPosition(x, y);
        }
      
        public async Task CursorMotion(int x, int y, int steps, int timeDelay)
        {

            await mouseMotion.ShowMouse(x, y, steps, timeDelay);

        }

    }
}
