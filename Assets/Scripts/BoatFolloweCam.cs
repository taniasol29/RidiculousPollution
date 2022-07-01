using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatFolloweCam : MonoBehaviour
{
    public Transform target;
    //public float damping;
    //public float smoothSpeed = 0.3f;
    public Vector3 offset;

    void LateUpdate()
    {
        Quaternion rot = Quaternion.Lerp(transform.rotation, target.transform.rotation, Time.deltaTime);
        //Quaternion rot = Quaternion.Slerp(transform.rotation, target.transform.rotation, Time.deltaTime);
        transform.rotation = rot;

        Vector3 forward = transform.rotation * Vector3.forward;
        Vector3 right = transform.rotation * Vector3.right;
        Vector3 up = transform.rotation * Vector3.up;

        Vector3 targetPos = target.position;
        Vector3 desiredPos = targetPos + forward * offset.z + right * offset.x + up * offset.y;
        Vector3 dampedPos = Vector3.Lerp(transform.position, desiredPos, Time.deltaTime * 10.0f);
        //Vector3 dampedPos = Vector3.Slerp(transform.position, desiredPos, Time.deltaTime * 10.0f);

        transform.position = dampedPos;
    }
}
