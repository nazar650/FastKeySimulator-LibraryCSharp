# FastKeySimulator V 1.2.1(Doesn't Works v 1.2.1)
The **FastKeySimulator library** for C# allows programmatic control of the keyboard and mouse in Windows via the WinAPI. It uses the low-level **SendInput API**, which emulates physical key presses, mouse clicks, and cursor movements.
Key Features

---
## Key Features

### 1. Keyboard
- **Keystrokes**
- **Supports multiple keys pressed simultaneously**
- **Layout-independent** (QWERTY, RUS, ENG, etc.)

### 2. Mouse
- **Left, Right, and Middle clicks**
- **Scroll wheel support**
- **Move the cursor to absolute coordinates**
- **Smooth cursor movement**
---
## Keyboard Simulation with FastKeySim
The **FastKeySim** class allows you to easily simulate keyboard and mouse input in your C# applications. You can press single keys or key combinations with a single method call, without worrying about low-level WinAPI details.The **KeyboardClick()** method allows you to simulate pressing single keys or key combinations on the keyboard with just one call. It handles both the press and release events, so Windows sees it as a real key press.

### How to use **KeyBoardClick(int timeDelay,params ushort[] scanCode)**
- **timeDelay** – Delay in milliseconds before releasing the key.
  - If **timeDelay** < 6 a single key/key combination is pressed.
  - If **timeDelay** > 6 the keys will be held down for the specified time before being released.
- **scanCode** – one or more scan codes of the keys to press. You can pass both individual keys and combinations.
```csharp
using FastKeySimulator;
internal class Program
{
    private static async Task Main(string[] args)
    {
        FastKeySim fast=new FastKeySim();
        Thread.Sleep(6000);
        // Press a single key
        await fast.KeyBoardClick(0,ScanCode.W);
        // Press a key combination (0,RShift + w)
        await fast.KeyBoardClick(0,ScanCode.RShift,ScanCode.W);
        // Press multiple keys (0,Alt + RShift)
        await fast.KeyBoardClick(0,ScanCode.Alt,ScanCode.RShift);
    }
}
```
## Mouse Simulation with FastKeySim

- The FastKeySim class also provides powerful tools for simulating mouse input in your C# applications. It allows you to perform mouse clicks, scroll the mouse wheel, move the cursor to specific screen positions, and create smooth cursor movements — all with simple and high-level method calls.

- The **MouseClick()** method allows you to simulate left, right, and middle mouse button clicks. It automatically handles both the press and release events, so Windows recognizes the action as a real physical mouse click.

- The **MouseScrollWheel()** method allows you to simulate mouse wheel scrolling. You can scroll up or down by specifying the number of steps and control the scrolling speed using a time delay.

- The **MouseSetCursorPos()** method allows you to instantly move the mouse cursor to any position on the screen using absolute coordinates.

- The **CursorMotion()** method allows you to smoothly move the mouse cursor by a specified number of pixels.

### How to use **MouseClick(string name)**
```csharp
using FastKeySimulator;
internal class Program
{
    private static void Main(string[] args)
    {
        FastKeySim fast=new FastKeySim();
        Thread.Sleep(6000);

        // Left mouse click
        fast.MouseClick(Mouse.Left);

        // Right mouse click
        fast.MouseClick(Mouse.Right);

        // Middle mouse click
        fast.MouseClick(Mouse.Middle);

    }
}
```
### How to use **MouseScrollWheel(int count, int timeDelay)**
- **count** — Number of scroll steps
   - Positive value → scroll up
   - Negative value → scroll down
- **timeDelay** — Delay in milliseconds between scroll steps
```csharp
using FastKeySimulator;
internal class Program
{
    private static async Task Main(string[] args)
    {
        FastKeySim fast=new FastKeySim();
        Thread.Sleep(6000);
        // Scroll up 3 steps
        await fast.MouseScrollWheel(3, 10);

        // Scroll down 2 steps
       await fast.MouseScrollWheel(-2, 15);
    }
}
```
###  How to use  **MouseSetCursorPos(int x, int y)**
Moves the mouse cursor to an absolute screen position.
- **x** — X coordinate (pixels)
- **y** — Y coordinate (pixels)
```csharp
using FastKeySimulator;
internal class Program
{
    private static void Main(string[] args)
    {
        FastKeySim fast=new FastKeySim();
        Thread.Sleep(6000);
        // Move cursor to position (500, 300)
        fast.MouseSetCursorPos(500, 300);

        // Move cursor to top-left corner
        fast.MouseSetCursorPos(0, 0);
    }
}
```
###  How to use **CursorMotion(int x,int y,int steps,int timeDelay)**
- **x**     — Total horizontal movement in pixels
  - Positive value of movement to the right
  - Negative value of movement to the left
- **y**    — Total vertical movement in pixels
   - Positive value of movement to the down
   - Negative value of movement to the up
- **steps** — number of movement steps  
- **timeDelay**  — Delay between steps in milliseconds
```csharp
using FastKeySimulator;
internal class Program
{
    private static async Task Main(string[] args)
    {
        FastKeySim fast=new FastKeySim();
        Thread.Sleep(6000);
        //Moves 200px right, 100px down, in 20 steps, with 10ms delay.
        await fast.MouseShowMouse(200, 100, 20, 10);
    }
}
```
