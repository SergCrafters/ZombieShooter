using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private List<Weapon> _weapons;

    private Weapon _currentWeapon;  

    private void OnEnable()
    {
        _inputReader.Shot += Shoot;
    }

    private void Start()
    {
        _currentWeapon = _weapons[0];
    }

    private void OnDisable()
    {
        _inputReader.Shot -= Shoot;
    }

    private void Shoot()
    {
        _currentWeapon.Shot(_camera);
    }

    private void SwitchWeapon()
    {

    }
}
