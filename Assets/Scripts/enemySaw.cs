
using UnityEngine;

public class EnemySaw : MonoBehaviour
{
    [SerializeField] private float damage;

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            HealthLast playerHealth = collision.GetComponent<HealthLast>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }


    
}
