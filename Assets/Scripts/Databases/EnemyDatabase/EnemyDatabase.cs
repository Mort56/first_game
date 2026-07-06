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


    [SerializeField] private Sprite icon;
    public Sprite Icon => icon;

    [SerializeField] private EnemyModifier enemyType;
    public EnemyModifier EnemeyType => enemyType;
}

public enum EnemyModifier
{
    Normal, 
    Elite
}