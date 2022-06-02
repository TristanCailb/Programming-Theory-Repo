using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    /// <summary>
    /// Go to the game scene
    /// </summary>
    public void GoToGame()
    {
        SceneManager.LoadScene(1);
    }
}
