using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private readonly int Die = Animator.StringToHash(nameof(Die));
    private readonly int Hit = Animator.StringToHash(nameof(Hit));
    private readonly int Attack = Animator.StringToHash(nameof(Attack));

    [SerializeField] private Animator _animator;
    [SerializeField] private EnemyHealth _health;
    [SerializeField] private EnemyAttacker _attacker;
    [SerializeField] private EnemyMover _mover;

    private void OnEnable()
    {
        _attacker.Attaking += PlayAttackAnimation;
        _health.Died += PlayDeathAnimation;
        _health.TookDamage += PlayHitAnimation;
    }

    private void OnDisable()
    {
        _attacker.Attaking -= PlayAttackAnimation;
        _health.Died -= PlayDeathAnimation;
        _health.TookDamage -= PlayHitAnimation;
    }

    private void PlayDeathAnimation(Health _)
    {
        _animator.SetTrigger(Die);
    }

    private void PlayHitAnimation()
    {
        _animator.SetTrigger(Hit);
    }

    private void PlayAttackAnimation()
    {
        //_mover.IsMove(false);
        _animator.SetTrigger(Attack);
    }
}
