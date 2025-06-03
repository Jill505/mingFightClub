using Unity.VisualScripting;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    [Header("Basic Declare")]
    public AllGameManager allGameManager;
    public LandInformation[] LandInfos = new LandInformation[11];

    public void JudgeLandAttackable()
    {
        for (int i = 0; i < 11; i++)
        {
            for (int j = 0; j < LandInfos[i].attLand.Length; j++)
            {
                if (LandInfos[i].attackAble == true)
                {
                    break;
                }
                for (int k = 0; k < allGameManager.saveFile.playerData.playerGang.myLands.Length; k++)
                {
                    if (LandInfos[i].attackAble == true)
                    {
                        break;
                    }
                    if (LandInfos[i].attLand[j] == allGameManager.saveFile.playerData.playerGang.myLands[k].areaName)
                    {
                        LandInfos[i].attackAble = true; 
                    }
                }
            }
        }
    }

    private void SyncLamdInfosToSaveData()
    {
        for (int i = 0; i < 11; i++)
        {
            allGameManager.saveFile.landData.lands[i] = LandInfos[i].returnLand();
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        SyncLamdInfosToSaveData();
    }
}
