using UnityEngine;
using System.Collections;

public class RepeatingBackground : MonoBehaviour
{

    public float speed;

	void Update ()
    {
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(Time.time * speed, 0);
	}
}
