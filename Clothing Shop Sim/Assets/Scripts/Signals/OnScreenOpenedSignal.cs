public class OnScreenOpenedSignal
{
    public UIScreen Screen { get; private set; }
    public OnScreenOpenedSignal(UIScreen screen)
    {
        Screen = screen;
    }
}
