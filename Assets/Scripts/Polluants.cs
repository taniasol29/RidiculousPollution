using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Polluants : MonoBehaviour
{
    [SerializeField] private List<GameObject> polluants = new List<GameObject>(); // 5 poissons, index de 0 à 4 
    private float speed;
    private float pointValue;
    private GameObject polluantContainer;

    private GameObject objectToDestroy;

    private void Start()
    {
        polluantContainer = new GameObject("Polluant Container");
        CreatePolluants();
    }

    public void CreatePolluants()
    {
        float y = -6.0f;
        float z = -3.0f;
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
                GameObject go = Instantiate(polluants[0]) as GameObject;
                go.transform.position = new Vector3(x, y, z);
                go.transform.SetParent(polluantContainer.transform, false);
            }
            if (zone2)
            {
                GameObject go = Instantiate(polluants[1]) as GameObject;
                go.transform.position = new Vector3(x, y, z);
                go.transform.SetParent(polluantContainer.transform, false);
            }
            if (zone3)
            {
                GameObject go = Instantiate(polluants[2]) as GameObject;
                go.transform.position = new Vector3(x, y, z);
                go.transform.SetParent(polluantContainer.transform, false);
            }
            if (zone4)
            {
                GameObject go = Instantiate(polluants[3]) as GameObject;
                go.transform.position = new Vector3(x, y, z);
                go.transform.SetParent(polluantContainer.transform, false);
            }
            if (zone5)
            {
                GameObject go = Instantiate(polluants[4]) as GameObject;
                go.transform.position = new Vector3(x, y, z);
                go.transform.SetParent(polluantContainer.transform, false);
            }

            y -= offset;
        }
    }
}
