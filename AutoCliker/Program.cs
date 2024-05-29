using System.Runtime.InteropServices;

[DllImport("user32.dll")]
static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData , IntPtr dwExtraInfo);

[DllImport("user32.dll")]
static extern short GetAsyncKeyState (int vKey);

const uint LEFTDOWN = 0x02;
const uint LEFTUP = 0x04;
const int HOTKEY = 0x76;// F7

bool enableClicker = false;
int clickerInterval = 5;

while (true)
{
    if (GetAsyncKeyState(HOTKEY) < 0)
    {
        enableClicker = !enableClicker;
        Thread.Sleep(300);
    }
    if (enableClicker == true)
    {
        MouseClick();
    }
    Thread.Sleep(clickerInterval);
}
void MouseClick()
{
    mouse_event(LEFTDOWN, 0, 0, 0, IntPtr.Zero);
    mouse_event(LEFTUP, 0, 0, 0, IntPtr.Zero);
}
