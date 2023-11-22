using UnityEngine;
using UnityEngine.UI;

public class LocaController : MonoBehaviour
{
    public GameObject canvasLoca;
    public Button locaButton;
    public AudioSource clickSound;
    public Text diamondText;
    private ClickerGame clickerGame;

    private string[] locaElements = { "MainMenuBGRazmit", "DesertBGRazmit", "MountainLakeBGRazmit", "NightCItyBGRazmit", "WinterBGRazmit", "bg2" };
    private int currentElementIndex = 0;

    void Start()
    {
        clickerGame = FindObjectOfType<ClickerGame>();
        currentElementIndex = PlayerPrefs.GetInt("LastActiveLocaElementIndex", 0);
        locaButton.onClick.AddListener(OnLocaButtonClick);
        ToggleLocaElement();
    }

    void OnLocaButtonClick()
    {
        int diamonds = ClickerGame.Diamonds;
        if (diamonds >= 15)
        {
            clickerGame.SubtractDiamonds(15);
            clickerGame.SaveScore();
            clickerGame.SaveDiamonds();

            PlayerPrefs.SetInt("LastActiveLocaElementIndex", currentElementIndex);
            PlayerPrefs.Save();

            if (clickSound != null)
            {
                clickSound.Play();
            }

            ToggleLocaElement();
        }
        else
        {
            Debug.Log("Недостаточно бриллиантов для переключения локации.");
        }
    }

    void ToggleLocaElement()
    {
        DisableAllLocaElements();
        string currentElement = locaElements[currentElementIndex];
        GameObject elementObject = canvasLoca.transform.Find(currentElement).gameObject;
        elementObject.SetActive(true);
        currentElementIndex++;
        if (currentElementIndex >= locaElements.Length)
        {
            currentElementIndex = 0;
        }
    }

    void DisableAllLocaElements()
    {
        foreach (string element in locaElements)
        {
            GameObject elementObject = canvasLoca.transform.Find(element).gameObject;
            elementObject.SetActive(false);
        }
    }
}