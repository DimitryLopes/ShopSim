public class OnJobExcecutedSignal
{
    public Job Job { get; private set; }

    public OnJobExcecutedSignal(Job job)
    {
        Job = job;
    }
}
