using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    private string _startGameScene = "StartGame";
    public void onClickStart()
    {
        SceneManager.LoadScene(_startGameScene);
        Time.timeScale = 1.0f;
    }

    public void onClickQuit()
    {
        Application.Quit();       
    }
}
