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
    public PlayerData playerData = new PlayerData(); //實例化
    public LandData landData = new LandData();

    public void SaveTheFile()
    {
        /*
         //同步現在時間
        //showNowTime.text = DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
        //儲存上次時間 如影響校能應優先考慮刪除
        SaveTime ST = new SaveTime();
        ST = SaveTime.giveTime(DateTime.Now);
        PlayerPrefs.SetString("LastLoginTime", JsonUtility.ToJson(ST));//序列化
        PlayerPrefs.Save();
         */
    }

    public void LoadTheFile()
    {
        /*參考資料
         
        SaveTime ST = new SaveTime();
        if (login == true)
        {//防止場景切回來二次計算
            login = false;
            if (!PlayerPrefs.HasKey("LastLoginTime"))
            {
                //初始化
                Debug.Log("首次遊玩本遊戲");
                savedTime_LastTimeLogin = DateTime.Now;
                Debug.Log("實現時間重置");
                //儲存現在時間
                ST = SaveTime.giveTime(DateTime.Now);
                PlayerPrefs.SetString("LastLoginTime", JsonUtility.ToJson(ST));//序列化
                PlayerPrefs.Save();
            }
            else
            {
                //取得上次時間
                SaveTime STR = JsonUtility.FromJson<SaveTime>(PlayerPrefs.GetString("LastLoginTime"));//反序列化
                savedTime_LastTimeLogin = SaveTime.giveDate(STR);
                //儲存現在時間
                ST = SaveTime.giveTime(DateTime.Now);
                PlayerPrefs.SetString("LastLoginTime", JsonUtility.ToJson(ST));//序列化
                PlayerPrefs.Save();
            }

            //syncer.text = DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
            Debug.Log("這次登陸：" + DateTime.Now + "\n" + "上次登陸：" + savedTime_LastTimeLogin);
            //計算時間差
            TimeSpan TS = DateTime.Now - savedTime_LastTimeLogin;
            lobby_entry.lastPastTime = (int)TS.TotalSeconds;

            //弄個提示字
            if (lastLogTimeShowcase != null)
            {
                if (TS.Days > 0)
                {
                    //lastLogTimeShowcase.text = "歡迎回來\n距離上次登陸已經過了\n" + TS.Days + "天" + TS.Hours + "小時 " + TS.Minutes + "分鐘 " + TS.Seconds + "秒";
                }
                else if (TS.Hours > 0)
                {
                    //lastLogTimeShowcase.text = "歡迎回來\n距離上次登陸已經過了\n" + TS.Hours + "小時 " + TS.Minutes + "分鐘 " + TS.Seconds + "秒";
                }
                else
                {
                    //lastLogTimeShowcase.text = "歡迎回來\n距離上次登陸已經過了\n" + TS.Minutes + "分鐘 " + TS.Seconds + "秒";
                }
                Destroy(lastLogTimeShowcase.gameObject, 10f);
            }
        }
        else
        {
            //切換視窗 or 切換場景時觸發
        }
         */
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