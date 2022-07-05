using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UImanager : MonoBehaviour
{
    // menus
    [SerializeField] GameObject menuInGame;
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject pauseScreen;
    [SerializeField] GameObject chooseLvl;
    [SerializeField] GameObject bankMenu;

    // inventaire
    private Inventaire monInventaire;
    private GameObject GOHookLvl1;//objet où est la liste de "collectibles"
    private GameObject GOhookLvl2;//objet où est la liste de "collectibles"
    List<GameObject> collectList;

    // values
    private int currentValue; //variable de la valeur du current clone
    private bool currentStatus;
    private float hookPosY;

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
        foreach (GameObject go in collectList)
        {
            currentStatus = gameObject.GetComponent<DestroyCollectible>().isDestroyed;
            if (currentStatus)
            {
                currentValue = gameObject.GetComponent<DestroyCollectible>().goValue;
                monInventaire.collectedCoins += currentValue;
                monInventaire.totalCoins += currentValue;
            }
        }
    }

    void InGameDisplay()
    {
        //Depth

        //totalCoins
        //pauseIcon
        //depollutionSlider
    }
}
