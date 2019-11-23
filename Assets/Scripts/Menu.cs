using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
}
