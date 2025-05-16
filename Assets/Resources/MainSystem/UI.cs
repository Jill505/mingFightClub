using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UI : MonoBehaviour
{
    [SerializeField] Button StartButton;
    [SerializeField] GameObject StartMenu;
    [SerializeField] GameObject TainanMap;
    private Dictionary<string, Action> tagActions;//�r���Ƶ��c

    private void Start()
    {
        tagActions = new Dictionary<string, Action>//�ھڤ��PTag�A�Q�I����|�����P���ʧ@
        {
            { "LandXinhua",      () => Debug.Log("Xinhua�I") },
            { "LandGuiren",      () => Debug.Log("Guiren�I") },
            { "LandYongkang",    () => Debug.Log("Yongkang�I") },
            { "LandSoutheastern",() => Debug.Log("Southeastern�I") },
            { "LandTainan",      () => Debug.Log("Tainan�I") },
            { "LandAnnan",       () => Debug.Log("Annan�I") },
            { "LandJiali",       () => Debug.Log("Jiali�I") },
            { "LandMadou",       () => Debug.Log("Madou�I") },
            { "LandYanshui",     () => Debug.Log("Yanshui�I") },
            { "LandBaihe",       () => Debug.Log("Baihe�I") },
            { "LandYujing",      () => Debug.Log("Yujing�I") }
        };
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
