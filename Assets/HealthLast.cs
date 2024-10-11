using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthLast : MonoBehaviour
{
    [SerializeField] private float stratingHealth;
    public float Currenthealth { get; private set; }
    private Animator anim;
    private bool dead;
    private string Lose_Scene = "YouLose";



    // Start is called before the first frame update
    private void Awake()
    {
        Currenthealth = stratingHealth;
        anim = GetComponent<Animator>();

    }
    public void TakeDamage(float _damage)
    {
        Currenthealth = Mathf.Clamp(Currenthealth - _damage, 0, stratingHealth);
        if (Currenthealth > 0)
        {
            anim.SetTrigger("hurt");

        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("die");
                GetComponent<player_mov>().enabled = false;
                dead = true;
                SceneManager.LoadScene(Lose_Scene);
            }
        }


    }
    public void AddHealth(float _value)
    {
        Currenthealth= Mathf.Clamp(Currenthealth + _value , 0, stratingHealth);
    }



}