using System;
using UnityEngine;

public class EnemyAnimationEventHandler : MonoBehaviour
{
    public event Action HitAnimationEnded;
    public event Action Attacked;
    public event Action AttackEnded;

    private void Ended()
    {
        HitAnimationEnded?.Invoke();
    }

    private void OnAttack()
    {
        Attacked?.Invoke();
    }

    private void OnAttackEnd()
    {
        AttackEnded?.Invoke();
    }
}
