using UnityEngine;
using System.Collections;

public class CoroutineExample : MonoBehaviour
{
    void Start()
    {
        // �Ұʨ�{
        //StartCoroutine(Fighting());
    }

    IEnumerator Fighting(int myPop, int emenyPop)
    {
        while (myPop > 0 && emenyPop > 0)
        {
            int res = Random.Range(0, 15); // ���� 0 �� 14 �����

            switch (res)
            {
                case 0:
                    Debug.Log("0�G�ĤH�{�פF�����I");
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
    }
}
