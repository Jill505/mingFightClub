using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class CombatManager : MonoBehaviour
{
    [Header("UI ����")]
    public Button attackButton;
    public TextMeshProUGUI combatLogText; // �]�i�� UnityEngine.UI.Text

    [Header("�������")]
    public Gang playerGang;
    public Gang enemyGang;

    [Header("�Ѽ�")]
    public float combatSpeed = 1.5f; // �C�^�X���j���

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
        combatLogText.text = "�԰��}�l�I\n";

        while (playerGang.pop > 0 && enemyGang.pop > 0)
        {
            yield return new WaitForSeconds(combatSpeed);

            int outcome = Random.Range(0, 5); // ���;԰����G
            string result = "";

            switch (outcome)
            {
                case 0:
                    result = "�A�����ĤH�A�y�� 1 �I�ˮ`�I";
                    enemyGang.pop--;
                    break;
                case 1:
                    result = "�ĤH�����A�A�y�� 1 �I�ˮ`�I";
                    playerGang.pop--;
                    break;
                case 2:
                    result = "���褬�������A�U�l 1 �H�I";
                    playerGang.pop--;
                    enemyGang.pop--;
                    break;
                case 3:
                    result = "�A�{�פF�ĤH�������I";
                    break;
                case 4:
                    result = "�ĤH�{�פF�A�������I";
                    break;
            }

            result += $"\n�Ѿl�H�f - �A�G{playerGang.pop}�A�ĤH�G{enemyGang.pop}";
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
            combatLogText.text += "<color=orange>��������A����I</color>";
        }
        else if (playerGang.pop <= 0)
        {
            combatLogText.text += "<color=red>�A��F�I</color>";
            // �i�I�s Game Over �t��
        }
        else if (enemyGang.pop <= 0)
        {
            combatLogText.text += "<color=green>�AĹ�F�I</color>";
            enemyGang.GangOut(); // �Ĥ�h�X
        }
    }
}
