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
            attackButton.interactable = false;  // �}�l�԰����������s�קK�����I��
            StartCoroutine(FightCoroutine());
        });
    }

    private IEnumerator FightCoroutine()
    {
        combatLogText.text = "�԰��}�l�I";

        while (playerGang.pop > 0 && enemyGang.pop > 0)
        {
            int res = Random.Range(0, 15);
            string message = res switch
            {
                0 => "�ĤH�{�פF�����I",
                1 => "�A�y���F���L�ˮ`�C",
                2 => "�����I�ˮ`�[���I",
                3 => "�A�Q�����F�I",
                4 => "�A���_�F�ĤH���ޯ�I",
                5 => "�A��o�F�@�I��q�C",
                6 => "�ĤH���F�w�t�C",
                7 => "�A�{�פF�����I",
                8 => "�A�y���F�@���B�~�����C",
                9 => "�ĤH�i�J���m���A�C",
                10 => "�A�y�������ˮ`�C",
                11 => "�A��o�@�ӼW�q�ĪG�I",
                12 => "�A��o�@���B�~�^�X�I",
                13 => "�ĤH�չϰk�]�C",
                14 => "�A�I�i�F�����ޡI",
                _ => ""
            };

            combatLogText.text = message;
            Debug.Log(message);

            // �o��²������l���޿�]�i�H�̧A�޿�վ�^
            if (res == 1 || res == 2 || res == 8 || res == 10 || res == 14)
            {
                enemyGang.pop -= 10;  // �ĤH����
            }
            else if (res == 3)
            {
                playerGang.pop -= 10; // ���a�Q��������
            }

            yield return new WaitForSeconds(1.5f);
        }

        if (playerGang.pop <= 0)
        {
            combatLogText.text = "�A�Q���ѤF�I�C�������C";
        }
        else if (enemyGang.pop <= 0)
        {
            combatLogText.text = "�Ĥ�Q���ѡA�A�ӧQ�F�I";
            enemyGang.GangOut();
        }

        attackButton.interactable = true; // �԰��������s�}�ҫ��s
    }
}

