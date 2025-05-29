using UnityEngine;
using TMPro;

public class PlayerStatusDisplay : MonoBehaviour
{
    public TextMeshProUGUI playerNameText;
    public TextMeshProUGUI moneyText;

    private void Start()
    {
        AllGameManager allGameManager = GameObject.Find("AllGameManager")?.GetComponent<AllGameManager>();
        allGameManager.saveFile.playerData.playerSurname = "������";
        allGameManager.saveFile.playerData.money = 100;

        if (allGameManager != null &&
            allGameManager.saveFile != null &&
            allGameManager.saveFile.safeFile != null &&
            allGameManager.saveFile.safeFile.playerData != null)
        {
            playerNameText.text = $"���a�m�W�G{allGameManager.saveFile.playerData.playerSurname}";
            moneyText.text = $"�����G{allGameManager.saveFile.playerData.money}��";
        }
        else
        {
            playerNameText.text = "���a�m�W�G����";
            moneyText.text = "�����G����";
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

            playerNameText.text = $"���a�m�W�G{allGameManager.saveFile.playerData.playerSurname}";
            moneyText.text = $"�����G{allGameManager.saveFile.playerData.money}��";
        }
    }
}
