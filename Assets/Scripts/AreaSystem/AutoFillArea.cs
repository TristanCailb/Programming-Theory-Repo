public class AutoFillArea : FillableArea
{
    protected override void Start()
    {
        base.Start();
        isFilling = true;
    }

    protected override void UpdateAreaColor()
    {
        rend.color = activeAreaColor;
    }
}