using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudioHandler : MonoBehaviour
{
    [SerializeField] private float _minPitch;
    [SerializeField] private float _maxPitch;
    [SerializeField] private float _ambientPlayDelay;
    [SerializeField] private AudioSource _source;
    [SerializeField] private List<AudioClip> _ambientSounds;
    [SerializeField] private AudioClip _attackSound;
    [SerializeField] private AudioClip _hitSound;
    [SerializeField] private EnemyAttacker _attacker;
    [SerializeField] private EnemyHealth _health;

    private Coroutine _playingAmbientSouns;

    private void OnEnable()
    {
        _attacker.Attaking += PlayAttackSound;
        _health.TookDamage += PlayHitSound;

        if(_playingAmbientSouns != null)
        {
            StopCoroutine(_playingAmbientSouns);
        }

        _playingAmbientSouns = StartCoroutine(PlayAmbientSound());
    }

    private void OnDisable()
    {
        _attacker.Attaking -= PlayAttackSound;
        _health.TookDamage -= PlayHitSound;
    }

    private IEnumerator PlayAmbientSound() 
    {
        var wait = new WaitForSeconds(_ambientPlayDelay);

        while (enabled)
        {
            yield return wait;

            if (_source.isPlaying == false)
            {
                _source.pitch = Random.Range(_minPitch, _maxPitch);
                _source.clip = _ambientSounds[Random.Range(0, _ambientSounds.Count)];
                _source.Play();
            }
        }

        _playingAmbientSouns = null;
    }

    private void PlayAttackSound() 
    {
        _source.pitch = Random.Range(_minPitch, _maxPitch);
        _source.clip = _attackSound;
        _source.Play();
    }
    
    private void PlayHitSound() 
    {
        _source.pitch = Random.Range(_minPitch, _maxPitch);
        _source.clip = _hitSound;
        _source.Play();
    }
}
