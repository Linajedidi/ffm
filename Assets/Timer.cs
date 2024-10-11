using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float dailyPlayTime = 30*60; 
    private float remainingTime;

    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        remainingTime = PlayerPrefs.GetFloat("RemainingPlayTime", dailyPlayTime);
    }

    public void OnApplicationQuit()
    {
        
        PlayerPrefs.SetFloat("RemainingPlayTime", remainingTime);
        PlayerPrefs.Save();
    }

    private void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 0)
        {
            remainingTime = 0;
            timerText.color = Color.yellow;

            
            Time.timeScale = 0f;
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    
    public void StartNewDay()
    {
     
        remainingTime = dailyPlayTime;

        
        Time.timeScale = 1f;
    }
}