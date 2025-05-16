using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] Button StartButton;
    [SerializeField] GameObject StartMenu;

    public void HideStartMenu()
    {
        StartMenu.SetActive(false); //ÁôÂÃ StartMenu
    }
}
