using System;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);
    private const string MouseX = "Mouse X";
    private const string MouseY = "Mouse Y";

    [SerializeField] private List<KeyCode> _jumpKeys;
    [SerializeField] private List<KeyCode> _shootKeys;

    public event Action<float, float> Moved;
    public event Action<float, float> Looked;
    public event Action Jumped;
    public event Action Shot;

    private void Update()
    {
        float horizontal = Input.GetAxisRaw(Horizontal);
        float vertical = Input.GetAxisRaw(Vertical);
        Moved?.Invoke(horizontal, vertical);

        float mouseX = Input.GetAxis(MouseX);
        float mouseY = Input.GetAxis(MouseY);
        Looked?.Invoke(mouseX, mouseY);

        foreach (KeyCode key in _jumpKeys)
        {
            if (Input.GetKeyDown(key))
            {
                Jumped?.Invoke();
            }
        }

        foreach (KeyCode key in _shootKeys)
        {
            if (Input.GetKeyDown(key))
            {
                Shot?.Invoke();
            }
        }
    }
}
