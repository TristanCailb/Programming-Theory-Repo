using UnityEngine;

public class PresenceArea : FillableArea
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        isFilling = true;
    }

    protected override void OnTriggerExit2D(Collider2D other)
    {
        base.OnTriggerExit2D(other);
        isFilling = false;
        ResetFillAmount();
    }

    protected override void UpdateFillAmount()
    {
        if (!isPlayerInArea) return;
        base.UpdateFillAmount();
    }
}