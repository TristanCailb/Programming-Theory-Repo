using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);
    }
    #endregion

    [SerializeField] private TMP_Text scoreText;
    private int _currentPoints;

    private void Start()
    {
        UpdateScoreText();
    }

    /// <summary>
    /// Add points
    /// </summary>
    public void AddPoints(int amount)
    {
        _currentPoints += amount;
        UpdateScoreText();
    }

    /// <summary>
    /// Remove points
    /// </summary>
    public void RemovePoints(int amount)
    {
        if (!CanRemovePoints(amount)) return;
        _currentPoints -= amount;
        UpdateScoreText();
    }

    /// <summary>
    /// Check if we can remove points
    /// </summary>
    public bool CanRemovePoints(int amount)
    {
        return amount <= _currentPoints;
    }

    /// <summary>
    /// Update the score text
    /// </summary>
    private void UpdateScoreText()
    {
        scoreText.text = _currentPoints.ToString("000");
    }
}