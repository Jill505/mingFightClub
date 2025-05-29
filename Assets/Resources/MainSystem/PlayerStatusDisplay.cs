using UnityEngine;
using TMPro;

public class PlayerStatusDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerNameText;
    [SerializeField] private TextMeshProUGUI moneyText;

    private void Start()
    {
        AllGameManager allGameManager = GameObject.Find("AllGameManager")?.GetComponent<AllGameManager>();

        if (allGameManager != null &&
            allGameManager.saveFile != null &&
            allGameManager.saveFile.safeFile != null &&
            allGameManager.saveFile.safeFile.playerData != null)
        {
            var playerData = allGameManager.saveFile.safeFile.playerData;

            playerNameText.text = $"玩家姓名：{playerData.playerSurname}";
            moneyText.text = $"金錢：{playerData.money}";
        }
        else
        {
            playerNameText.text = "玩家姓名：未知";
            moneyText.text = "金錢：未知";
        }
    }
}
