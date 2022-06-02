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
    public int CurrentPoints { get; private set; } // ENCAPSULATION

    private void Start()
    {
        UpdateScoreText();
    }

    // ABSTRACTION
    /// <summary>
    /// Add points
    /// </summary>
    public void AddPoints(int amount)
    {
        CurrentPoints += amount;
        UpdateScoreText();
    }

    // ABSTRACTION
    /// <summary>
    /// Remove points
    /// </summary>
    public void RemovePoints(int amount)
    {
        if (!CanRemovePoints(amount)) return;
        CurrentPoints -= amount;
        UpdateScoreText();
    }

    // ABSTRACTION
    /// <summary>
    /// Check if we can remove points
    /// </summary>
    public bool CanRemovePoints(int amount)
    {
        return amount <= CurrentPoints;
    }

    // ABSTRACTION
    /// <summary>
    /// Update the score text
    /// </summary>
    private void UpdateScoreText()
    {
        scoreText.text = CurrentPoints.ToString("000");
    }
}