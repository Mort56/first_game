using UnityEngine;

public class WeaponColliderActivation : MonoBehaviour
{
    [SerializeField] private Collider2D attackCollider;

    public void EnableCollider()
    {
        attackCollider.enabled = true;
    }

    public void DisableCollider()
    {
        attackCollider.enabled = false;
    }
}
