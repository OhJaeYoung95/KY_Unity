using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public static GameManager Instance { get { return instance; } }

    public bool IsGameOver { get; private set; }

    public TextMeshProUGUI scoreText;
    public GameObject gameOverText;

    private int score = 0;

    // Start is called before the first frame update
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            gameOverText.SetActive(false);
        }
        else
        {
            Debug.LogWarning("GameManager instance already exists, destroying this one.");
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(IsGameOver && Input.GetMouseButtonDown(0))
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void AddScore(int newScore)
    {
        if (IsGameOver)
            return;

        score += newScore;
        scoreText.text = $"SCORE : {score}";
    }

    public void OnPlayerDead()
    {
        IsGameOver = true;
        gameOverText.SetActive(true);
    }
}
