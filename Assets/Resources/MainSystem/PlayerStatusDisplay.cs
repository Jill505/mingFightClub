using UnityEngine;
using TMPro;

public class PlayerStatusDisplay : MonoBehaviour
{
    public TextMeshProUGUI playerNameText;
    public TextMeshProUGUI moneyText;

    private void Start()
    {
        AllGameManager allGameManager = GameObject.Find("AllGameManager")?.GetComponent<AllGameManager>();
        allGameManager.saveFile.playerData.playerSurname = "廖偉民";
        allGameManager.saveFile.playerData.money = 100;

        if (allGameManager != null &&
            allGameManager.saveFile != null &&
            allGameManager.saveFile.safeFile != null &&
            allGameManager.saveFile.safeFile.playerData != null)
        {
            playerNameText.text = $"玩家姓名：{allGameManager.saveFile.playerData.playerSurname}";
            moneyText.text = $"金錢：{allGameManager.saveFile.playerData.money}元";
        }
        else
        {
            playerNameText.text = "玩家姓名：未知";
            moneyText.text = "金錢：未知";
        }
    }

    private void FixedUpdate()
    {
        AllGameManager allGameManager = GameObject.Find("AllGameManager")?.GetComponent<AllGameManager>();

        if (allGameManager != null &&
            allGameManager.saveFile != null &&
            allGameManager.saveFile.safeFile != null &&
            allGameManager.saveFile.safeFile.playerData != null)
        {
            var playerData = allGameManager.saveFile.safeFile.playerData;

            playerNameText.text = $"玩家姓名：{allGameManager.saveFile.playerData.playerSurname}";
            moneyText.text = $"金錢：{allGameManager.saveFile.playerData.money}元";
        }
    }
}
