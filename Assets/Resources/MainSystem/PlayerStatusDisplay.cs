using UnityEngine;
using TMPro;

public class PlayerStatusDisplay : MonoBehaviour
{
    public TextMeshProUGUI playerNameText;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI populationText;


    AllGameManager allGameManager;

    private void Awake()
    {
        allGameManager = GameObject.Find("AllGameManager")?.GetComponent<AllGameManager>();
    }
    private void Start()
    {
        allGameManager.saveFile.playerData.playerGang.GangName = "廖偉民";
        allGameManager.saveFile.playerData.InitializationPlayerData();

        if (allGameManager != null &&
            allGameManager.saveFile != null &&
            allGameManager.saveFile.safeFile != null &&
            allGameManager.saveFile.safeFile.playerData != null)
        {
            playerNameText.text = $"玩家姓名：{allGameManager.saveFile.playerData.playerGang.GangName}";
            moneyText.text = $"金錢：{allGameManager.saveFile.playerData.money}元";
            populationText.text = $"人口數：\n{allGameManager.saveFile.playerData.population}";
        }
        else
        {
            playerNameText.text = "玩家姓名：未知";
            moneyText.text = "金錢：未知";
            populationText.text = $"人口數：未知";
        }
    }

    private void FixedUpdate()
    {
        /*if (allGameManager != null &&
            allGameManager.saveFile != null &&
            allGameManager.saveFile.safeFile != null &&
            allGameManager.saveFile.safeFile.playerData != null)
        {*/
            playerNameText.text = $"玩家姓名：{allGameManager.saveFile.playerData.playerGang.GangName}";
            moneyText.text = $"金錢：{allGameManager.saveFile.playerData.money}元";
            populationText.text = $"人口數：\n{allGameManager.saveFile.playerData.population}";
       /* }*/
    }
}
