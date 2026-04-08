using System;
using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _attackDistance;
    [SerializeField] private PlayerHealth _player;
    [SerializeField] private EnemyAnimationEventHandler _animationEvents;

    private bool _isAttacking = false;

    public event Action Attaking;

    private void OnEnable()
    {
        _animationEvents.Attacked += Attack;
        _animationEvents.AttackEnded += AllowAttaking;
        _animationEvents.HitAnimationEnded += AllowAttaking;
    }

    private void Update()
    {
        if (_isAttacking == false && IsPlayerNear())
        {
            StartAttaking();
        }
    }

    private void OnDisable()
    {
        _animationEvents.Attacked -= Attack;
        _animationEvents.AttackEnded -= AllowAttaking;
        _animationEvents.HitAnimationEnded += AllowAttaking;
    }

    private void StartAttaking()
    {
        _isAttacking = true;
        Attaking?.Invoke();
    }

    private void Attack()
    {
        if (IsPlayerNear())
        {
            _player.TakeDamage(_damage);
        }
    }

    private void AllowAttaking()
    {
        _isAttacking = false;
    }

    private bool IsPlayerNear() => 
        Vector3.Distance(transform.position, _player.transform.position) <= _attackDistance;
}
