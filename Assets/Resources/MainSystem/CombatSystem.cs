using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CoroutineExample : MonoBehaviour
{
    public Text CombatShowText;



    void Start()
    {
        // 啟動協程
        //StartCoroutine(Fighting());
        //Debug.Log("我在喔，我叫CombatSystem");
        //Debug.Log("我掛載在" + gameObject.name + "上");
    }

    public void CallFight(Gang myGang, Gang enemyGang)
    {
        StartCoroutine(Fighting(myGang, enemyGang));
    }

    public void CombatResultJudgement(Gang myGang, Gang enemyGang)
    {
        if (myGang.pop <= 0)
        {
            //All Game Over 全局遊戲結束
            //TODO: 出現遊戲失敗介面，準備重製遊戲
        }
        if (enemyGang.pop <= 0)
        {
            enemyGang.GangOut();
        }
    }


    IEnumerator Fighting(Gang myGang, Gang enemyGang)
    {
        while (myGang.pop> 0 && enemyGang.pop> 0)
        {
            int res = Random.Range(0, 15); // 產生 0 到 14 的整數

            switch (res)
            {
                case 0:
                    Debug.Log("0：敵人閃避了攻擊！");
                    CombatShowText.text = "敵人閃避了攻擊！";
                    break;
                case 1:
                    Debug.Log("1：你造成了輕微傷害。");
                    break;
                case 2:
                    Debug.Log("2：暴擊！傷害加倍！");
                    break;
                case 3:
                    Debug.Log("3：你被反擊了！");
                    break;
                case 4:
                    Debug.Log("4：你打斷了敵人的技能！");
                    break;
                case 5:
                    Debug.Log("5：你獲得了一點能量。");
                    break;
                case 6:
                    Debug.Log("6：敵人中了暈眩。");
                    break;
                case 7:
                    Debug.Log("7：你閃避了攻擊！");
                    break;
                case 8:
                    Debug.Log("8：你造成了一次額外攻擊。");
                    break;
                case 9:
                    Debug.Log("9：敵人進入防禦狀態。");
                    break;
                case 10:
                    Debug.Log("10：你造成中等傷害。");
                    break;
                case 11:
                    Debug.Log("11：你獲得一個增益效果！");
                    break;
                case 12:
                    Debug.Log("12：你獲得一個額外回合！");
                    break;
                case 13:
                    Debug.Log("13：敵人試圖逃跑。");
                    break;
                case 14:
                    Debug.Log("14：你施展了必殺技！");
                    break;
            }

            yield return new WaitForSeconds(1.5f);
        }
        CombatResultJudgement(myGang, enemyGang);
    }
}
