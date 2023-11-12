using UnityEngine;
using UnityEngine.EventSystems;
public class Node : MonoBehaviour
{
    public Color hoverColor;                                                                                                        //color of node if hovered
    public Color notEnoughMoneyColor;                                                                                               //color of node if hovered and not enough money
    public Vector3 positionOffset;                                                                                                  //possition of hovered node
    [HideInInspector]
    public GameObject turret;                                                                                                       //turret node has
    [HideInInspector]
    public TurretBluePrint turretBlueprint;                                                                                         //blueprint of turret on node
    [HideInInspector]
    public bool isUpgraded = false;                                                                                                 //checks if turret is upgraded to tier 2
    [HideInInspector]
    public bool isUpgraded2 = false;                                                                                                //checks if turret is upgraded completely

    private Renderer rend;                                                                                                          //gets renderer
    private Color startColor;                                                                                                       //color when node is not hovered
    BuildManager buildManager;                                                                                                      //gets buildManager
    void Start()
    {
        buildManager = BuildManager.instance;                                                                                       //instance of buildManager object
        rend = GetComponent<Renderer>();                                                                                            //gets component of renderer
        startColor = rend.material.color;                                                                                           //start color is set
    }
    public Vector3 GetBuildPosition()                                                                                               //gets build position of node that is being built on
    {
        return transform.position + positionOffset;
    }
    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())                                                                        
        {
            return;
        }
        if (turret != null)                                                                                                         //if there is a turret, then node UI pops up
        {
            buildManager.SelectNode(this);      
            return;
        }
        if (!buildManager.CanBuild)                                                                                                 //checks if turret can be built
        {
            return;
        }
        BuildTurret(buildManager.GetTurretToBuild());                                                                               //builds a turret on the selected node
    }
    void BuildTurret(TurretBluePrint blueprint)
    {
        if (PlayerStats.money < blueprint.cost)                                                                                     //if player does not have enough money
        {
            return;
        }
        PlayerStats.money -= blueprint.cost;                                                                                        //reduces player money for bought turret
        

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);    
        turret = _turret;                                                                                                           //sets turret to selected turret

        turretBlueprint = blueprint;                                                                                                //gets blueprint of turret

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);             //particle effect for building
        Destroy(effect, 5f);
    }
    public void UpgradeTurret()                                                                                             
    {
        if (PlayerStats.money < turretBlueprint.upgradeCost)
        {
            return;
        }
        PlayerStats.money -= turretBlueprint.upgradeCost;                                                                           //money reduces after upgrading
       

        Destroy(turret);                                                                                                            //previous turret disappears

        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);      //replaces with upgraded turret
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        isUpgraded = true;                                                                                                          //turret is upgraded
    }
    public void UpgradeTurret2()                                                                                                    //same function as UpgradeTurret(), but for complete upgrade
    {
        if (PlayerStats.money < turretBlueprint.upgradeCost)
        {
            return;
        }
        PlayerStats.money -= turretBlueprint.upgradeCost;
        

        Destroy(turret);

        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab2, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        isUpgraded2 = true;
        
    }
    public void SellTurret()
    {
        PlayerStats.money += turretBlueprint.GetSellAmount();                                                                       //player gets money for selling

        GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);              //particle effect for selling
        Destroy(effect, 5f);

        Destroy(turret);                                                                                                            //turret disappears
        turretBlueprint = null;                                                                                                     //there is no turret, so no blueprint
    }
    void OnMouseEnter()                                                                                                             //when player is hovering over node
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!buildManager.CanBuild)                                                                                                 //checks if player can't build
        {
            return;
        }
        if(buildManager.HasMoney)                                                                                                   //if player has money. node is hover color
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;                                                                              //otherwise, node is not enough money color
        }
        
    }
    void OnMouseExit()                                                                                                              //color of renderer is default
    {
        rend.material.color = startColor;
    }
}
