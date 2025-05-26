using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using static SaveFile;

public class UI : MonoBehaviour
{
    [Header("啟動與地圖")]
    [SerializeField] Button StartButton;
    [SerializeField] GameObject StartMenu;
    [SerializeField] GameObject TainanMap;
    [SerializeField] AllGameManager allGameManager;

    [Header("各區域地圖面板")]
    [SerializeField] GameObject XinhuaMenu;
    [SerializeField] GameObject GuirenMenu;
    [SerializeField] GameObject YongkangMenu;
    [SerializeField] GameObject SoutheasternMenu;
    [SerializeField] GameObject TainanMenu;
    [SerializeField] GameObject AnnanMenu;
    [SerializeField] GameObject JialiMenu;
    [SerializeField] GameObject MadouMenu;
    [SerializeField] GameObject YanshuiMenu;
    [SerializeField] GameObject BaiheMenu;
    [SerializeField] GameObject YujingMenu;

    [Header("各區域關閉按鈕")]
    [SerializeField] Button XinhuaExit;
    [SerializeField] Button GuirenExit;
    [SerializeField] Button YongkangExit;
    [SerializeField] Button SoutheasternExit;
    [SerializeField] Button TainanExit;
    [SerializeField] Button AnnanExit;
    [SerializeField] Button JialiExit;
    [SerializeField] Button MadouExit;
    [SerializeField] Button YanshuiExit;
    [SerializeField] Button BaiheExit;
    [SerializeField] Button YujingExit;

    private Dictionary<string, Action> tagActions;//字典資料結構

    private void Start()
    {
        tagActions = new Dictionary<string, Action>//根據不同Tag，被點擊後會有不同的動作
        {
            { "LandXinhua",      () => { TainanMap.SetActive(false); XinhuaMenu.SetActive(true); } },
            { "LandGuiren",      () => { TainanMap.SetActive(false); GuirenMenu.SetActive(true); } },
            { "LandYongkang",    () => { TainanMap.SetActive(false); YongkangMenu.SetActive(true); } },
            { "LandSoutheastern",() => { TainanMap.SetActive(false); SoutheasternMenu.SetActive(true); } },
            { "LandTainan",      () => { TainanMap.SetActive(false); TainanMenu.SetActive(true); } },
            { "LandAnnan",       () => { TainanMap.SetActive(false); AnnanMenu.SetActive(true); } },
            { "LandJiali",       () => { TainanMap.SetActive(false); JialiMenu.SetActive(true); } },
            { "LandMadou",       () => { TainanMap.SetActive(false); MadouMenu.SetActive(true); } },
            { "LandYanshui",     () => { TainanMap.SetActive(false); YanshuiMenu.SetActive(true); } },
            { "LandBaihe",       () => { TainanMap.SetActive(false); BaiheMenu.SetActive(true); } },
            { "LandYujing",      () => { TainanMap.SetActive(false); YujingMenu.SetActive(true); } }
        };

        Button[] exits =
        {
            XinhuaExit, GuirenExit, YongkangExit, SoutheasternExit,
            TainanExit, AnnanExit, JialiExit, MadouExit,
            YanshuiExit, BaiheExit, YujingExit
        };
        GameObject[] menus =
        {
            XinhuaMenu, GuirenMenu, YongkangMenu, SoutheasternMenu,
            TainanMenu, AnnanMenu, JialiMenu, MadouMenu,
            YanshuiMenu, BaiheMenu, YujingMenu
        };

        for (int i = 0; i < exits.Length; i++)
        {
            var menu = menus[i]; // 用 local 變數避免閉包問題
            exits[i].onClick.AddListener(() =>
            {
                menu.SetActive(false);
                TainanMap.SetActive(true);
            });
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))//滑鼠左鍵
        {
            //將滑鼠在螢幕的位置轉換成遊戲內的世界座標
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //判斷滑鼠點擊位置是否有Collider2D，並把結果存到hit
            Collider2D hit = Physics2D.OverlapPoint(mousePos);

            //滑鼠點擊地方有觸發器，且在tagActions中有對應的Tag，則執行該Tag的特定動作
            if (hit != null && tagActions.TryGetValue(hit.tag, out Action action))
            {
                action.Invoke();
            }
        }
    }

    public void HideStartMenu()
    {
        StartMenu.SetActive(false); //隱藏 StartMenu
        TainanMap.SetActive(true); //隱藏 StartMenu
    }
}
