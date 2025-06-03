using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using static SaveFile;
using System.Security.Cryptography.X509Certificates;
using TMPro;

public class UI : MonoBehaviour
{
    [Header("啟動與地圖")]
    [SerializeField] Button StartButton;
    [SerializeField] GameObject StartMenu;
    [SerializeField] GameObject TainanMap;
    [SerializeField] GameObject PlayerUIManager;
    [SerializeField] AllGameManager allGameManager;

    [Header("區域面板")]
    public GameObject LandShowcase;

    [Header("地區資料顯示")]
    public Image showLandMapImage;
    public Text landName;

    public Image landMoneyBuildingImage;
    public Image landPopulationBuildingImage;
    public Image landCultureBuildingImage;

    public Text landMoneyBuildingText;
    public Text landPopulationBuildingText;
    public Text landCultureBuildingText;

    public Text obj_landMoneyBuildingText;
    public Text obj_landPopulationBuildingText;
    public Text obj_landCultureBuildingText;

    public Button moneyBuyButton;
    public Button populationBuyButton;
    public Button cultureBuyButton;

    [Header("傳入值")]
    public LandInformation loadingLandInformation;

    private void Awake()
    {
        if (allGameManager == null)
        {
            allGameManager = GameObject.Find("AllGameManager").GetComponent<AllGameManager>();
        }
    }

    private void Start()
    {
        buttonStateCheck();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))//滑鼠左鍵
        {
            //將滑鼠在螢幕的位置轉換成遊戲內的世界座標
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //判斷滑鼠點擊位置是否有Collider2D，並把結果存到hit
            Collider2D hit = Physics2D.OverlapPoint(mousePos);

            if (hit != null && hit.gameObject.TryGetComponent<LandInformation>(out LandInformation info))
            {
                LandShowcase.SetActive(true);
                TainanMap.SetActive(false);
                info.showContext();

                allGameManager.inGameManager.JudgeLandAttackable();
            }
            else
            {
                Debug.Log("不是觸發區");
            }
        }
    }

    public void LoadLandInformationContext(LandInformation info)
    {
        showLandMapImage.sprite = info.landMap;
        landName.text = info.landName;

        landMoneyBuildingImage.sprite = info.landMoneyBuilding;
        landPopulationBuildingImage.sprite = info.landPopulationBuilding;
        landCultureBuildingImage.sprite = info.landCultureBuilding;

        landMoneyBuildingText.text = info.landMoneyBuildingText;
        landPopulationBuildingText.text = info.landPopulationBuildingText;
        landCultureBuildingText.text = info.landCultureBuildingText;

        obj_landMoneyBuildingText.text = info.obj_landMoneyBuildingText;
        obj_landPopulationBuildingText.text = info.obj_landPopulationBuildingText;
        obj_landCultureBuildingText.text = info.obj_landCultureBuildingText;
    }


    public void buyLandBuilding(int sort) // 0 = money building, 1 = population building, 2 = culture building.
    {
        if (sort == 0)
        {
            if (allGameManager.saveFile.playerData.money >= loadingLandInformation.landMoneyBuildingPrice)
            {
                //allow player buy the building
                allGameManager.saveFile.playerData.money -= loadingLandInformation.landMoneyBuildingPrice;
                loadingLandInformation.unlockAlreadyLandMoneyBuilding = true;
            }
        }

        if (sort == 1)
        {
            if (allGameManager.saveFile.playerData.money >= loadingLandInformation.landPopulationBuildingPrice)
            {
                allGameManager.saveFile.playerData.money -= loadingLandInformation.landPopulationBuildingPrice;
                loadingLandInformation.unlockAlreadyLandPopulationBuilding = true;
            }
        }

        if (sort == 2)
        {
            if (allGameManager.saveFile.playerData.money >= loadingLandInformation.landCultureBuildingPrice)
            {
                allGameManager.saveFile.playerData.money -= loadingLandInformation.landCultureBuildingPrice;
                loadingLandInformation.unlockAlreadyLandCultureBuilding = true;
            }
        }
        buttonStateCheck();
    }

    public void buttonStateCheck()
    {
        if (loadingLandInformation == null)
        {
            return;
        }

        if (loadingLandInformation.unlockAlreadyLandMoneyBuilding == true)
        {
            moneyBuyButton.interactable = false;
        }
        else
        {
            moneyBuyButton.interactable = true;
        }

        if (loadingLandInformation.unlockAlreadyLandPopulationBuilding == true)
        {
            populationBuyButton.interactable = false;
        }
        else
        {
            populationBuyButton.interactable = true;
        }

        if (loadingLandInformation.unlockAlreadyLandCultureBuilding == true)
        {
            cultureBuyButton.interactable = false;
        }
        else
        {
            cultureBuyButton.interactable = true;
        }
    }

    public void closeMenu()
    {
        LandShowcase.SetActive(false);
        TainanMap.SetActive(true);
    }


    public void HideStartMenu()
    {
        StartMenu.SetActive(false); //隱藏 StartMenu
        TainanMap.SetActive(true); //隱藏 StartMenu
        PlayerUIManager.SetActive(true);
    }
}
