using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private readonly Vector2 _screenShotPercent = new Vector2(0.5f, 0.5f);

    [SerializeField] private WeaponName _weaponName;
    [SerializeField] private ParticleSystem _bloodEffect; 
    [SerializeField] private float _damage;
    [SerializeField] private int _maxMagazineCapacity;
    [SerializeField] private int _maxBulletsInInventory;
    [SerializeField] private GameObject _test;

    private int _bulletsInMagazine = 0;
    private int _bulletsInInventory = 0;

    public event Action Shot;
    public event Action Reloaded;

    private void Start()
    {
        _bulletsInMagazine = _maxMagazineCapacity;
        _bulletsInInventory = _maxBulletsInInventory;
    }


    public bool TryShot(Camera camera)
    {
        if (_bulletsInMagazine > 0)
        {
            Ray ray = camera.ViewportPointToRay(_screenShotPercent);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if(hit.collider.TryGetComponent(out EnemyHealth enemy))
                {
                    enemy.TakeDamage(_damage);
                    ParticleSystem effect = Instantiate(_bloodEffect, hit.point, Quaternion.identity);
                    effect.transform.right = hit.normal;
                }
                Instantiate(_test, hit.point, Quaternion.identity);
            }
            _bulletsInMagazine--;
            Shot?.Invoke();

            return true;
        }
        return false;
    }

    public void Reload()
    {
        int bulletToLoad = _maxMagazineCapacity - _bulletsInMagazine;

        if (bulletToLoad <= _bulletsInInventory)
        {
            _bulletsInInventory -= bulletToLoad;
        }
        else
        {
            bulletToLoad = _bulletsInInventory;
            _bulletsInInventory = 0;
        }

        _bulletsInMagazine += bulletToLoad;
        Reloaded?.Invoke();
    }
}


public enum WeaponName
{
    AK47,
    HuntingPistol
}