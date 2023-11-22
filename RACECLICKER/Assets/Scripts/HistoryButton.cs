using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HistoryButton : MonoBehaviour
{
    public void OnButtonClick()
    {
        SceneManager.LoadScene("HistoryCar");
    }
}
