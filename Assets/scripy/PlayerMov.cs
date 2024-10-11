
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    private Rigidbody2D rb;
    
    [SerializeField] private float speed;
    private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }
    private void Update()

    {
        float horizontale = Input.GetAxis("Horizontal");
           rb.velocity = new Vector2(horizontale * speed,rb.velocity.y);
        if ((horizontale > 0.01f))
        {
            transform.localScale = new Vector3(4.46f, 4.46f, 4.46f);
        }
        else
            transform.localScale = new Vector3(-4.46f, 4.46f, 4.46f);

        animator.SetBool("run", horizontale != 0);
        

    }
}
