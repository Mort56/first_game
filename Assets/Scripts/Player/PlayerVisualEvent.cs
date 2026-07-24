using UnityEngine;

public class PlayerVisualEvents : MonoBehaviour
{
    [SerializeField] private Player player;

    public void EnableMovement()
    {
        player.EnableMovement();
    }
}