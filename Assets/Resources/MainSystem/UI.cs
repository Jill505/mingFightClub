using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UI : MonoBehaviour
{
    [SerializeField] Button StartButton;
    [SerializeField] GameObject StartMenu;
    [SerializeField] GameObject TainanMap;
    private Dictionary<string, Action> tagActions;//字典資料結構

    private void Start()
    {
        tagActions = new Dictionary<string, Action>//根據不同Tag，被點擊後會有不同的動作
        {
            { "LandXinhua",      () => Debug.Log("Xinhua！") },
            { "LandGuiren",      () => Debug.Log("Guiren！") },
            { "LandYongkang",    () => Debug.Log("Yongkang！") },
            { "LandSoutheastern",() => Debug.Log("Southeastern！") },
            { "LandTainan",      () => Debug.Log("Tainan！") },
            { "LandAnnan",       () => Debug.Log("Annan！") },
            { "LandJiali",       () => Debug.Log("Jiali！") },
            { "LandMadou",       () => Debug.Log("Madou！") },
            { "LandYanshui",     () => Debug.Log("Yanshui！") },
            { "LandBaihe",       () => Debug.Log("Baihe！") },
            { "LandYujing",      () => Debug.Log("Yujing！") }
        };
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
