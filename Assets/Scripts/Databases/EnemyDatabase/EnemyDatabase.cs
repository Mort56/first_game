using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Database", menuName = "Database/Enemys")]
public class EnemyDatabase : GenericDatabase<Enemy>
{

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