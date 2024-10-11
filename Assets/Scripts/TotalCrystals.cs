using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalCrystals : MonoBehaviour
{
    public Text TotalCryst;
    [ContextMenu("ClearGemNumberPlayerPrefs")]
    void ClearGemNumberPlayerPrefs()
    {
        PlayerPrefs.DeleteKey("GemNumber");
    }

    private void Awake()
    {
        TotalCryst.text = PlayerPrefs.GetInt("GemNumber").ToString();

    }


}
