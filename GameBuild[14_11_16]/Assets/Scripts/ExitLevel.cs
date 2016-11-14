using UnityEngine;
using UnityEngine.SceneManagement;


public class ExitLevel : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        //Check collision name
        if (col.gameObject.name == "Player")
        {
            Destroy(col.gameObject);
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);


        }
    }
}
