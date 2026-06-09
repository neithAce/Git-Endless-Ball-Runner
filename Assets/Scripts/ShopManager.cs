using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject shopMenu;

    public void OpenShop()
    {
        mainMenu.SetActive(false);
        shopMenu.SetActive(true);
    }

    public void CloseShop()
    {
        shopMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
