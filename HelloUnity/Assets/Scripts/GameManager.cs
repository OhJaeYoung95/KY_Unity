using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Text;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI restartText;
    public TextMeshProUGUI bestTimeText;

    private bool isGameOver = false;
    private float timer = 0f;
    private float bestScore = 0f;

    private void Start()
    {
        Time.timeScale = 1f;
        restartText.gameObject.SetActive(false);
        bestTimeText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameOver)
        {
            timer += Time.deltaTime;
            timeText.text = $"TIME : {timer:F2}";
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.R)) 
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    public void EndGame()
    {
        isGameOver = true;
        restartText.gameObject.SetActive(true);
        bestTimeText.gameObject.SetActive(true);
        Time.timeScale = 0f;

        var bestTime = PlayerPrefs.GetFloat("BestTime", 0.0f);
        if (timer > bestTime)
        {
            bestTime = timer;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        bestTimeText.text = $"Best Time : {bestTime:F2}";
    }

    public void DisplayTime()
    {
        timer += Time.deltaTime;
        StringBuilder sb = new StringBuilder();
        sb.Append("TIME : ");
        sb.Append(timer.ToString("F2"));
        timeText.text = sb.ToString();

    }
}
