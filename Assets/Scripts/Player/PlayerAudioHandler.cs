using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioHandler : MonoBehaviour
{
    [SerializeField] private float _minPitch;
    [SerializeField] private float _maxPitch;
    [SerializeField] private PlayerMover _player;
    [SerializeField] private AudioSource _source;
    [SerializeField] private List<AudioClip> _stepSound;

    private void OnEnable()
    {
        _player.Moved += PlayStepSound;
    }

    private void OnDisable()
    {
        _player.Moved -= PlayStepSound;
    }

    private void PlayStepSound(Vector2 direction)
    {
        if (direction != Vector2.zero && _source.isPlaying == false)
        {
            _source.clip = _stepSound[Random.Range(0, _stepSound.Count)];
            _source.pitch = Random.Range(_minPitch, _maxPitch);
            _source.Play();
        }
    }
}
