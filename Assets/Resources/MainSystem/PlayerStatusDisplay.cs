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
        allGameManager.saveFile.playerData.playerGang.GangName = "������";
        allGameManager.saveFile.playerData.InitializationPlayerData();

        if (allGameManager != null &&
            allGameManager.saveFile != null &&
            allGameManager.saveFile.safeFile != null &&
            allGameManager.saveFile.safeFile.playerData != null)
        {
            playerNameText.text = $"���a�m�W�G{allGameManager.saveFile.playerData.playerGang.GangName}";
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
        /*if (allGameManager != null &&
            allGameManager.saveFile != null &&
            allGameManager.saveFile.safeFile != null &&
            allGameManager.saveFile.safeFile.playerData != null)
        {*/
            playerNameText.text = $"���a�m�W�G{allGameManager.saveFile.playerData.playerGang.GangName}";
            moneyText.text = $"�����G{allGameManager.saveFile.playerData.money}��";
            populationText.text = $"�H�f�ơG\n{allGameManager.saveFile.playerData.population}";
       /* }*/
    }
}
