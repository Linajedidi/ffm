
using UnityEngine;

public class FireBall : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }

}
