using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    public int Respawn1;

    private int respawnCount;
    private int maxRespawns = 3;

    [SerializeField] private float damage;

    void Start()
    {
        respawnCount = 0;
    }

    void Update()
    {
        if (transform.position.y <= -20f )
        {
           
            SceneManager.LoadScene(Respawn1);
        }
     
        
    }
   
}
