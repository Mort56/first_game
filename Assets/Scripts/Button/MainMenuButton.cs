using Unity.Loading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void onClickStart()
    {
        SceneManager.LoadScene("StartGame");
        Time.timeScale = 1.0f;
    }

    public void onClickQuite()
    {
        Application.Quit();       
    }
}
