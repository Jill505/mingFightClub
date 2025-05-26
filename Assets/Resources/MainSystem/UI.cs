using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using static SaveFile;

public class UI : MonoBehaviour
{
    [Header("�ҰʻP�a��")]
    [SerializeField] Button StartButton;
    [SerializeField] GameObject StartMenu;
    [SerializeField] GameObject TainanMap;
    [SerializeField] AllGameManager allGameManager;

    [Header("�U�ϰ�a�ϭ��O")]
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

    [Header("�U�ϰ��������s")]
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

    private Dictionary<string, Action> tagActions;//�r���Ƶ��c

    private void Start()
    {
        tagActions = new Dictionary<string, Action>//�ھڤ��PTag�A�Q�I����|�����P���ʧ@
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
            var menu = menus[i]; // �� local �ܼ��קK���]���D
            exits[i].onClick.AddListener(() =>
            {
                menu.SetActive(false);
                TainanMap.SetActive(true);
            });
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))//�ƹ�����
        {
            //�N�ƹ��b�ù�����m�ഫ���C�������@�ɮy��
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //�P�_�ƹ��I����m�O�_��Collider2D�A�ç⵲�G�s��hit
            Collider2D hit = Physics2D.OverlapPoint(mousePos);

            //�ƹ��I���a�観Ĳ�o���A�B�btagActions����������Tag�A�h�����Tag���S�w�ʧ@
            if (hit != null && tagActions.TryGetValue(hit.tag, out Action action))
            {
                action.Invoke();
            }
        }
    }

    public void HideStartMenu()
    {
        StartMenu.SetActive(false); //���� StartMenu
        TainanMap.SetActive(true); //���� StartMenu
    }
}
