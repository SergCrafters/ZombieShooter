using UnityEngine;

public class PlayerLooker : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _lookSens;
    [SerializeField] private float _minRotationX;
    [SerializeField] private float _maxRotationX;

    private float _rotationX = 0f;

    private void OnEnable()
    {
        _inputReader.Looked += Look;
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnDisable()
    {
        _inputReader.Looked -= Look;
    }

    private void Look(float horizontal, float vertical)
    {
        _rotationX -= vertical * _lookSens * Time.deltaTime;
        float rotationYDelta = horizontal * _lookSens * Time.deltaTime;

        _rotationX = Mathf.Clamp(_rotationX, _minRotationX, _maxRotationX);

        _camera.transform.localRotation = Quaternion.Euler(_rotationX, 0, 0);
        transform.Rotate(Vector3.up * rotationYDelta);
    }
}
