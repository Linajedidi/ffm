using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystalspawn : MonoBehaviour
{
    [SerializeField] GameObject[] Crystale;
    private BoxCollider2D col;
    float x1, x2;

    private void Awake()
    {
        col = GetComponent<BoxCollider2D>();
        x1 = transform.position.x - col.bounds.size.x / 2f;
        x2 = transform.position.x + col.bounds.size.x / 2f;
    }
    private void Start()
    {
        StartCoroutine(SpawnCrys(1f));
    }
    IEnumerator SpawnCrys(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        
        Vector3 temp = transform.position;
        temp.x = Random.Range(x1,x2);
        Instantiate(Crystale[Random.Range(0,Crystale.Length)],temp, Quaternion.identity);
        StartCoroutine(SpawnCrys(Random.Range(1f,2f))); 
    }
    



}
