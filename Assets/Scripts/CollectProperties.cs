using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectProperties : MonoBehaviour
{
    public int collectValue;

    void Start()
    {
        DetermineValue();
        Debug.Log(collectValue);
        Debug.Log("position X,Y: "+ transform.position);
        Debug.Log(transform.tag);
    }

    void DetermineValue()
    {
        float zone1max = -10.0f;
        float zone1min = -50.0f;
        float zone2max = -50.0f;
        float zone2min = -100.0f;
        float zone3max = -100.0f;
        float zone3min = -150.0f;
        float zone4max = -150.0f;
        float zone4min = -200.0f;
        float zone5max = -200.0f;
        float zone5min = -250.0f;

        if(transform.position.y <= zone1max && transform.position.y > zone1min && transform.tag == "Polluant")//zone 1
        {
            collectValue = 10;
        }
        else if (transform.position.y <= zone1max && transform.position.y > zone1min && transform.tag == "Fish")
        {
            collectValue = -10;
        }
        else if (transform.position.y <= zone2max && transform.position.y > zone2min && transform.tag == "Polluant")//zone 2
        {
            collectValue = 15;
        }
        else if (transform.position.y <= zone2max && transform.position.y > zone2min && transform.tag == "Fish")
        {
            collectValue = -15;
        }
        else if (transform.position.y <= zone3max && transform.position.y > zone3min && transform.tag == "Polluant")//zone 3
        {
            collectValue = 20;
        }
        else if (transform.position.y <= zone3max && transform.position.y > zone3min && transform.tag == "Fish")
        {
            collectValue = -20;
        }
        else if (transform.position.y <= zone4max && transform.position.y > zone4min && transform.tag == "Polluant")//zone 4
        {
            collectValue = 25;
        }
        else if (transform.position.y <= zone4max && transform.position.y > zone4min && transform.tag == "Fish")
        {
            collectValue = -25;
        }
        else if (transform.position.y <= zone5max && transform.position.y > zone5min && transform.tag == "Polluant")//zone 5
        {
            collectValue = 30;
        }
        else if (transform.position.y <= zone5max && transform.position.y > zone5min && transform.tag == "Fish")
        {
            collectValue = -30;
        }
    }
}
