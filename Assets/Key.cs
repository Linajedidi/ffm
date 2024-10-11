using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Key : MonoBehaviour

{
    [SerializeField] Image keyImg;
    public bool IsPicked;
    // Start is called before the first frame update
    void Start()
    {
        keyImg.enabled = false;
        IsPicked = false;
    }

    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           
            IsPicked =true;
            Destroy(gameObject);
            keyImg.enabled = true;

        }
    }

}
