    using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private readonly int X = Animator.StringToHash(nameof(X));
    private readonly int Y = Animator.StringToHash(nameof(Y));

    [SerializeField] private PlayerMover _mover;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _smoothCoefficient;


    private void OnEnable()
    {
        _mover.Moved += UpdateMoveParametrs;
    }

    private void OnDisable()
    {
        _mover.Moved -= UpdateMoveParametrs;
    }

    private void UpdateMoveParametrs(Vector2 direction)
    {
        Vector2 currentParams = new Vector2(_animator.GetFloat(X), _animator.GetFloat(Y));
        direction = Vector2.Lerp(currentParams, direction, _smoothCoefficient);

        _animator.SetFloat(X, direction.x);
        _animator.SetFloat(Y, direction.y);
    }
}
