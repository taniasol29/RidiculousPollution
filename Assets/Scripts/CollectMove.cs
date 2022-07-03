using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectMove : MonoBehaviour
{
    // Light movements sin
    public float amp;
    public float freq;
    Vector3 initPos;

    public Vector3 currentPos;
    private bool hookInSight = false;
    HingeJoint hj;
    bool attached = false;

    // Audio
    [SerializeField] AudioClip fish;
    [SerializeField] AudioClip polluant;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
            attached = true;

            if(gameObject.tag == "Polluant")
            {
                audioSource.pitch = Random.Range(0.5f, 1.0f);
                audioSource.Stop();
                audioSource.PlayOneShot(polluant);
            }
            else if(gameObject.tag == "Fish")
            {
                audioSource.pitch = Random.Range(0.5f, 1.0f);
                audioSource.Stop();
                audioSource.PlayOneShot(fish);
            }
            
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
        //hj.enabled = false;
    }
}
