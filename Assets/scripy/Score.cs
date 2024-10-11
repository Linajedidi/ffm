using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Security.Cryptography;

public class Score : MonoBehaviour
{
    [SerializeField] private float damage;

    private TextMeshProUGUI ScoreText;
    private TextMeshProUGUI ScoreText1;
    private TextMeshProUGUI ScoreText2;
    private int Score1 = 0;
    private int Score2 = 0;
    private int Score3 = 0;
    private int GemNumber = 0;

    private string winSceneName = "YouWin4";  // Set the name of the win scene
    private string Lose_Scene = "YouLose";
    public int maxscore;

    // Start is called before the first frame update
    void Awake()
    {
        ScoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        ScoreText1 = GameObject.Find("ScoreText1").GetComponent<TextMeshProUGUI>();
        ScoreText2 = GameObject.Find("ScoreText2").GetComponent<TextMeshProUGUI>();
        ScoreText.text = "0";
        ScoreText1.text = "0";
        ScoreText2.text = "0";
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
       
        Debug.Log("Trigger entered");
        if (target.CompareTag("green"))
        {
            Debug.Log("Green Crystal collected");
            target.gameObject.SetActive(false);
            Score1++;
            ScoreText.text = Score1.ToString();
            CheckWinCondition();
        }
        else if (target.CompareTag("purple"))
        {
            Debug.Log("Purple Crystal collected");
            target.gameObject.SetActive(false);
            Score2++;
            ScoreText1.text = Score2.ToString();
            CheckWinCondition();
        }
        else if (target.CompareTag("orange"))
        {
            Debug.Log("Orange Crystal collected");
            target.gameObject.SetActive(false);
            Score3++;
            ScoreText2.text = Score3.ToString();
            CheckWinCondition();
        }
    }

    private void CheckWinCondition()
    {
        if (Score1 >= maxscore && Score2 >= maxscore && Score3 >= maxscore)
        {
            GemNumber = 10;
            Debug.Log("Player wins!");
            var oldScore = PlayerPrefs.GetInt("GemNumber", 0);
            PlayerPrefs.SetInt("GemNumber", oldScore + GemNumber);
            SceneManager.LoadScene(winSceneName);  // Load the win scene
        }
    }
}
