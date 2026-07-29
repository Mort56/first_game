using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyDatabase enemyDatabase;
    [SerializeField] private Health health;
    [SerializeField] private int id;
    public Enemy Data { get; private set; }

    public void Initialize(int id)
    {
        this.id = id; 
        Data = enemyDatabase.GetEnemyById(id);
    }

    private void Awake()
    {
        Initialize(id);
    }

    private void Start()
    {
        health.ChangeMaxHealth(Data.MaxHealth);
    }
}
