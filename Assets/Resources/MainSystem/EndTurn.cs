using UnityEngine;
using UnityEngine.UI;

public class EndTurn : MonoBehaviour
{
    public AllGameManager allGameManager;
    public Button endTurn;

    public void GrowthInNumbersAndMoney()
    {
        allGameManager.saveFile.playerData.population = Mathf.CeilToInt(allGameManager.saveFile.playerData.population * 1.4f);
        allGameManager.saveFile.playerData.money = Mathf.CeilToInt(allGameManager.saveFile.playerData.money * 1.4f);
        /*foreach (Land land in allGameManager.saveFile.landData.lands)
        {
            land.landPopulation = Mathf.CeilToInt(land.landPopulation * 1.4f);
            land.landMoney = Mathf.CeilToInt(land.landMoney * 1.4f);
        }*/
        foreach (Gang gangs in allGameManager.saveFile.gangData.gangs)
        {
            gangs.IncreseForEachTurn();
        }
    }

}
