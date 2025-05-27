using NUnit.Framework.Internal.Commands;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LandInformation : MonoBehaviour
{
    public AllGameManager allGameManager;

    public string landName = "Åw³s¿¤";
    public Sprite landMap;

    public string obj_landMoneyBuildingText;
    public string landMoneyBuildingText;
    public Sprite landMoneyBuilding;
    public int landMoneyBuildingPrice = 100;
    public bool unlockAlreadyLandMoneyBuilding = false;

    public string obj_landPopulationBuildingText;
    public string landPopulationBuildingText;
    public Sprite landPopulationBuilding;
    public int landPopulationBuildingPrice = 200;
    public bool unlockAlreadyLandPopulationBuilding = false;

    public string obj_landCultureBuildingText;
    public string landCultureBuildingText;
    public Sprite landCultureBuilding;
    public int landCultureBuildingPrice = 150;
    public bool unlockAlreadyLandCultureBuilding = false;

    public void Awake()
    {
        allGameManager = GameObject.Find("AllGameManager").GetComponent<AllGameManager>();
    }

    public void showContext()
    {
        GameObject.Find("AllGameManager").GetComponent<UI>().LoadLandInformationContext(this);
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
