using UnityEngine;
using UnityEngine.UI;

public abstract class FillableArea : BaseArea
{
    [SerializeField] protected bool isFilling;
    [SerializeField] protected float fillSpeed;
    [SerializeField] protected float fillAmount;
    [SerializeField] protected int pointsValue;
    [SerializeField] protected Image gauge;

    protected override void Start()
    {
        base.Start();
        ResetFillAmount();
    }

    private void Update()
    {
        UpdateFillAmount();
    }

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

    /// <summary>
    /// Update the gauge
    /// </summary>
    private void UpdateGauge()
    {
        gauge.fillAmount = fillAmount;
    }

    /// <summary>
    /// Reset the fill amount
    /// </summary>
    protected void ResetFillAmount()
    {
        fillAmount = 0f;
        UpdateGauge();
    }

    /// <summary>
    /// Method called when the fill amount reaches the max value
    /// </summary>
    protected virtual void OnFilled()
    {
        GameManager.Instance.AddPoints(pointsValue);
    }
}