// INHERITANCE
public class AutoFillArea : FillableArea
{
    // POLYMORPHISM
    protected override void Start()
    {
        base.Start();
        isFilling = true;
    }

    // POLYMORPHISM
    protected override void UpdateAreaColor()
    {
        rend.color = activeAreaColor;
    }
}