using UnityEngine;

public class RegionalHoldingJudgment : MonoBehaviour
{
    private void FixedUpdate()
    {
        foreach (Transform region in transform)//���b�x�n�a�ϤW�ɡA�|���o�x�n�a�Ϫ��l����A�]�N�O11�Ӱϰ�
        {
            bool isOwned = region.CompareTag("Player");//�x�s�Ӱϰ�O�_�OPlayer�o��TAG

            foreach (Transform child in region)//����U�ϰ�U���l����
            {
                if (child.CompareTag("Flag"))//�P�_�U�ϰ�U���l����O�_��Flag�o��TAG
                {
                    child.gameObject.SetActive(isOwned);//�l����N�ھڸӰϰ�O�_�ݩ󪱮a�i����ܩ�����
                }
            }
        }
    }
}
