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
    List<GameObject> collectibles = new List<GameObject>();
    [SerializeField] private float limitHookPos;
    [SerializeField] private float limitUpPos;

    public bool collided = false;

    //[Header("Air")]
    //private Transform camTarget;

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
        transform.position += new Vector3(_moveInput.x * 15.0f, hookGravity.y, 0.0f) * Time.deltaTime;
        Vector3 newPos = transform.position;
        newPos.x = Mathf.Clamp(newPos.x, -20.0f, 20.0f);
        transform.position = newPos;  
    }

    private void FixedUpdate()
    {
        AirState();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.tag == "Fish" || collision.gameObject.tag == "Polluant"))
        {
            collided = true;
            collectibles.Add(collision.gameObject);
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

    public void AirState()
    {
        var pos = transform.position;

        if(pos.y >= limitHookPos)
        {
            Debug.Log("Air state");
            //hookGravity = Vector3.zero;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            ExplodeCollectibles();
            //if (camTarget != null)
            //camTarget = new GameObject("up").transform;
            //Camera.main.GetComponent<FollowCamera>().target = newCamTarget;
        }
    }

    public void ExplodeCollectibles()
    {
        var forceSpeed = 0.0f;
        
        foreach (var col in collectibles)
        {
            var upLimit = col.transform.position;
            if(upLimit.y < limitUpPos)
            {
                Debug.Log("UpLimit moins limitPos : " + upLimit.y);
                
                forceSpeed = 0.35f;
            }
            else if(upLimit.y > limitUpPos)
            {
                Debug.Log("UpLimitplus limitPos : " + upLimit.y);
                forceSpeed = 0.01f;
                hookGravity = Vector3.zero;
            }

            Debug.Log("ForceSpeed :" + forceSpeed);
            Vector3 pos = new Vector3(Random.Range(-forceSpeed, forceSpeed), forceSpeed, 0.0f);
            col.GetComponent<CollectMove>().BreakJoint();
            var rb = col.GetComponent<Rigidbody>(); //.useGravity = true;
            rb.useGravity = true;

            rb.AddForce(pos, ForceMode.Impulse); 
        }
    } 
}
