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
    public PlayerData playerData = new PlayerData(); //��Ҥ�
    public LandData landData = new LandData();

    public void SaveTheFile()
    {
        /*
         //�P�B�{�b�ɶ�
        //showNowTime.text = DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
        //�x�s�W���ɶ� �p�v�T�կ����u���Ҽ{�R��
        SaveTime ST = new SaveTime();
        ST = SaveTime.giveTime(DateTime.Now);
        PlayerPrefs.SetString("LastLoginTime", JsonUtility.ToJson(ST));//�ǦC��
        PlayerPrefs.Save();
         */
    }

    public void LoadTheFile()
    {
        /*�ѦҸ��
         
        SaveTime ST = new SaveTime();
        if (login == true)
        {//����������^�ӤG���p��
            login = false;
            if (!PlayerPrefs.HasKey("LastLoginTime"))
            {
                //��l��
                Debug.Log("�����C�����C��");
                savedTime_LastTimeLogin = DateTime.Now;
                Debug.Log("��{�ɶ����m");
                //�x�s�{�b�ɶ�
                ST = SaveTime.giveTime(DateTime.Now);
                PlayerPrefs.SetString("LastLoginTime", JsonUtility.ToJson(ST));//�ǦC��
                PlayerPrefs.Save();
            }
            else
            {
                //���o�W���ɶ�
                SaveTime STR = JsonUtility.FromJson<SaveTime>(PlayerPrefs.GetString("LastLoginTime"));//�ϧǦC��
                savedTime_LastTimeLogin = SaveTime.giveDate(STR);
                //�x�s�{�b�ɶ�
                ST = SaveTime.giveTime(DateTime.Now);
                PlayerPrefs.SetString("LastLoginTime", JsonUtility.ToJson(ST));//�ǦC��
                PlayerPrefs.Save();
            }

            //syncer.text = DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second;
            Debug.Log("�o���n���G" + DateTime.Now + "\n" + "�W���n���G" + savedTime_LastTimeLogin);
            //�p��ɶ��t
            TimeSpan TS = DateTime.Now - savedTime_LastTimeLogin;
            lobby_entry.lastPastTime = (int)TS.TotalSeconds;

            //�˭Ӵ��ܦr
            if (lastLogTimeShowcase != null)
            {
                if (TS.Days > 0)
                {
                    //lastLogTimeShowcase.text = "�w��^��\n�Z���W���n���w�g�L�F\n" + TS.Days + "��" + TS.Hours + "�p�� " + TS.Minutes + "���� " + TS.Seconds + "��";
                }
                else if (TS.Hours > 0)
                {
                    //lastLogTimeShowcase.text = "�w��^��\n�Z���W���n���w�g�L�F\n" + TS.Hours + "�p�� " + TS.Minutes + "���� " + TS.Seconds + "��";
                }
                else
                {
                    //lastLogTimeShowcase.text = "�w��^��\n�Z���W���n���w�g�L�F\n" + TS.Minutes + "���� " + TS.Seconds + "��";
                }
                Destroy(lastLogTimeShowcase.gameObject, 10f);
            }
        }
        else
        {
            //�������� or ����������Ĳ�o
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