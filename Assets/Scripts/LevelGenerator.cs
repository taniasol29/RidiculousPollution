using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    // Containers
    private GameObject levelContainer;

    // Ocean
    [SerializeField] GameObject oceanSurface;
    [SerializeField] GameObject wallGradient;
    [SerializeField] GameObject wallWaves;
    [SerializeField] GameObject oceanFloor;
    [SerializeField] GameObject airCollider;
    // Hook
    [SerializeField] public GameObject hook;
    public Vector3 hookPos;

    private void GenerateLevel()
    {
        CreateLevelContainers();
        //CreateOcean();
        CreateWallGradient();
        CreateWallWaves();
        CreateOceanFloor();
        CreateHook();
        CreateAirCollider();
    }

    private void CreateLevelContainers()
    {
        // Création du level container
        levelContainer = new GameObject("LevelContainer");
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
        float yValue = 0.0f;
        float zValue = -2.0f;

        hook.transform.position = new Vector3(xValue, yValue, zValue);
        Vector3 location = hook.transform.position;
        hook = Instantiate<GameObject>(hook, location, Quaternion.identity);
        hook.transform.SetParent(levelContainer.transform, false);
    }

    private void CreateAirCollider()
    {
        float xValue = 0.0f;
        float yValue = 58.0f;
        float zValue = -2.0f;

        airCollider.transform.position = new Vector3(xValue, yValue, zValue);
        Vector3 location = airCollider.transform.position;
        airCollider = Instantiate<GameObject>(airCollider, location, Quaternion.identity);
        airCollider.transform.SetParent(levelContainer.transform, false);
    }

    void Awake()
    {
        GenerateLevel();
        Camera.main.GetComponent<FollowCamera>().target = hook.transform;
    }
}
