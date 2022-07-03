using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyToDestroy : MonoBehaviour
{
    private int hitNb = 0;
    [SerializeField] int hitBeforeDestroy = 3;

    public bool IsReadyToDestroy()
    {
        hitNb++;
        Debug.Log("Nb clicks : " + hitNb);
        return hitNb >= hitBeforeDestroy;
    }
}
