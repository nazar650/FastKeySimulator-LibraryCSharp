using FastKeySimulator.Keystrokes.Keyboard.Domain.Click;
using FastKeySimulator.Keystrokes.Mouse.Domain.Click;
using FastKeySimulator.Keystrokes.Mouse.Domain.Motion;
using FastKeySimulator.Keystrokes.Mouse.Domain.ScrollWheel;
using FastKeySimulator.Keystrokes.Mouse.Domain.SetCursorPos;

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
      
        public void MouseClick(string name, bool Hold)
        {

            mouseClick.Click(name, Hold);

        }
       public void MouseClickRelease()
        {
            mouseClick.ClickRelease();
        }
        public async Task MouseScrollWheel(int count, int timeDelay)
        {

            await mouseScrollWheel.ScrollWheelAsync(count, timeDelay);

        }
      
        public void MouseSetCursorPos(object x, object y)
        {
            mouseSetCursorPos.SetCursorPosition(x, y);
        }
      
        public async Task CursorMotion(int x, int y, int steps, int timeDelay)
        {

            await mouseMotion.ShowMouse(x, y, steps, timeDelay);

        }

    }
}
