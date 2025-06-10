using NUnit.Framework.Internal.Commands;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class LandInformation : MonoBehaviour
{
    [Header("�򥻫ŧi")]
    public AllGameManager allGameManager;

    [Header("�g�a������")]
    public bool attackAble = false;
    public bool unlock = false;
    public Gang belongingGang;

    [Header("���[�g�a")]
    public string[] attLand = new string[10];

    [Header("�g�a��T")]
    public string landName = "�w�s��";
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

    [Header("Flag")]
    public GameObject Flag;


    public Land returnLand()
    {
        Land swapLand = new Land();
        swapLand.unlock = unlock;
        swapLand.buildingUnlockA = unlockAlreadyLandPopulationBuilding;
        swapLand.buildingUnlockB = unlockAlreadyLandCultureBuilding;
        swapLand.buildingUnlockC = unlockAlreadyLandMoneyBuilding;

        //TODO: Fix Gang Having Problem

        return swapLand;
    }


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
