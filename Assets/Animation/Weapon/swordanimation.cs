using UnityEngine;

public class SwordAnimation : MonoBehaviour
{
    private bool _isAttack = false;
    [SerializeField] private Animator animator;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            _isAttack = !_isAttack;
            animator.SetBool("isAttack", _isAttack);
        }
    }
}
