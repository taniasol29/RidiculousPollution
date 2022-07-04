using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovements : MonoBehaviour
{
    // Inputs 
    private HookInputs _hookInputs;
    private Vector2 _moveInput;

    // Hook physics
    public Vector3 hookGravity = Physics.gravity;
    [SerializeField] private float limitHookPos;
    private bool collided = false;

    // Collectibles
    public List<GameObject> collectibles = new List<GameObject>();
    [SerializeField] private float limitUpPos;

    private void Awake()
    {
        _hookInputs = new HookInputs();
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
            //Debug.Log("Air state");
            //hookGravity = Vector3.zero;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            ExplodeCollectibles();
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
                //Debug.Log("UpLimit moins limitPos : " + upLimit.y);
                forceSpeed = Random.Range(0.5f, 0.8f);
            }
            else if(upLimit.y > limitUpPos)
            {
                //Debug.Log("UpLimitplus limitPos : " + upLimit.y);
                forceSpeed = 0.01f;
                hookGravity = Vector3.zero;
            }

            Debug.Log("ForceSpeed :" + forceSpeed);
            // pas les mêmes intensités en x et y ; y hauteur max
            //Vector3 pos = new Vector3(Random.Range(-forceSpeed * 0.5f, forceSpeed * 0.5f), forceSpeed, 0.0f);
            Vector3 pos = new Vector3(Random.Range(-1f, 1f), forceSpeed, 0.0f);
            col.GetComponent<CollectMove>().BreakJoint();

            var rb = col.GetComponent<Rigidbody>();
            rb.useGravity = true;

            if(rb.velocity.magnitude < 30.0f)
            {
                rb.AddForce(pos, ForceMode.VelocityChange);
            }
            col.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
