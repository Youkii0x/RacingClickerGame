using UnityEngine;
using UnityEngine.UI;

public class nextbutton : MonoBehaviour
{
    public GameObject canvasCarH;
    public Button carButtonH;
    public AudioSource clickSound;

    private string[] carElementss = { "EE30", "EECLIPSE", "SSKYLINE", "LLANCER", "SSUBARIK", "LLAMBA" };
    private int currenttElementIndex = 0;

    void Start()
    {
        currenttElementIndex = PlayerPrefs.GetInt("LastActiveElementIndex", 0);
        carButtonH.onClick.AddListener(OnCarButtonHClick);
        ToggleCareElement();
    }

    void OnCarButtonHClick()
    {
        {
            PlayerPrefs.Save(); if (clickSound != null)
            {
                clickSound.Play();
            }
            ToggleCareElement();
        }
    }

    void ToggleCareElement()
    {
        DisableAllCarElementss(); string currentElement = carElementss[currenttElementIndex];
        GameObject elementObject = canvasCarH.transform.Find(currentElement).gameObject; elementObject.SetActive(true);
        currenttElementIndex++; if (currenttElementIndex >= carElementss.Length)
        {
            currenttElementIndex = 0;
        }
    }
    void DisableAllCarElementss()
    {
        foreach (string element in carElementss)
        {
            GameObject elementObject = canvasCarH.transform.Find(element).gameObject;
            elementObject.SetActive(false);
        }
    }
}