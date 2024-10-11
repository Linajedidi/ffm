using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using System.Drawing;

public class LevelSlection : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private bool Unlocked;
    public Image unlockedImage;
    public RectTransform Player;
    public RectTransform point;

  

    private void Update()
    {
       UpdateLevelImage();

        UpdateLevel();
    }
  

    private void UpdateLevel() {
        
         int PerviousLevelNum = int.Parse(gameObject.name)-1;

     

        if (PlayerPrefs.GetInt("Lv" + PerviousLevelNum) > 0 && PlayerPrefs.GetInt("Lv" + PerviousLevelNum) < 4)
        {
            Player.anchoredPosition = point.anchoredPosition;
            //PlayerPrefs.DeleteAll();
            Unlocked = true;

        }
        if (PlayerPrefs.GetInt("Lv" + PerviousLevelNum) == 4)
        {
            if (PlayerPrefs.GetInt("GemNumber") >= 50)
            {
                Player.anchoredPosition = point.anchoredPosition;
                Unlocked = true;
            }
            else
            {
                Unlocked = false;
            }
        }
       /* if (PerviousLevelNum == 5)
        {
            if (PlayerPrefs.GetInt("GemNumber") == 50)
            {
                Unlocked = true;
            }
            else
            {
                Unlocked = false;
            }
        }*/


    }
   
   

    private void UpdateLevelImage()
    {
        if (!Unlocked ) { 
            unlockedImage.gameObject.SetActive(true);
        }
        else
        {
            unlockedImage.gameObject.SetActive(false);
        }
    }
    public void PressSelection(string _LeveLName)
    {
        if(Unlocked)
        {
            SceneManager.LoadScene(_LeveLName);
            

        }
    }

}
