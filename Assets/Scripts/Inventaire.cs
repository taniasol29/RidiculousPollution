using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Inventaire
{
    [UnityEngine.SerializeField]
    public int totalCoins;
    [UnityEngine.SerializeField]
    public int collectedCoins;

    public int ResetTotalCoins()
    {
        return totalCoins = 0;
    }

    public int ResetCurrentCoins()
    {
        return collectedCoins = 0;
    }
}
