using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("BenJammin");
    }

    /*
    public void LoadOptions()
    {
        
    }
    */

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
