using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Database", menuName = "Database/Enemys")]
public class EnemyDatabase : GenericDatabase<Enemy>
{
    public Enemy GetEnemyById(int id)
    {
        return items.FirstOrDefault(e => e.Id == id);
    }
}

[System.Serializable]
public class Enemy
{
    [SerializeField] private int id;
    public int Id => id;

    [SerializeField] private float maxHealth;
    public float MaxHealth => maxHealth;

    [SerializeField] private float damage;
    public float Damage => damage;

    [SerializeField] private float speed;
    public float Speed => speed;

    [SerializeField] private float attackDistanceByX;
    public float AttackDistanceByX => attackDistanceByX;

    [SerializeField] private float attackDistanceByY;
    public float AttackDistanceByY => attackDistanceByY;

    [SerializeField] private float cooldawn;
    public float Cooldawn => cooldawn;

    [SerializeField] private EnemyModifier enemyType;
    public EnemyModifier EnemeyType => enemyType;
    [SerializeField] private float spawnChance;
    public float SpawnChance => spawnChance;

}

public enum EnemyModifier
{
    Normal, 
    Elite
}