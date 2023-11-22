using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public Image ON;
    public Image OFF;
    public Image White;
    public Image Black;
    public AudioSource clickSound;
    int index;

    private void Start()
    {
        index = PlayerPrefs.GetInt("SwitchState", 0);
        UpdateSwitchState();
    }

    private void UpdateSwitchState()
    {
        if (index == 1)
        {
            Black.gameObject.SetActive(false);
            White.gameObject.SetActive(true);
            ON.gameObject.SetActive(false);
            OFF.gameObject.SetActive(true);
        }
        else
        {
            Black.gameObject.SetActive(true);
            White.gameObject.SetActive(false);
            ON.gameObject.SetActive(true);
            OFF.gameObject.SetActive(false);
        }
    }

    public void ONN()
    {
        index = 1;
        PlayerPrefs.SetInt("SwitchState", index);
        PlayerPrefs.Save();
        UpdateSwitchState();

        if (clickSound != null)
        {
            clickSound.Play();
        }
    }

    public void OF()
    {
        index = 0;
        PlayerPrefs.SetInt("SwitchState", index);
        PlayerPrefs.Save();
        UpdateSwitchState();

        if (clickSound != null)
        {
            clickSound.Play();
        }
    }
}