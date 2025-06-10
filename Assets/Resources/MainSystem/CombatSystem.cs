using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CoroutineExample : MonoBehaviour
{
    public Text CombatShowText;



    void Start()
    {
        // �Ұʨ�{
        //StartCoroutine(Fighting());
        //Debug.Log("�ڦb��A�ڥsCombatSystem");
        //Debug.Log("�ڱ����b" + gameObject.name + "�W");
    }

    public void CallFight(Gang myGang, Gang enemyGang)
    {
        StartCoroutine(Fighting(myGang, enemyGang));
    }

    public void CombatResultJudgement(Gang myGang, Gang enemyGang)
    {
        if (myGang.pop <= 0)
        {
            //All Game Over �����C������
            //TODO: �X�{�C�����Ѥ����A�ǳƭ��s�C��
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
            int res = Random.Range(0, 15); // ���� 0 �� 14 �����

            switch (res)
            {
                case 0:
                    Debug.Log("0�G�ĤH�{�פF�����I");
                    CombatShowText.text = "�ĤH�{�פF�����I";
                    break;
                case 1:
                    Debug.Log("1�G�A�y���F���L�ˮ`�C");
                    break;
                case 2:
                    Debug.Log("2�G�����I�ˮ`�[���I");
                    break;
                case 3:
                    Debug.Log("3�G�A�Q�����F�I");
                    break;
                case 4:
                    Debug.Log("4�G�A���_�F�ĤH���ޯ�I");
                    break;
                case 5:
                    Debug.Log("5�G�A��o�F�@�I��q�C");
                    break;
                case 6:
                    Debug.Log("6�G�ĤH���F�w�t�C");
                    break;
                case 7:
                    Debug.Log("7�G�A�{�פF�����I");
                    break;
                case 8:
                    Debug.Log("8�G�A�y���F�@���B�~�����C");
                    break;
                case 9:
                    Debug.Log("9�G�ĤH�i�J���m���A�C");
                    break;
                case 10:
                    Debug.Log("10�G�A�y�������ˮ`�C");
                    break;
                case 11:
                    Debug.Log("11�G�A��o�@�ӼW�q�ĪG�I");
                    break;
                case 12:
                    Debug.Log("12�G�A��o�@���B�~�^�X�I");
                    break;
                case 13:
                    Debug.Log("13�G�ĤH�չϰk�]�C");
                    break;
                case 14:
                    Debug.Log("14�G�A�I�i�F�����ޡI");
                    break;
            }

            yield return new WaitForSeconds(1.5f);
        }
        CombatResultJudgement(myGang, enemyGang);
    }
}
