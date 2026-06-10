using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject shopMenu;

    public TextMeshProUGUI txtRedBall;
    public TextMeshProUGUI txtBlueBall;
    public TextMeshProUGUI txtYellowBall;
    public TextMeshProUGUI txtGreenBall;

    public TextMeshProUGUI txtDefaultButton;
    public TextMeshProUGUI txtRedButton;
    public TextMeshProUGUI txtBlueButton;
    public TextMeshProUGUI txtYellowButton;
    public TextMeshProUGUI txtGreenButton;

    public Renderer playerRenderer;

    public Material playerMaterial;
    public Material redMaterial;
    public Material blueMaterial;
    public Material yellowMaterial;
    public Material greenMaterial;

    private bool redBallOwned;
    private bool blueBallOwned;
    private bool yellowBallOwned;
    private bool greenBallOwned;

    private void Start()
    {
        redBallOwned = PlayerPrefs.GetInt("RedBallOwned", 0) == 1;
        blueBallOwned = PlayerPrefs.GetInt("BlueBallOwned", 0) == 1;
        yellowBallOwned = PlayerPrefs.GetInt("YellowBallOwned", 0) == 1;
        greenBallOwned = PlayerPrefs.GetInt("GreenBallOwned", 0) == 1;

        if(redBallOwned && PlayerPrefs.GetInt("SelectedSkin", -1) == -1)
        {
            PlayerPrefs.SetInt("SelectedSkin", 1);
            PlayerPrefs.Save();
        }
        UpdateUI();
        ApplySkin();
    }

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

    public void BuyRedBall()
    {
        if (redBallOwned)
        {
            EquipRedBall();
            return;
        }
 
        if (DiamondManager.instance.GetDiamond() >= 100)
        {
            DiamondManager.instance.SpendDiamond(100);
            redBallOwned = true;
            PlayerPrefs.SetInt("RedBallOwned", 1);
            PlayerPrefs.SetInt("SelectedSkin", 1);
            PlayerPrefs.Save();
            ApplySkin();
            UpdateUI();
            Debug.Log("Red Ball purchased!");
        }
        else
        {
            Debug.Log("Not enough diamonds to purchase the Red Ball.");
        }
    }

    public void BuyBlueBall()
    {
        if (blueBallOwned)
        {
            EquipBlueBall();
            return;
        }
        if (DiamondManager.instance.GetDiamond() >= 150)
        {
            DiamondManager.instance.SpendDiamond(150);
            blueBallOwned = true;
            PlayerPrefs.SetInt("BlueBallOwned", 1);
            PlayerPrefs.SetInt("SelectedSkin", 2);
            PlayerPrefs.Save();
            ApplySkin();
            UpdateUI();
            Debug.Log("Blue Ball purchased!");
        }
        else
        {
            Debug.Log("Not enough diamonds to purchase the Blue Ball.");
        }
    }

    public void BuyYellowBall()
    {
        if (yellowBallOwned)
        {
            EquipYellowBall();
            return;
        }
        if (DiamondManager.instance.GetDiamond() >= 200)
        {
            DiamondManager.instance.SpendDiamond(200);
            yellowBallOwned = true;
            PlayerPrefs.SetInt("YellowBallOwned", 1);
            PlayerPrefs.SetInt("SelectedSkin", 3);
            PlayerPrefs.Save();
            ApplySkin();
            UpdateUI();
            Debug.Log("Yellow Ball purchased!");
        }
        else
        {
            Debug.Log("Not enough diamonds to purchase the Yellow Ball.");
        }
    }

    public void BuyGreenBall()
    {
        if (greenBallOwned)
        {
            EquipGreenBall();
            return;
        }
        if (DiamondManager.instance.GetDiamond() >= 300)
        {
            DiamondManager.instance.SpendDiamond(300);
            greenBallOwned = true;
            PlayerPrefs.SetInt("GreenBallOwned", 1);
            PlayerPrefs.SetInt("SelectedSkin", 4);
            PlayerPrefs.Save();
            ApplySkin();
            UpdateUI();
            Debug.Log("Green Ball purchased!");
        }
        else
        {
            Debug.Log("Not enough diamonds to purchase the Green Ball.");
        }
    }

    public void EquipDefaultBall()
    {
        PlayerPrefs.SetInt("SelectedSkin", 0);
        PlayerPrefs.Save();
        ApplySkin();
        UpdateUI();
    }

    public void EquipRedBall()
    {
        if (redBallOwned)
        {
            PlayerPrefs.SetInt("SelectedSkin", 1);
            PlayerPrefs.Save();
            ApplySkin();
            UpdateUI();
        }
    }

    public void EquipBlueBall()
    {
        if (blueBallOwned)
        {
            PlayerPrefs.SetInt("SelectedSkin", 2);
            PlayerPrefs.Save();
            ApplySkin();
            UpdateUI();
        }
    }

    public void EquipYellowBall()
    {
        if (yellowBallOwned)
        {
            PlayerPrefs.SetInt("SelectedSkin", 3);
            PlayerPrefs.Save();
            ApplySkin();
            UpdateUI();
        }
    }

    public void EquipGreenBall()
    {
        if (greenBallOwned)
        {
            PlayerPrefs.SetInt("SelectedSkin", 4);
            PlayerPrefs.Save();
            ApplySkin();
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        int selectedSkin = PlayerPrefs.GetInt("SelectedSkin", 0);

        txtRedBall.text = redBallOwned ? "Red Ball - Owned" : "Red Ball - 100 Diamonds";
        txtBlueBall.text = blueBallOwned ? "Blue Ball - Owned" : "Blue Ball - 150 Diamonds";
        txtYellowBall.text = yellowBallOwned ? "Yellow Ball - Owned" : "Yellow Ball - 200 Diamonds";
        txtGreenBall.text = greenBallOwned ? "Green Ball - Owned" : "Green Ball - 300 Diamonds";

        if(selectedSkin == 0)
        {
            txtDefaultButton.text = "EQUIPPED";
        }
        else
        {
            txtDefaultButton.text = "EQUIP";
        }

        if (!redBallOwned)
        {
            txtRedButton.text = "BUY";
        }
        else if(selectedSkin == 1)
        {
            txtRedButton.text = "EQUIPPED";
        }
        else
        {
            txtRedButton.text = "EQUIP";
        }

        if(!blueBallOwned)
        {
            txtBlueButton.text = "BUY";
        }
        else if (selectedSkin == 2)
        {
            txtBlueButton.text = "EQUIPPED";
        }
        else
        {
            txtBlueButton.text = "EQUIP";
        }

        if(!yellowBallOwned)
        {
            txtYellowButton.text = "BUY";
        }
        else if (selectedSkin == 3)
        {
            txtYellowButton.text = "EQUIPPED";
        }
        else
        {
            txtYellowButton.text = "EQUIP";
        }

        if(!greenBallOwned)
        {
            txtGreenButton.text = "BUY";
        }
        else if (selectedSkin == 4)
        {
            txtGreenButton.text = "EQUIPPED";
        }
        else
        {
            txtGreenButton.text = "EQUIP";
        }
    }

    void ApplySkin()
    {
        int selectedSkin = PlayerPrefs.GetInt("SelectedSkin", 0);
        if (selectedSkin == 0)
        {
            playerRenderer.material = playerMaterial;
        }
        else if (selectedSkin == 1)
        {
            playerRenderer.material = redMaterial;
        }
        else if (selectedSkin == 2)
        {
            playerRenderer.material = blueMaterial;
        }else if(selectedSkin == 3)
        {
            playerRenderer.material = yellowMaterial;
        }else if(selectedSkin == 4)
        {
            playerRenderer.material = greenMaterial;
        }
    }
}
