using UnityEngine;
using TMPro;

public class PlayerStatusDisplay : MonoBehaviour
{
    public TextMeshProUGUI playerNameText;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI populationText;

    private void Start()
    {
        AllGameManager allGameManager = GameObject.Find("AllGameManager")?.GetComponent<AllGameManager>();
        allGameManager.saveFile.playerData.playerSurname = "������";
        allGameManager.saveFile.playerData.InitializationPlayerData();

        if (allGameManager != null &&
            allGameManager.saveFile != null &&
            allGameManager.saveFile.safeFile != null &&
            allGameManager.saveFile.safeFile.playerData != null)
        {
            playerNameText.text = $"���a�m�W�G{allGameManager.saveFile.playerData.playerSurname}";
            moneyText.text = $"�����G{allGameManager.saveFile.playerData.money}��";
            populationText.text = $"�H�f�ơG\n{allGameManager.saveFile.playerData.population}";
        }
        else
        {
            playerNameText.text = "���a�m�W�G����";
            moneyText.text = "�����G����";
            populationText.text = $"�H�f�ơG����";
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
            playerNameText.text = $"���a�m�W�G{allGameManager.saveFile.playerData.playerSurname}";
            moneyText.text = $"�����G{allGameManager.saveFile.playerData.money}��";
            populationText.text = $"�H�f�ơG\n{allGameManager.saveFile.playerData.population}";
        }
    }
}
