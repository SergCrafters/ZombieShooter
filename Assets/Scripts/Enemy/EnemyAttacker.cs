using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _attackDistance;
    [SerializeField] private PlayerHealth _player;

    private void Update()
    {
        if(Vector3.Distance(transform.position, _player.transform.position) <= _attackDistance)
        {
            Attack();
        }
    }

    private void Attack()
    {
        _player.TakeDamage(_damage * Time.deltaTime);
    }
}
