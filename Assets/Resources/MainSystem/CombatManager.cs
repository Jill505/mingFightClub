using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class CombatManager : MonoBehaviour
{
    [Header("UI 元件")]
    public Button attackButton;
    public TextMeshProUGUI combatLogText; // 也可用 UnityEngine.UI.Text

    [Header("幫派資料")]
    public Gang playerGang;
    public Gang enemyGang;

    [Header("參數")]
    public float combatSpeed = 1.5f; // 每回合間隔秒數

    private bool isFighting = false;

    private void Start()
    {
        attackButton.onClick.AddListener(() => StartCombat());
    }

    public void StartCombat()
    {
        if (!isFighting)
        {
            StartCoroutine(FightCoroutine());
        }
    }

    IEnumerator FightCoroutine()
    {
        isFighting = true;
        combatLogText.text = "戰鬥開始！\n";

        while (playerGang.pop > 0 && enemyGang.pop > 0)
        {
            yield return new WaitForSeconds(combatSpeed);

            int outcome = Random.Range(0, 5); // 產生戰鬥結果
            string result = "";

            switch (outcome)
            {
                case 0:
                    result = "你攻擊敵人，造成 1 點傷害！";
                    enemyGang.pop--;
                    break;
                case 1:
                    result = "敵人攻擊你，造成 1 點傷害！";
                    playerGang.pop--;
                    break;
                case 2:
                    result = "雙方互有攻擊，各損 1 人！";
                    playerGang.pop--;
                    enemyGang.pop--;
                    break;
                case 3:
                    result = "你閃避了敵人的攻擊！";
                    break;
                case 4:
                    result = "敵人閃避了你的攻擊！";
                    break;
            }

            result += $"\n剩餘人口 - 你：{playerGang.pop}，敵人：{enemyGang.pop}";
            combatLogText.text += result + "\n";
        }

        yield return new WaitForSeconds(1f);
        ShowCombatResult();
        isFighting = false;
    }

    void ShowCombatResult()
    {
        if (playerGang.pop <= 0 && enemyGang.pop <= 0)
        {
            combatLogText.text += "<color=orange>雙方全滅，平手！</color>";
        }
        else if (playerGang.pop <= 0)
        {
            combatLogText.text += "<color=red>你輸了！</color>";
            // 可呼叫 Game Over 系統
        }
        else if (enemyGang.pop <= 0)
        {
            combatLogText.text += "<color=green>你贏了！</color>";
            enemyGang.GangOut(); // 敵方退出
        }
    }
}
