using System;
using System.IO;
using UnityEngine;

public class AllGameManager : MonoBehaviour
{
    public SaveFile saveFile = new SaveFile();
    public InGameManager inGameManager = new InGameManager();   
    private void Awake()
    {
        saveFile.LoadTheFile();
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        saveFile.SaveTheFile();
    }
}

[Serializable]
public class SaveFile
{
    public SaveFile safeFile;

    public PlayerData playerData = new PlayerData(); //��Ҥ�
    public LandData landData = new LandData();
    public GangData gangData = new GangData();

    public void SaveTheFile()
    {
        //Debug.Log("�x�s");
        string jsonString = JsonUtility.ToJson(safeFile);
        File.WriteAllText(Application.persistentDataPath + "/SaveFile.json", jsonString);
    }

    public void LoadTheFile()
    {
        //SaveFile saveFile;

        string path = Application.persistentDataPath + "/SaveFile.json";
        Debug.Log("���J�ɮ�");

        // �ˬd�ɮ׬O�_�s�b
        if (File.Exists(path))
        {
            Debug.Log("�}�l���J");
            string jsonString = File.ReadAllText(path);
            SaveFile swapSaveFile = JsonUtility.FromJson<SaveFile>(jsonString);
            safeFile = swapSaveFile;
        }
        else
        {
            // �Y�ɮפ��s�b�A��l�� saveFile
            Debug.Log("�S���W�� ��l�Ʀs��");
            safeFile = new SaveFile();

            // �i��G�ߧY�N��l�ƪ� saveFile �s��
            string json = JsonUtility.ToJson(safeFile, true);
            File.WriteAllText(path, json);
        }
    }
}
    [Serializable]
    public class PlayerData
    {
        public int population = -10;
        public int money = -10;

        public PlayerGang playerGang;

        public void InitializationPlayerData()
        {
            population = 100;
            money = 100;
        }
    }

    [Serializable]
    public class LandData
    {
        public int Ignore = 0;//�W���ܼ�
        public Land[] lands = new Land[11];
    }
    [Serializable]
    public class Land
    {
        public string areaName = "�s";

        public bool unlock = false;
        public string belongingGang = null;//�ݩ�����

        public int landPopulation = 100;
        public int landMoney = 30;

        /// <summary>
        /// �H�f�]�I
        /// </summary>
        public bool buildingUnlockA = false;
        public int buildingUnlockRequireMoneyA = 100;
        /// <summary>
        /// ��Ƴ]�I
        /// </summary>
        public bool buildingUnlockB = false;
        public int buildingUnlockRequireMoneyB = 100;
        /// <summary>
        /// �Ӧ�]�I
        /// </summary>
        public bool buildingUnlockC = false;
        public int buildingUnlockRequireMoneyC = 100;

        /// <summary>
        /// �ϥθ�function�A�P�_�g�a�ݩ���ӶդO
        /// </summary>
        public void JudgeHavingGang()
        {
            //���p belongingGang == ���a�W�r
            //�N��o�Ӥg�a�ݩ󪱮a

            //else if(foreach(�Ҧ��s�b��Gang, ���gang name, ���p�ۦP, land �ݩ��gang))
            //�ݩ�ĤH
            //if(belongingGang == )
        }
    }

[Serializable]
public class Gang
{
    public string GangName = "�w�]�m";
    public int pop = 100;
    public int cult = 100;
    public int money = 30;
        
    public Land[] myLands = new Land[11]; 

    public void IncreseForEachTurn()
    {
        Debug.Log("�����W�[�A�ڦ��QĲ�o�I");
        pop =  (int)(pop * 1.4f);
        money = (int)(money * 1.4f);
    }

    public void GangOut()
    {
        //TODO: ��@�����Q��������
        PlayerData playerData = GameObject.Find("AllGameManager").GetComponent<AllGameManager>().saveFile.playerData;
        Land[] AllLands = GameObject.Find("AllGameManager").GetComponent<AllGameManager>().saveFile.landData.lands;
        for (int i = 0; i < AllLands.Length; i++)
        {
            if (AllLands[i].belongingGang == GangName)
            {
                AllLands[i].belongingGang = playerData.playerGang.GangName;
        
            }
        }
        for (int i = 0; i < GameObject.Find("AllGameManager").GetComponent<AllGameManager>().saveFile.gangData.gangs.Length; i++)
        {
            GameObject.Find("AllGameManager").GetComponent<AllGameManager>().saveFile.gangData.gangs[i].RegistLandData();
        }
    }

    public void RegistLandData()
    {
        Land[] AllLands = GameObject.Find("AllGameManager").GetComponent<AllGameManager>().saveFile.landData.lands;
        for (int i = 0; i < AllLands.Length; i++)
        {
            if (AllLands[i].belongingGang == GangName)
            {
                myLands[i] = AllLands[i];
            }
        }
    }

}

[Serializable]
public class PlayerGang : Gang
{

}

[Serializable]
public class GangData
{
    int IWANTTOSLEEP;
    public Gang[] gangs = new Gang[11];
}