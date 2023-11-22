using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class ClickerGame : MonoBehaviour
{
    public Text scoreText;
    public Text diamondText;
    public GameObject particleEffectPrefab;
    public AudioClip clickSound;
    private AudioSource audioSource;

    public static int Score { get; private set; }
    public static int Diamonds { get; private set; }

    private const string ScoreKey = "Score";
    private const string DiamondKey = "Diamonds";

    public void Start()
    {
        LoadScore();
        LoadDiamonds();
        StartCoroutine(IncrementScoreRoutine());
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.clip = clickSound;

        string lastActiveScene = PlayerPrefs.GetString("LastActiveCarScene", "");

        if (lastActiveScene == "MainMenu")
        {
            LoadCarData();
        }
        else if (lastActiveScene == "Game")
        {
            LoadLocaData();
        }
    }

    private IEnumerator IncrementScoreRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            Score += 1;
            scoreText.text = Score.ToString();
        }
    }

    public void OnButtonClick()
    {
        Score++;
        scoreText.text = Score.ToString();
        ShowParticleEffect();
        audioSource.PlayOneShot(clickSound);

        if (Score % 100 == 0)
        {
            AddDiamonds(2);
            SaveScore();
            SaveDiamonds();
        }
    }

    public void OnButton2Click()
    {
        Score += 2;
        scoreText.text = Score.ToString();
        ShowParticleEffect();
        audioSource.PlayOneShot(clickSound);

        if (Score % 100 == 0)
        {
            AddDiamonds(5);
            SaveScore();
            SaveDiamonds();
        }
    }

    public void OnButton3Click()
    {
        Score += 3;
        scoreText.text = Score.ToString();
        ShowParticleEffect();
        audioSource.PlayOneShot(clickSound);

        if (Score % 100 == 0)
        {
            AddDiamonds(8);
            SaveScore();
            SaveDiamonds();
        }
    }

    public void OnButton4Click()
    {
        Score += 4;
        scoreText.text = Score.ToString();
        ShowParticleEffect();
        audioSource.PlayOneShot(clickSound);

        if (Score % 100 == 0)
        {
            AddDiamonds(10);
            SaveScore();
            SaveDiamonds();
        }
    }

    public void OnButton5Click()
    {
        Score += 5;
        scoreText.text = Score.ToString();
        ShowParticleEffect();
        audioSource.PlayOneShot(clickSound);

        if (Score % 100 == 0)
        {
            AddDiamonds(15);
            SaveScore();
            SaveDiamonds();
        }
    }

    public void OnButton6Click()
    {
        Score += 7;
        scoreText.text = Score.ToString();
        ShowParticleEffect();
        audioSource.PlayOneShot(clickSound);

        if (Score % 100 == 0)
        {
            AddDiamonds(20);
            SaveScore();
            SaveDiamonds();
        }
    }

    private void ShowParticleEffect()
    {
        GameObject particleEffect = Instantiate(particleEffectPrefab, transform.position, Quaternion.identity);
        particleEffect.SetActive(true);
        Destroy(particleEffect, 0.5f);
    }

    public void AddDiamonds(int amount)
    {
        Diamonds += amount;
        diamondText.text = Diamonds.ToString();
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt(ScoreKey, Score);
        PlayerPrefs.Save();
    }

    public void LoadScore()
    {
        if (PlayerPrefs.HasKey(ScoreKey))
        {
            Score = PlayerPrefs.GetInt(ScoreKey);
            scoreText.text = Score.ToString();
        }
    }

    public void SubtractDiamonds(int amount)
    {
        Diamonds = Mathf.Max(Diamonds - amount, 0);
        diamondText.text = Diamonds.ToString();
    }

    public void SubtractScore(int amount)
    {
        Score = Mathf.Max(Score - amount, 0);
        scoreText.text = Score.ToString();
    }

    public void SaveDiamonds()
    {
        PlayerPrefs.SetInt(DiamondKey, Diamonds);
        PlayerPrefs.Save();
    }

    public void LoadDiamonds()
    {
        if (PlayerPrefs.HasKey(DiamondKey))
        {
            Diamonds = PlayerPrefs.GetInt(DiamondKey);
            diamondText.text = Diamonds.ToString();
        }
    }

    public void LoadCarData()
    {
        int lastActiveElementIndex = PlayerPrefs.GetInt("LastActiveCarElementIndex", 0);
    }

    public void LoadLocaData()
    {
        int lastActiveElementIndex = PlayerPrefs.GetInt("LastActiveLocaElementIndex", 0);
    }
}