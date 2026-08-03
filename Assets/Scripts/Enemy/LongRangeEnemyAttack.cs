public class LongRangeEnemyAttack : AbstractEnemyAttack
{
    private BulletMovement _currentBullet;

    public void Shoot()
    {
        _currentBullet = BulletSpawner.Instance.GetBullet();
        if (_currentBullet == null)
            return;
        _currentBullet.transform.position = transform.position;
        _currentBullet.GetTargetVector(Player.Instance.transform.position, damage);
    }
}
