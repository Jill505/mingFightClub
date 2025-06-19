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

    public PlayerData playerData = new PlayerData(); //實例化
    public LandData landData = new LandData();
    public GangData gangData = new GangData();

    public void SaveTheFile()
    {
        //Debug.Log("儲存");
        string jsonString = JsonUtility.ToJson(safeFile);
        File.WriteAllText(Application.persistentDataPath + "/SaveFile.json", jsonString);
    }

    public void LoadTheFile()
    {
        //SaveFile saveFile;

        string path = Application.persistentDataPath + "/SaveFile.json";
        Debug.Log("載入檔案");

        // 檢查檔案是否存在
        if (File.Exists(path))
        {
            Debug.Log("開始載入");
            string jsonString = File.ReadAllText(path);
            SaveFile swapSaveFile = JsonUtility.FromJson<SaveFile>(jsonString);
            safeFile = swapSaveFile;
        }
        else
        {
            // 若檔案不存在，初始化 saveFile
            Debug.Log("沒有獨到 初始化存檔");
            safeFile = new SaveFile();

            // 可選：立即將初始化的 saveFile 存檔
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
        public int Ignore = 0;//規避變數
        public Land[] lands = new Land[11];
    }
    [Serializable]
    public class Land
    {
        public string areaName = "山";

        public bool unlock = false;
        public string belongingGang = null;//屬於的幫派

        public int landPopulation = 100;
        public int landMoney = 30;

        /// <summary>
        /// 人口設施
        /// </summary>
        public bool buildingUnlockA = false;
        public int buildingUnlockRequireMoneyA = 100;
        /// <summary>
        /// 文化設施
        /// </summary>
        public bool buildingUnlockB = false;
        public int buildingUnlockRequireMoneyB = 100;
        /// <summary>
        /// 商行設施
        /// </summary>
        public bool buildingUnlockC = false;
        public int buildingUnlockRequireMoneyC = 100;

        /// <summary>
        /// 使用該function，判斷土地屬於哪個勢力
        /// </summary>
        public void JudgeHavingGang()
        {
            //假如 belongingGang == 玩家名字
            //代表這個土地屬於玩家

            //else if(foreach(所有存在的Gang, 比對gang name, 假如相同, land 屬於該gang))
            //屬於敵人
            //if(belongingGang == )
        }
    }

[Serializable]
public class Gang
{
    public string GangName = "預設姓";
    public int pop = 100;
    public int cult = 100;
    public int money = 30;
        
    public Land[] myLands = new Land[11]; 

    public void IncreseForEachTurn()
    {
        Debug.Log("幫派增加，我有被觸發！");
        pop =  (int)(pop * 1.4f);
        money = (int)(money * 1.4f);
    }

    public void GangOut()
    {
        //TODO: 實作幫派被完全打敗
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