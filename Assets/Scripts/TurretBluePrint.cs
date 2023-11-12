using UnityEngine;
[System.Serializable]
public class TurretBluePrint 
{
    public GameObject prefab;               //turret itself
    public int cost;                        //cost of turret

    public GameObject upgradedPrefab;       //upgraded turret
    public int upgradeCost;                 //upgrade cost
    public GameObject upgradedPrefab2;      //completely upgraded turret
   
    public int GetSellAmount()              //sells for half the cost of original turret cost
    {
        return cost/2;
    }
}
