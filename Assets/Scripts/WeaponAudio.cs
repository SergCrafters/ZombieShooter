using UnityEngine;

public class WeaponAudio : MonoBehaviour
{
    [SerializeField] private float _minPitch;
    [SerializeField] private float _maxPitch;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _shotSound;
    [SerializeField] private AudioClip _reloadSound;

    private void OnEnable()
    {
        _weapon.Shot += PlayShotSound;
        _weapon.Reloaded += PlayReloadSound;
    }

    private void OnDisable()
    {
        _weapon.Shot -= PlayShotSound;
        _weapon.Reloaded -= PlayReloadSound;
    }

    private void PlayShotSound()
    {
        _source.clip = _shotSound;
        _source.pitch = Random.Range(_minPitch, _maxPitch);
        _source.Play();
    }

    private void PlayReloadSound()
    {
        _source.clip = _reloadSound;
        _source.Play();
    }
}
