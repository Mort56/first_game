using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(IInteractable))]
public class PortalActivated : MonoBehaviour, IInteractable
{
    private static readonly int StartGame = Animator.StringToHash("StartGame"); 
    [SerializeField] private Animator portalAnimator;
    
    public void Interact()
    {
        portalAnimator.SetTrigger(StartGame);

        var animationTime = 3f;
        while (animationTime > 0f)
            animationTime -= Time.deltaTime;

        SceneManager.LoadScene("Game");
    }
}
