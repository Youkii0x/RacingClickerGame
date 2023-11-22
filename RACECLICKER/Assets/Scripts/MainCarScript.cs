using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    public GameObject canvasCar;
    public Button carButton;
    public AudioSource clickSound;
    private ClickerGame clickerGame;
    public Text scoreText;

    private string[] carElements = { "BMWE30", "Eclipse", "Skyline", "Lancer", "Subarik", "Lamba" };
    private int currentElementIndex = 0;

    void Start()
    {
        clickerGame = FindObjectOfType<ClickerGame>();
        currentElementIndex = PlayerPrefs.GetInt("LastActiveElementIndex", 0);
        carButton.onClick.AddListener(OnCarButtonClick);
        ToggleCarElement();
    }

    void OnCarButtonClick()
    { 
        int score = ClickerGame.Score;
    if (score >= 2500)
    {
        clickerGame.SubtractScore(2500);
        clickerGame.SaveScore();
        clickerGame.SaveDiamonds();
        PlayerPrefs.SetInt("LastActiveElementIndex", currentElementIndex);
        PlayerPrefs.Save();

        if (clickSound != null)
        {
            clickSound.Play();
        }

        ToggleCarElement();
    }
        else
    {
    Debug.Log("Недостаточно денег для переключения машины.");
   }
 }

    void ToggleCarElement()
    {
        DisableAllCarElements();
        string currentElement = carElements[currentElementIndex];
        GameObject elementObject = canvasCar.transform.Find(currentElement).gameObject;
        elementObject.SetActive(true);
        currentElementIndex++;
        if (currentElementIndex >= carElements.Length)
        {
            currentElementIndex = 0;
        }
    }

    void DisableAllCarElements()
    {
        foreach (string element in carElements)
        {
            GameObject elementObject = canvasCar.transform.Find(element).gameObject;
            elementObject.SetActive(false);
        }
    }
}