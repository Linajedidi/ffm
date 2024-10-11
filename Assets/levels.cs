using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class levels : MonoBehaviour
{

    public Button[] buttons;
    public GameObject lockImg;
    public Text TotalCryst;


    [ContextMenu("ClearGemNumberPlayerPrefs")]
    void ClearGemNumberPlayerPrefs()
    {
        PlayerPrefs.DeleteKey("GemNumber");
    }

    private void Awake()
    {
        //PlayerPrefs.DeleteAll();
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        TotalCryst.text = PlayerPrefs.GetInt("GemNumber").ToString();
       
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
            lockImg.SetActive(true);

        }
        for (int i = 0; i < unlockedLevel; i++)
        {
            buttons[i].interactable = true;
            ActivateChild(i + 1);


        }
    }
    public void openlevel(int levelId)
    {
        string levelName = "Level" + levelId;
        SceneManager.LoadScene(levelName);
    }
    void ActivateChild(int index)
    {
        string childName = "Lock" + index;
        Transform child = lockImg.transform.Find(childName);
        if (child != null)
        {
            child.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning("NotFound");
        }
    }

}
