using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _velocity;
    private HookInputs _hookInputs;
    private Rigidbody _rbody;
    private Vector2 _moveInput;
    //public bool useGravity = true;

    private void Awake()
    {
        _hookInputs = new HookInputs();
        _rbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _hookInputs.Hook.Enable();
    }

    private void OnDisable()
    {
        _hookInputs.Hook.Disable();
    }

    private void FixedUpdate()
    {
        _moveInput = _hookInputs.Hook.Move.ReadValue<Vector2>();
        _rbody.velocity = _moveInput * _speed;
        _rbody.AddForce(Physics.gravity * _velocity);
    }
}
