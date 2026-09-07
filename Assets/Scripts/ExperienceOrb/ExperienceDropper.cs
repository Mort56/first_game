using UnityEngine;

public class ExperienceDropper : MonoBehaviour
{
    [SerializeField] private EnemyController enemyController;
    [SerializeField] private Health health;

    private void OnEnable()
    {
        health.onDeath += SpawnOrb;
    }

    private void OnDisable()
    {
        health.onDeath -= SpawnOrb;
    }

    private void SpawnOrb(object sender, System.EventArgs e)
    {
        for (int i = 0; i < enemyController.Data.OrbCount; i++)
        {
            var orb = ExperienceOrbSpawner.Instance.GetItem();
            if (orb != null)
            {
                orb.transform.position = transform.position;
                orb.StartSpawnAnimation();
            }
        }
    }
}
