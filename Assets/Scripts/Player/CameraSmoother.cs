using UnityEngine;

public class CameraSmoother : MonoBehaviour
{
    [SerializeField] private float _smoothValue;
    [SerializeField] private Vector3 _offset;

    private Quaternion _lastRotation;

    private void Start()
    {
        _lastRotation = transform.rotation;
    }

    private void LateUpdate()
    {
        transform.rotation = Quaternion.Lerp(_lastRotation, transform.rotation, _smoothValue);
        transform.rotation = Quaternion.Euler(transform.eulerAngles + _offset);

        _lastRotation = transform.rotation;
    }
}
