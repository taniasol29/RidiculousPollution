using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    [SerializeField] private List<GameObject> fish = new List<GameObject>(); // 5 poissons, index de 0 à 4 
    private float speed;
    private float pointValue;
    private GameObject fishContainer;
    private GameObject go;

    private void Start()
    {
        fishContainer = new GameObject("Fish Container");
        CreateFish();
    }

    public void CreateFish()
    {
        float y = -10.0f;
        float z = -2.0f;
        float offset = 10.0f;

        for (int i = 0; i < 25; i++)
        {
            float x = Random.Range(-17.0f, 17.0f);
            bool zone1 = y <= -10.0f && y > -50.0f;
            bool zone2 = y <= -50.0f && y > -100.0f;
            bool zone3 = y <= -100.0f && y > -150.0f;
            bool zone4 = y <= -150.0f && y > -200.0f;
            bool zone5 = y <= -200.0f && y > -250.0f;
            
            if (zone1)
            {
                Debug.Log("zPos : " + z);
                
                Vector3 location = new Vector3(x, y, z);
                go = Instantiate(fish[0], location, Quaternion.identity, fishContainer.transform) as GameObject;
                Debug.Log("zPos : " + location.z);
                //go.transform.SetParent(fishContainer.transform, false);

                //GameObject go = Instantiate(fish[0]) as GameObject;
                //go.transform.position = new Vector3(x, y, z);
                //go.transform.SetParent(fishContainer.transform, false);
            }
            if(zone2)
            {
                GameObject go = Instantiate(fish[1]) as GameObject;
                go.transform.position = new Vector3(x, y, z);
                go.transform.SetParent(fishContainer.transform, false);
            }
            if(zone3)
            {
                GameObject go = Instantiate(fish[2]) as GameObject;
                go.transform.position = new Vector3(x, y, z);
                go.transform.SetParent(fishContainer.transform, false);
            }
            if(zone4)
            {
                GameObject go = Instantiate(fish[3]) as GameObject;
                go.transform.position = new Vector3(x, y, z);
                go.transform.SetParent(fishContainer.transform, false);
            }
            if(zone5)
            {
                GameObject go = Instantiate(fish[4]) as GameObject;
                go.transform.position = new Vector3(x, y, z);
                go.transform.SetParent(fishContainer.transform, false);
            }

            y -= offset;
        }
    }
}
