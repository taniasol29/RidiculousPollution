using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectMove : MonoBehaviour
{
    public float amp;
    public float freq;
    Vector3 initPos;
    Vector3 hookPos;
    public Vector3 currentPos;
    private bool hookInSight = false;
    HingeJoint hj;

    private void Start()
    {
        initPos = transform.position;
    }

    void Update()
    {
        UpdateCollectiblePos();
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player" && !hookInSight)
        {
            hj = gameObject.AddComponent<HingeJoint>();
            GetComponent<BoxCollider>().enabled = false;
            hj.autoConfigureConnectedAnchor = false;
            hj.anchor = Vector3.zero;
            hj.connectedAnchor = new Vector3(0.0f, -2.5f, 0.0f); //Vector3.zero;
            
            hj.connectedBody = other.gameObject.GetComponent<Rigidbody>();
            hj.axis = new Vector3(0.0f, 0.0f, 1.0f);
            hookInSight = true;
        }
    }

    private void UpdateCollectiblePos()
    {
        if (!hookInSight)
        {
            transform.position = new Vector3(Mathf.Sin(Time.time * freq) * amp + initPos.x, initPos.y, initPos.z);
        }
    }

    public void BreakJoint()
    {
        Destroy(GetComponent<HingeJoint>());
        ///hj.enabled = false;
    }
}
