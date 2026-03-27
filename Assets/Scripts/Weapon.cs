using UnityEngine;

public class Weapon : MonoBehaviour
{
    private readonly Vector2 _screenShotPercent = new Vector2 (0.5f, 0.5f);
   
    [SerializeField] private WeaponName _weaponName;
    [SerializeField] private float _damage;
    [SerializeField] private GameObject _test;

    public void Shot(Camera camera)
    {
        Ray ray = camera.ViewportPointToRay(_screenShotPercent);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Instantiate(_test, hit.point, Quaternion.identity);
        }
    }
}


public enum WeaponName
{
    AK47,
    HuntingPistol
}