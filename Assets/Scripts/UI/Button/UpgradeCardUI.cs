using UnityEngine;

public class UpgradeCardUI : MonoBehaviour
{
    [SerializeField] private GameObject UpgradeCards;

    private void OnEnable()
    {
        ExperienceManager.onBarFilledUp += ExperienceManager_onBarFilledUp;
    }

    private void ExperienceManager_onBarFilledUp(object sender, System.EventArgs e)
    {
        UpgradeCards.SetActive(true);
        Time.timeScale = 0f;
    }

    private void OnDisable()
    {
        ExperienceManager.onBarFilledUp -= ExperienceManager_onBarFilledUp;
    }
}
