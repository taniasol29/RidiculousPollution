using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{
    [Header("IN-GAME")]
    [SerializeField] Image depollutionFill;
    [SerializeField] TextMeshProUGUI depthDisplay;  
    [SerializeField] TextMeshProUGUI coinsDisplay;  
    [SerializeField] Image pauseIcon;  
    [SerializeField] Image playIcon;

    //Scenes
    private bool scene1 = false;
    private bool scene2 = false;

    // inventaire
    private Inventaire monInventaire;
    private GameObject GOHookLvl1;//objet où est la liste de "collectibles"
    private GameObject GOHookLvl2;//objet où est la liste de "collectibles"
    List<GameObject> collectList;
    List<GameObject> polluantList;
    List<GameObject> fishList;
    private bool collectionStart;

    // GO values
    private int fishKilled;
    private int polluantNeutralized;
    private int currentValue; //variable de la valeur du current clone
    private int totalCoinsAccumulated;
    //private int polluantTotalValue;
    //private int fishTotalValue;
    //private int polluantSurplusValue;
    //private int fishSurplusValue;
    //private int polluantRealValue;
    //private int fishRealValue;
    //private bool currentStatus;
    //private float hookPosY;

    //Depollution
    private int depollution;
    private int maxPolluant;



    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            scene1 = true;
            GOHookLvl1 = GameObject.Find("LevelContainer/Hook(Clone)");

        }
        if (SceneManager.GetActiveScene().name == "Level2")
        {
            scene2 = true;
            GOHookLvl2 = GameObject.Find("LevelContainer/NightHook(Clone)");

        }     
    }

    void Start()
    {    
        monInventaire = new Inventaire();
        monInventaire.ResetCurrentCoins();  //TROUVER UNE FAÇON POUR RESET APRÈS UN NIVEAU
        monInventaire.ResetTotalCoins();
        maxPolluant = GameObject.Find("LevelManager").GetComponent<Polluants>().totalPolluants;

    }

    void Update()
    {
        //inventoryUpdate();
        InGameDisplay();
    }

    void inventoryUpdate()
    {
        //if(scene1)
        //{
        //    collectionStart = GOHookLvl1.GetComponent<PlayerMovements>().isCollected;
        //}
        //if(scene2)
        //{
        //    collectionStart = GOHookLvl2.GetComponent<PlayerMovements>().isCollected;
        //}
        //
        //if (collectionStart)
        //{
        //    if (scene1)
        //    {
        //        collectList = GOHookLvl1.GetComponent<PlayerMovements>().collectibles;
        //        polluantList = GOHookLvl1.GetComponent<PlayerMovements>().polluantsOnHook;
        //        fishList = GOHookLvl1.GetComponent<PlayerMovements>().fishOnHook;
        //    }
        //    if (scene2)
        //    {
        //        collectList = GOHookLvl2.GetComponent<PlayerMovements>().collectibles;
        //        polluantList = GOHookLvl2.GetComponent<PlayerMovements>().polluantsOnHook;
        //        fishList = GOHookLvl2.GetComponent<PlayerMovements>().fishOnHook;
        //    }
        //}



        //calcul du total de coins
        //if (collectList != null)
        //{
        //    
        //     foreach (GameObject go in polluantList)
        //     {
        //         currentValue = go.GetComponent<CollectProperties>().collectValue;
        //         Debug.Log("currentValue : " + currentValue);
        //         polluantTotalValue += currentValue;
        //         Debug.Log("polluantTotalValue : " + polluantTotalValue);
        //         if (go == null)
        //         {
        //             polluantSurplusValue += currentValue;
        //         }
        //     }
        //     foreach (GameObject go in fishList)
        //     {
        //         currentValue = go.GetComponent<CollectProperties>().collectValue;
        //         fishTotalValue += currentValue;
        //         if (go == null)
        //         {
        //             fishSurplusValue += currentValue;
        //         }
        //     }
        //}
    }

    void InGameDisplay()
    {
        //Depth
        DisplayDepth();
        //totalCoins
        TotalCoinsDisplay();
        //pauseIcon

        //depollutionSlider
        DisplayProgressBar();
    }

    void CalculateTotalCoins()
    {
        fishKilled = Camera.main.GetComponent<DestroyCollectible>().totalFishValueOnHook;
        polluantNeutralized = Camera.main.GetComponent<DestroyCollectible>().totalPolluantValueOnHook;
        //Debug.Log("fishKilled : " + fishKilled);
        //Debug.Log("polluantNeutralized : " + polluantNeutralized);
        totalCoinsAccumulated = polluantNeutralized + fishKilled;
        monInventaire.totalCoins = totalCoinsAccumulated;
    }

    void TotalCoinsDisplay()
    {
        CalculateTotalCoins();
        coinsDisplay.text = monInventaire.totalCoins + " $";
        coinsDisplay.ForceMeshUpdate(true);
    }

    void DisplayDepth()
    {
        if(scene1)
        {
            depthDisplay.text = Mathf.Round(GOHookLvl1.transform.position.y).ToString() + " m";
        }
        if(scene2)
        {
            depthDisplay.text = Mathf.Round(GOHookLvl2.transform.position.y).ToString() + " m";
        }
        depthDisplay.ForceMeshUpdate(true);
    }

    void DisplayProgressBar()
    {
        //depollutionFill
        //maxPolluant
        if (scene1)
        {
            depollution = GOHookLvl1.GetComponent<PlayerMovements>().polluantToGo;
        }
        if (scene2)
        {
            depollution = GOHookLvl2.GetComponent<PlayerMovements>().polluantToGo;
        }
        Debug.Log("max polluants : " + maxPolluant);
        Debug.Log("depollution : " + depollution);
        depollutionFill.fillAmount = depollution/maxPolluant * Time.deltaTime;
    }
}
