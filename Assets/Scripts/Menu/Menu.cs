using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
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
}
