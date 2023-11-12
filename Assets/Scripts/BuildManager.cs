using UnityEngine;

public class BuildManager : MonoBehaviour                                           //Script responsible for building a turret
{
    public static BuildManager instance;

    void Awake()                                                                    //instance of Build Manager is loaded
    {
        if(instance!=null)
        {
            return;
        }
        instance = this;
    }
    public GameObject buildEffect;                                                  //Particle effect for building/upgrading turret
    public GameObject sellEffect;                                                   //Particle effect for selling turret
    private TurretBluePrint turretToBuild;                                          //variable for turret's blueprint

    private Node selectedNode;                                                      //current node selected

    public NodeUI nodeUI;                                                           // UI that hovers over current node selected

    public bool CanBuild { get { return turretToBuild != null; } }                  // returns turret that is being built
    public bool HasMoney { get { return PlayerStats.money>= turretToBuild.cost; } } //returns if player has enough money to build
    
    public void SelectNode(Node node)                                               //Selects node
    {
        if(selectedNode == node)
        {
            DeselectNode();                                                         //Deselects previous node
            return;
        }
        selectedNode = node;                                                        //Selected node is current node
        turretToBuild = null;                                                       //Turret to build is empty
        nodeUI.SetTarget(node);                                                     //node UI hovers over current node
    }
    public void DeselectNode()                                                      //Deselects node
    {
        selectedNode = null;                                                        //node is null
        nodeUI.Hide();                                                              //Node UI disappears
    }
    public void SelectTurretToBuild(TurretBluePrint turret)
    {
        turretToBuild = turret;                                                     //turret to build is selected turret
        DeselectNode();                                                             //Deselects previous node
    }
    public TurretBluePrint GetTurretToBuild()
    {
        return turretToBuild;                                                       //returns turret that is being built
    }
    
}
