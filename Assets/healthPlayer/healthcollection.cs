
using UnityEngine;
public class healthcollection : MonoBehaviour
{
    
    [SerializeField] private float healthValue;
    [SerializeField] private AudioClip collect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<HealthLast>().AddHealth(healthValue);
            gameObject.SetActive(false);
            soundManger.Instance.PlaySound(collect);

        }
    }
}
