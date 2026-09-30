using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{

    public static DeathScreen instance;
    [SerializeField] private GameObject tryAgainButton; // This creates the ability to link a button to the RestartGame function

    private void Awake()
    {
        instance = this;
    }

    public void OpenEndScreen() // This funtion ends the game and allows for the "Restart" Button to appear
    {
        Time.timeScale = 0;
        tryAgainButton.SetActive(true);
    }

    public void RestartGame() // This code restarts the scene
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }



}
