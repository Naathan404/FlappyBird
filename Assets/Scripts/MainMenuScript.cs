using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public static GameManager instance;
    public void StartGame()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void OpenSetting()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}

public class RSHS : Movement
{ 

}
