using UnityEngine;

// INHERITANCE
public class PresenceArea : FillableArea
{
    // POLYMORPHISM
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        isFilling = true;
    }

    // POLYMORPHISM
    protected override void OnTriggerExit2D(Collider2D other)
    {
        base.OnTriggerExit2D(other);
        isFilling = false;
        ResetFillAmount();
    }

    // POLYMORPHISM
    protected override void UpdateFillAmount()
    {
        if (!isPlayerInArea) return;
        base.UpdateFillAmount();
    }
}