using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSettings : MonoBehaviour
{
    [SerializeField] private GameObject buttonZone;

    public void OnClickSettings()
    {
        buttonZone.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OnClickReturnToPlay()
    {
        buttonZone.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void OnClickReturnToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }
}
