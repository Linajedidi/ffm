using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddButtons : MonoBehaviour
{
    [SerializeField]
    public Transform puzzleField;
    [SerializeField]
    private GameObject btn;
    public int nb; 
    
    private void Awake()
    {
        for (int i = 0; i < nb; i++) {
            GameObject button = Instantiate(btn);
            button.name = "" + i; 
            button.transform.SetParent(puzzleField);
        }    
        
    }
}
