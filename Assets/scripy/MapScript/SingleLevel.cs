using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SingleLevel : MonoBehaviour
{
   
    // Start is called before the first frame update
    public int levelIndex;
    private int currentNum = 0;



    private void Start()
    {
        Debug.Log("LevelIndex at start  " + levelIndex);
        Debug.Log("currentNum at start " + currentNum);
    }
    public void BackButton()
    {
        SceneManager.LoadScene("MapScene");
    }
  

    public void WinButton(int _Num)
    {
        currentNum = _Num;
        Debug.Log("currentNum win buttton  " + currentNum);

        if (currentNum > PlayerPrefs.GetInt("Lv" + levelIndex))
        {
           
            PlayerPrefs.SetInt("Lv" + levelIndex, currentNum);
        }

     
        Debug.Log("Updated Score for Level " + levelIndex + ": " + PlayerPrefs.GetInt("Lv" + levelIndex));




            BackButton();
    }
}

