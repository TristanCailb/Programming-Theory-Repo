using UnityEngine;
using UnityEngine.UI;

// INHERITANCE
public abstract class FillableArea : BaseArea
{
    [SerializeField] protected bool isFilling;
    [SerializeField] protected float fillSpeed;
    [SerializeField] protected float fillAmount;
    [SerializeField] protected int pointsValue;
    [SerializeField] protected Image gauge;

    // POLYMORPHISM
    protected override void Start()
    {
        base.Start();
        ResetFillAmount();
    }

    private void Update()
    {
        UpdateFillAmount();
    }

    // POLYMORPHISM
    /// <summary>
    /// Update the fill amount
    /// </summary>
    protected virtual void UpdateFillAmount()
    {
        if (!isFilling) return;
        fillAmount += Time.deltaTime * fillSpeed;

        if (fillAmount > 1)
        {
            fillAmount = 0f;
            OnFilled();
        }
        
        UpdateGauge();
    }

    // ABSTRACTION
    /// <summary>
    /// Update the gauge
    /// </summary>
    private void UpdateGauge()
    {
        gauge.fillAmount = fillAmount;
    }

    // ABSTRACTION
    /// <summary>
    /// Reset the fill amount
    /// </summary>
    protected void ResetFillAmount()
    {
        fillAmount = 0f;
        UpdateGauge();
    }

    /// <summary>
    /// Set the points value
    /// </summary>
    public void SetPointsValue(int value)
    {
        pointsValue = value;
    }

    // ABSTRACTION
    /// <summary>
    /// Method called when the fill amount reaches the max value
    /// </summary>
    protected virtual void OnFilled()
    {
        GameManager.Instance.AddPoints(pointsValue);
    }
}