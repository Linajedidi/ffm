using UnityEngine;
using UnityEngine.SceneManagement;

public class Prison: MonoBehaviour
{
    public Key key;

    // Start is called before the first frame update
    


    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && (key.IsPicked))
        {
            Debug.Log("trigger");
            Destroy(gameObject);
            SceneManager.LoadScene("YouWin5");
        }
    }
}
