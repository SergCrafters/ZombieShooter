    using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private readonly int X = Animator.StringToHash(nameof(X));
    private readonly int Y = Animator.StringToHash(nameof(Y));
    private readonly int Fire = Animator.StringToHash(nameof(Fire));
    private readonly int Reload = Animator.StringToHash(nameof(Reload));

    [SerializeField] private PlayerMover _mover;
    [SerializeField] private Animator _animator;
    [SerializeField] private Shooter _shooter;
    [SerializeField] private float _smoothCoefficient;


    private void OnEnable()
    {
        _mover.Moved += UpdateMoveParametrs;
        _shooter.Shot += PlayShootAnimation;
        _shooter.Reloaded += PlayReloadAnimation;
    }

    private void OnDisable()
    {
        _mover.Moved -= UpdateMoveParametrs;
        _shooter.Shot -= PlayShootAnimation;
        _shooter.Reloaded -= PlayReloadAnimation;
    }

    private void UpdateMoveParametrs(Vector2 direction)
    {
        Vector2 currentParams = new Vector2(_animator.GetFloat(X), _animator.GetFloat(Y));
        direction = Vector2.Lerp(currentParams, direction, _smoothCoefficient);

        _animator.SetFloat(X, direction.x);
        _animator.SetFloat(Y, direction.y);
    }

    private void PlayShootAnimation()
    {
        _animator.SetTrigger(Fire);
    }

    private void PlayReloadAnimation()
    {
        _animator.SetTrigger(Reload);
    }
}
