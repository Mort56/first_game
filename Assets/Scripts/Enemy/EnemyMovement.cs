using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMesh;
    [SerializeField] EnemyController enemyController;
    private EnemyState _state;
    private float _speed;
    private float _damage;

    private void Awake()
    {
        navMesh.updateRotation = false;
        navMesh.updateUpAxis = false;
        _state = EnemyState.chase;
        _speed = enemyController.Data.Speed;
        _damage = enemyController.Data.Damage;

    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        switch (_state)
        {
            case EnemyState.chase:
                navMesh.SetDestination(Player.Instance.transform.position);
                break;
            case EnemyState.attack:

                break;
        }
    }

}

public enum EnemyState
{
    attack, 
    chase
}