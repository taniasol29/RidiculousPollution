using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PathFollower : MonoBehaviour
{
    private BoatInputs _boatInputs;
    private Rigidbody _rbody;
    private Vector2 moveVec;
    private bool isMoving;
    
    [SerializeField] private Transform[] boatPath;

    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float turningSpeed = 4.0f;
    [SerializeField] private float reachDistance = 1.0f;
    public int currentPoint = 0;

    private void Awake()
    {
        _boatInputs = new BoatInputs();
        _rbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _boatInputs.BoatMovements.Enable();
    }

    private void OnDisable()
    {
        _boatInputs.BoatMovements.Disable();
    }

    void Update()
    {
        moveVec = _boatInputs.BoatMovements.Move.ReadValue<Vector2>();
        //_rbody.velocity = moveVec * speed;
        MakeBoatMove(boatPath);
       
    }

    void MakeBoatMove(Transform[] p)
    {
        Vector3 direction = p[currentPoint].position - transform.position;
        direction.y = 0;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * turningSpeed);
        float dist = Vector3.Distance(p[currentPoint].position, transform.position);
        transform.position = Vector3.MoveTowards(transform.position, p[currentPoint].position, Time.deltaTime * speed);

        if (dist <= reachDistance)
        {
            currentPoint++;
        }

        if (currentPoint >= p.Length)
        {
            currentPoint = 0;
        }
    }
}
