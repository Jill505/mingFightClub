using System.IO;
using UnityEngine;

public class AllGameManager : MonoBehaviour
{
    public SaveFile saveFile;

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

[SerializeField]
public class SaveFile
{
    public SaveFile safeFile;

    public PlayerData playerData = new PlayerData(); //��Ҥ�
    public LandData landData = new LandData();

    public void SaveTheFile()
    {
        string jsonString = JsonUtility.ToJson(safeFile);
        File.WriteAllText(Application.persistentDataPath + "/SaveFile.json", jsonString);
    }

    public void LoadTheFile()
    {
        SaveFile saveFile;

        string path = Application.persistentDataPath + "/SaveFile.json";

        // �ˬd�ɮ׬O�_�s�b
        if (File.Exists(path))
        {
            string jsonString = File.ReadAllText(path);
            SaveFile swapSaveFile = JsonUtility.FromJson<SaveFile>(jsonString);
            saveFile = swapSaveFile;
        }
        else
        {
            // �Y�ɮפ��s�b�A��l�� saveFile
            saveFile = new SaveFile();

            // �i��G�ߧY�N��l�ƪ� saveFile �s��
            string json = JsonUtility.ToJson(saveFile, true);
            File.WriteAllText(path, json);
        }
    }

    [SerializeField]
    public class PlayerData
    {
        public int population = -10;
        public int money = -10;

        /// <summary>
        /// �X�{"��"�ɡA�N��w�]��ƿ��~
        /// </summary>
        public string playerSurname = "��";

        public void InitializationPlayerData()
        {
            population = 30;
            money = 100;
        }
    }

    [SerializeField]
    public class LandData
    {
        public int Ignore = 0;//�W���ܼ�
        public Land[] lands = new Land[11];
    }
    [SerializeField]
    public class Land
    {
        public bool unlock = false;
        public string belongingGang = null;

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

    [SerializeField]
    public class Gang
    {
        public string GangName = "��l�ƥ��ѩv�˷|";
    }
}