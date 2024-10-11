
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool hit;
    private Animator anim;
    private BoxCollider2D box;
  private float direction;
  
   
    private void Awake()
    {
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if (hit) return;
        float MovementSpeed = speed * Time.deltaTime;
        transform.Translate(MovementSpeed,0,0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        box.enabled = false;
        anim.SetTrigger("explode");


    }
    public void SetDirection(float _direction)
    {
        direction = _direction;
        gameObject.SetActive(true);
        hit=false;
        box.enabled = true;
        
        float localScaleX = Mathf.Sign(_direction) * Mathf.Abs(transform.localScale.x);
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
