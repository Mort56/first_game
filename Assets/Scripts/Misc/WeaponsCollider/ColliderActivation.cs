using UnityEngine;

public class WeaponColliderActivation : MonoBehaviour
{
    [SerializeField] private PolygonCollider2D polygonCollider;

    public void EnableCollider()
    {
        polygonCollider.enabled = true;
    }

    public void DisableCollider()
    {
        polygonCollider.enabled = false;
    }
}
