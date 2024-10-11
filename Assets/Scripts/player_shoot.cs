
using UnityEngine;

public class Player_shoot : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] fireballs;
    private Animator anim;
    private player_mov playMov;
    private float cooldownTimer = Mathf.Infinity;
    private bool isGamePaused = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playMov = GetComponent<player_mov>();
    }

    private void Update()
    {
        // Check if the game is paused
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }

        // Only allow shooting when the game is not paused
        if (!isGamePaused)
        {
            // Shooting logic
            if (Input.GetKeyDown(KeyCode.P) && cooldownTimer > attackCooldown )
            {
                Attack();
                cooldownTimer = 0;
            }

            cooldownTimer += Time.deltaTime;
        }
    }

    private void Attack()
    {
        anim.SetTrigger("attack");
        // Shooting logic
        fireballs[FindFireBall()].transform.position = firepoint.position;
        fireballs[FindFireBall()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private void TogglePause()
    {
        isGamePaused = !isGamePaused;

        // Implement pause/resume logic here (e.g., show/hide pause menu, time.timeScale manipulation, etc.)
        Time.timeScale = isGamePaused ? 0f : 1f;

        // You might want to implement additional logic, such as locking/unlocking the cursor, etc.
    }
    private int FindFireBall()
    {
        for(int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}

