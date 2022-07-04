using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UImanager : MonoBehaviour
{
    private Inventaire monInventaire;
    private GameObject GOHookLvl1;//objet où est la liste de "collectibles"
    private GameObject GOhookLvl2;//objet où est la liste de "collectibles"
    List<GameObject> collectList;

    private void Awake()
    {
        GOHookLvl1 = GameObject.Find("Hook");
        GOhookLvl2 = GameObject.Find("NightHook");
        collectList = GOHookLvl1.GetComponent<PlayerMovements>().collectibles;
    }

    void Start()
    {
        monInventaire = new Inventaire();

    }

    void Update()
    {
        inventoryUpdate();
    }

    void inventoryUpdate()
    {
        //if()
        //{
        //
        //}
    }
}
