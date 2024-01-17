using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] GameObject map_n;
 
   
    public void OpenLevel()
    {

        map_n.SetActive(false);
    }
}
