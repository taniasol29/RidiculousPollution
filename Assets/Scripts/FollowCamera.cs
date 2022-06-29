using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    [SerializeField] private Vector3 offset;

    private void Update()
    {
        Vector3 position = transform.position;
        position.y = target.position.y;
        position.z = target.position.z * offset.z;
        transform.position = position;
    }
}
