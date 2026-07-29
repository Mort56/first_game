using UnityEngine;

public class BulletPoolManager : MonoBehaviour
{
    [SerializeField] private BulletMovement bulletPrefab;
    [SerializeField] private int bulletCount;
    [SerializeField] private Transform container;
    public static BulletPoolManager Instance;
    private ObjectPool<BulletMovement> _bulletPool;

    private void Awake()
    {
        Instance = this;
        _bulletPool = new ObjectPool<BulletMovement>(bulletPrefab, bulletCount, container);
    }

    public BulletMovement GetBullet()
    {
        return _bulletPool.GetFreeElement();
    }

    public void ReturnBullet(BulletMovement bullet)
    {
        _bulletPool.Release(bullet);
    }
}
