using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] Button StartButton;
    [SerializeField] GameObject StartMenu;
    [SerializeField] GameObject TainanMap;

    public void HideStartMenu()
    {
        StartMenu.SetActive(false); //���� StartMenu
        TainanMap.SetActive(true); //���� StartMenu
    }
}
