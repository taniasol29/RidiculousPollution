using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _velocity;
    private HookInputs _hookInputs;
    //private Rigidbody _rbody;
    private Vector2 _moveInput;
    public Vector3 hookGravity = Physics.gravity;

    public bool collided = false;

    private void Awake()
    {
        _hookInputs = new HookInputs();
        //_rbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _hookInputs.Hook.Enable();
    }

    private void OnDisable()
    {
        _hookInputs.Hook.Disable();
    }

    private void Update()
    {
        _moveInput = _hookInputs.Hook.Move.ReadValue<Vector2>();
        transform.position += new Vector3(_moveInput.x, hookGravity.y * Time.deltaTime, 0.0f);
        Vector3 newPos = transform.position;
        newPos.x = Mathf.Clamp(newPos.x, -20.0f, 20.0f);
        transform.position = newPos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.tag == "Fish" || collision.gameObject.tag == "Polluant"))
        {
            collided = true;
            ReverseGravity();
        }
    }

    public void ReverseGravity()
    {
        if (collided)
        {
            hookGravity = -Physics.gravity;
        }
    }
}
