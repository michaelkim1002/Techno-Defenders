using UnityEngine;
using UnityEngine.UI;
public class NodeUI : MonoBehaviour
{
    public GameObject ui;                                                       //Node UI
    public Text upgradeCost;                                                    //text for upgrade cost
    public Text sellAmount;                                                     //text for sell amount
    public Button upgradeButton;                                                //button for upgrade
    private Node target;                                                        //selected node
    public void SetTarget(Node _target)
    {
        target = _target;                                                       //nodeUI is on top of selected node
        transform.position = target.GetBuildPosition();
        if (!target.isUpgraded)                                                 //checks if turret is not upgraded
        {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;        
            upgradeButton.interactable = true;
        }
        else if (target.isUpgraded && !target.isUpgraded2)                      //checks if turret is tier 2
        {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "Complete";
            upgradeButton.interactable = false;
        }
        sellAmount.text = "$" + target.turretBlueprint.GetSellAmount();
        ui.SetActive(true);
    }
    public void Hide()
    {
        ui.SetActive(false);                                                    
    }
    public void Upgrade()
    {
        if (target.isUpgraded && !target.isUpgraded2)                           //checks if turret is tier 2
        {
            target.UpgradeTurret2();                                            //upgrades completely
        }
        else
        {
            target.UpgradeTurret();                                             //upgrades to tier 2
        }

        BuildManager.instance.DeselectNode();                                   //build manager deselects node
    }
    public void Sell()
    {
        target.SellTurret();                                                    //node sells turret
        BuildManager.instance.DeselectNode();                                   //build manager deselects node
    }
}
