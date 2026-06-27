using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSettings : MonoBehaviour
{
    [SerializeField] private GameObject buttonZone;

    public void onClickSettings()
    {
        buttonZone.SetActive(true);
        Time.timeScale = 0f;
    }

    public void onClickReturnToPlay()
    {
        buttonZone.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void onClickReturnToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void onClickQuite()
    {
        Application.Quit();
    }
}
