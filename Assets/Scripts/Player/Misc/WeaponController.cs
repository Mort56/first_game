using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private float _angle;

    public void ChangeTransform(Vector2 playerLastDirection)
    {
        _angle = Mathf.Atan2(playerLastDirection.y, playerLastDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, _angle);
    }
}
