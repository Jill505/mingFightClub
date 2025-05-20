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

    public PlayerData playerData = new PlayerData(); //實例化
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

        // 檢查檔案是否存在
        if (File.Exists(path))
        {
            string jsonString = File.ReadAllText(path);
            SaveFile swapSaveFile = JsonUtility.FromJson<SaveFile>(jsonString);
            saveFile = swapSaveFile;
        }
        else
        {
            // 若檔案不存在，初始化 saveFile
            saveFile = new SaveFile();

            // 可選：立即將初始化的 saveFile 存檔
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
        /// 出現"洩"時，代表預設資料錯誤
        /// </summary>
        public string playerSurname = "洩";

        public void InitializationPlayerData()
        {
            population = 30;
            money = 100;
        }
    }

    [SerializeField]
    public class LandData
    {
        public int Ignore = 0;//規避變數
        public Land[] lands = new Land[11];
    }
    [SerializeField]
    public class Land
    {
        public bool unlock = false;
        public string belongingGang = null;

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

    [SerializeField]
    public class Gang
    {
        public string GangName = "初始化失敗宗親會";
    }
}