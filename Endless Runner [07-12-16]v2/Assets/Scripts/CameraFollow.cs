using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
	void Update ()
    {
        transform.position = new Vector3(player.position.x + 6, 0, -10);
	}

    public void DisableCamera()
    {
       // this.gameObject.SetActive(false);
        this.GetComponent<CameraFollow>().enabled = false;
    }
}
