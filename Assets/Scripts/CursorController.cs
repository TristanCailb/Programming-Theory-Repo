using UnityEngine;

public class CursorController : MonoBehaviour
{
    private SpriteRenderer _rend;
    private Camera _mainCam;

    [SerializeField] private Color mouseUpColor = new Color(1f, 1f, 1f, 0.2f);
    [SerializeField] private Color mouseDownColor = Color.white;

    private void Start()
    {
        _rend = GetComponent<SpriteRenderer>();
        _mainCam = Camera.main;
        _rend.color = mouseUpColor;
        Cursor.visible = false;
    }

    private void Update()
    {
        UpdatePosition();
        UpdateColor();
    }

    // ABSTRACTION
    /// <summary>
    /// Update cursor position
    /// </summary>
    private void UpdatePosition()
    {
        var position = _mainCam.ScreenToWorldPoint(Input.mousePosition);
        position.z = 0f;
        transform.position = position;
    }

    // ABSTRACTION
    /// <summary>
    /// Update cursor color
    /// </summary>
    private void UpdateColor()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _rend.color = mouseDownColor;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _rend.color = mouseUpColor;
        }
    }
}