using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    GameObject Green;
    GameObject Orange;
    GameObject Purple;
    GameObject Fire;
    private void Start()
    {
         Green = GameObject.FindWithTag("green");
         Orange = GameObject.FindWithTag("orange");
         Purple = GameObject.FindWithTag("purple");
        Fire = GameObject.FindWithTag("fire");
    }
    

    private void OnTriggerEnter2D(Collider2D target)
    {

        Debug.Log("Trigger entered");
        if (target.CompareTag("green"))
        {
            Destroy(Green);
            
        }
        else if (target.CompareTag("purple"))
        {
            Destroy(Purple);
           
        }
        else if (target.CompareTag("orange"))
        {
            Destroy(Orange);

        }
        else if (target.CompareTag("fire"))
        {
            Destroy(Fire);

        }
    }
}
