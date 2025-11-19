using UnityEngine;

public class MainMenuFunctions : MonoBehaviour
{
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadScene(string sceneName) 
    {
           UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    public void OpenWebURL(string WebURL) 
    {
          Application.OpenURL(WebURL);
    }

}
