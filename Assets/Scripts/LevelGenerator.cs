using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    // Containers
    private GameObject levelContainer;
    private GameObject collectiblesContainer;

    // Ocean
    [SerializeField] GameObject oceanSurface;
    [SerializeField] GameObject wallGradient;
    [SerializeField] GameObject wallWaves;
    [SerializeField] GameObject oceanFloor;
    // Hook
    [SerializeField] GameObject hook;
    // Collectibles up
    [SerializeField] List<GameObject> collectiblesUp = new List<GameObject>();
    // Collectibles middle
    [SerializeField] List<GameObject> collectiblesMiddle = new List<GameObject>();
    // Collectibles down
    [SerializeField] List<GameObject> collectiblesDown = new List<GameObject>();

    private void GenerateLevel()
    {
        CreateLevelContainers();
        CreateOcean();
        CreateWallGradient();
        CreateWallWaves();
        CreateOceanFloor();
        CreateHook();
        CreateCollectibles(collectiblesUp, 20.0f, -10.0f, -3.0f, 10.0f, 0.0f);
        CreateCollectibles(collectiblesUp, -20.0f, -20.0f, -3.0f, 10.0f, -180.0f);
        CreateCollectibles(collectiblesMiddle, 20.0f, -100.0f, -3.0f, 10.0f, 0.0f);
        CreateCollectibles(collectiblesMiddle, -20.0f, -110.0f, -3.0f, 10.0f, -180.0f);
        CreateCollectibles(collectiblesDown, 20.0f, -180.0f, -3.0f, 10.0f, 0.0f);
        CreateCollectibles(collectiblesDown, -20.0f, -190.0f, -3.0f, 10.0f, -180.0f);
    }

    private void CreateLevelContainers()
    {
        // Création du level container
        levelContainer = new GameObject("LevelContainer");
        // Création du collectibles container
        collectiblesContainer = new GameObject("Collectibles");
        // Parenter le collectibles container
        collectiblesContainer.transform.SetParent(levelContainer.transform, false);
    }

    public void CreateOcean()
    {
        Vector3 location = oceanSurface.transform.position;
        oceanSurface = Instantiate<GameObject>(oceanSurface, location, Quaternion.identity);
        oceanSurface.transform.SetParent(levelContainer.transform, false);
    }
    
    public void CreateWallGradient()
    {
        float xValue = 0.0f;
        float yValue = -126.8f;
        float zValue = 0.0f;

        wallGradient.transform.position = new Vector3(xValue, yValue, zValue);
        Vector3 location = wallGradient.transform.position;
        wallGradient = Instantiate<GameObject>(wallGradient, location, Quaternion.identity);
        wallGradient.transform.SetParent(levelContainer.transform, false);
    }
    
    public void CreateWallWaves()
    {
        float xValue = 0.0f;
        float yValue = -126.8f;
        float zValue = -1.0f;

        wallWaves.transform.position = new Vector3(xValue, yValue, zValue);
        Vector3 location = wallWaves.transform.position;
        wallWaves = Instantiate<GameObject>(wallWaves, location, Quaternion.identity);
        wallWaves.transform.SetParent(levelContainer.transform, false);
    }
    
    public void CreateOceanFloor()
    {
        float xValue = 0.0f;
        float yValue = -252.0f;
        float zValue = 0.0f;

        oceanFloor.transform.position = new Vector3(xValue, yValue, zValue);
        Vector3 location = oceanFloor.transform.position;
        oceanFloor = Instantiate<GameObject>(oceanFloor, location, Quaternion.identity);
        oceanFloor.transform.SetParent(levelContainer.transform, false);
    }
    
    public void CreateHook()
    {
        float xValue = 0.0f;
        float yValue = -4.0f;
        float zValue = -2.0f;

        hook.transform.position = new Vector3(xValue, yValue, zValue);
        Vector3 location = hook.transform.position;
        hook = Instantiate<GameObject>(hook, location, Quaternion.identity);
        hook.transform.SetParent(levelContainer.transform, false);
    }

    public void CreateCollectibles(List<GameObject> list, float x, float y, float z, float offset, float rot)
    {
        for (int i = 0; i < 8; i++)
        {
            int index = Random.Range(0, list.Count);
            GameObject go = Instantiate(list[index]) as GameObject;
            go.transform.position = new Vector3(x, y, z);
            go.transform.Rotate(0.0f, rot, 0.0f, Space.Self);
            go.transform.SetParent(collectiblesContainer.transform, false);
            y -= offset;
        }
    }


    void Start()
    {
        GenerateLevel();
        Camera.main.GetComponent<FollowCamera>().target = hook.transform;
    }
}
