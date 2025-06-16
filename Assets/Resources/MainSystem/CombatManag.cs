using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class CombatManager : MonoBehaviour
{
    public Button attackButton;
    public TextMeshProUGUI combatLogText;

    public Gang playerGang;
    public Gang enemyGang;

    private void Start()
    {
        attackButton.onClick.AddListener(() =>
        {
            attackButton.interactable = false;  // 開始戰鬥時關閉按鈕避免重複點擊
            StartCoroutine(FightCoroutine());
        });
    }

    private IEnumerator FightCoroutine()
    {
        combatLogText.text = "戰鬥開始！";

        while (playerGang.pop > 0 && enemyGang.pop > 0)
        {
            int res = Random.Range(0, 15);
            string message = res switch
            {
                0 => "敵人閃避了攻擊！",
                1 => "你造成了輕微傷害。",
                2 => "暴擊！傷害加倍！",
                3 => "你被反擊了！",
                4 => "你打斷了敵人的技能！",
                5 => "你獲得了一點能量。",
                6 => "敵人中了暈眩。",
                7 => "你閃避了攻擊！",
                8 => "你造成了一次額外攻擊。",
                9 => "敵人進入防禦狀態。",
                10 => "你造成中等傷害。",
                11 => "你獲得一個增益效果！",
                12 => "你獲得一個額外回合！",
                13 => "敵人試圖逃跑。",
                14 => "你施展了必殺技！",
                _ => ""
            };

            combatLogText.text = message;
            Debug.Log(message);

            // 這裡簡單模擬損血邏輯（可以依你邏輯調整）
            if (res == 1 || res == 2 || res == 8 || res == 10 || res == 14)
            {
                enemyGang.pop -= 10;  // 敵人扣血
            }
            else if (res == 3)
            {
                playerGang.pop -= 10; // 玩家被反擊扣血
            }

            yield return new WaitForSeconds(1.5f);
        }

        if (playerGang.pop <= 0)
        {
            combatLogText.text = "你被擊敗了！遊戲結束。";
        }
        else if (enemyGang.pop <= 0)
        {
            combatLogText.text = "敵方被擊敗，你勝利了！";
            enemyGang.GangOut();
        }

        attackButton.interactable = true; // 戰鬥結束重新開啟按鈕
    }
}

