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

            playerNameText.text = $"���a�m�W�G{playerData.playerSurname}";
            moneyText.text = $"�����G{playerData.money}";
        }
        else
        {
            playerNameText.text = "���a�m�W�G����";
            moneyText.text = "�����G����";
        }
    }
}
