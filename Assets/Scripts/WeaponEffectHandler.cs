using UnityEngine;

public class WeaponEffectHandler : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private ParticleSystem _particleSystem;

    private void OnEnable()
    {
        _weapon.Shot += HandleShotEffect;
    }

    private void OnDisable()
    {
        _weapon.Shot -= HandleShotEffect;
    }

    private void HandleShotEffect()
    {
        _particleSystem.Play();
    }
}
