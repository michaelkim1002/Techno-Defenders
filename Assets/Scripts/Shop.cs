using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBluePrint standardTurret;                      //blueprint for gatling
    public TurretBluePrint missileLauncher;                     //blueprint for rocket
    public TurretBluePrint laser;                               //blueprint for laser
    public TurretBluePrint moneyGenerator;                      //blueprint for money generator
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectStandardTurret()                          //selects gatling
    {
        buildManager.SelectTurretToBuild(standardTurret);
    }
    public void SelectMissileLauncher()                         //selects gatling
    {
        buildManager.SelectTurretToBuild(missileLauncher);
    }
    public void SelectLaser()                                   //selects gatling
    {
        buildManager.SelectTurretToBuild(laser);
    }
    public void SelectMoneyGenerator()                          //selects money generator
    {
        buildManager.SelectTurretToBuild(moneyGenerator);
    }
}
