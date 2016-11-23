using UnityEngine;
using System.Collections;

public class GroundGenerator : MonoBehaviour
{

    public GameObject ground;
    public Transform generator;
    public float groundDistance;

    private float platformWidth;


	//object to spawn items.
	public GameObject item;
    public Vector3 itemY = new Vector3(0, 1, 0);

	// Use this for initialization
	void Start ()
    {
        platformWidth = ground.GetComponent<BoxCollider2D>().size.x;
	}
	
	// Update is called once per frame
	void Update ()
    {


        if (transform.position.x < generator.position.x)
        {
            transform.position = new Vector3(transform.position.x + platformWidth + groundDistance, transform.position.y, transform.position.z);

            Instantiate(ground, transform.position, transform.rotation);

            Instantiate(item, transform.position + itemY, transform.rotation);
        }
	}

}
