using UnityEngine;

public class InteractionZone : MonoBehaviour
{
    [SerializeField] private IInteractable interactable;
    private bool _isPlayerInZone = false;

    private void Awake()
    {
        interactable = GetComponent<IInteractable>();
    }

    private void Update()
    {
        if (_isPlayerInZone && Input.GetKeyDown(KeyCode.E))
            interactable.Interact();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            _isPlayerInZone = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            _isPlayerInZone = false;
    }
}