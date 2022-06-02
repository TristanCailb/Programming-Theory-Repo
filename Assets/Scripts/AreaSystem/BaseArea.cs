using UnityEngine;

public abstract class BaseArea : MonoBehaviour
{
    protected SpriteRenderer rend;
    
    [SerializeField] protected bool isPlayerInArea;
    [SerializeField] protected Color activeAreaColor;
    [SerializeField] protected Color inactiveAreaColor;

    protected virtual void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        UpdateAreaColor();
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        isPlayerInArea = true;
        UpdateAreaColor();
    }

    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        isPlayerInArea = false;
        UpdateAreaColor();
    }

    /// <summary>
    /// Update the area color
    /// </summary>
    protected virtual void UpdateAreaColor()
    {
        rend.color = isPlayerInArea ? activeAreaColor : inactiveAreaColor;
    }
}