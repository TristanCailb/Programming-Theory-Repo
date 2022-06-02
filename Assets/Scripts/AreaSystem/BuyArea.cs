using System.Globalization;
using TMPro;
using UnityEngine;

// INHERITANCE
public class BuyArea : BaseArea
{
    [SerializeField] private int areaPrice;
    [SerializeField] private TMP_Text priceText;
    [SerializeField] private FillableArea areaPrefab;

    // POLYMORPHISM
    protected override void Start()
    {
        base.Start();
        priceText.text = areaPrice.ToString("#,0", CultureInfo.InvariantCulture.NumberFormat).Replace(",", " ");
    }

    private void Update()
    {
        if (!isPlayerInArea) return;
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!GameManager.Instance.CanRemovePoints(areaPrice)) return;
            GameManager.Instance.RemovePoints(areaPrice);
            Instantiate(areaPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}