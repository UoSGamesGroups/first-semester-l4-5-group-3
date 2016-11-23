using UnityEngine;
using System.Collections;

public class GroundGenerator : MonoBehaviour
{

    public GameObject ground;
    public Transform generator;
    public float groundDistance;

    private float platformWidth;

    public float groundDistanceMin;
    public float groundDistanceMax;

    //public ObjectPooling objectPool;

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
            groundDistance = Random.Range(groundDistanceMin, groundDistanceMax);

            transform.position = new Vector3(transform.position.x + platformWidth + groundDistance, transform.position.y, transform.position.z);

            Instantiate(ground, transform.position, transform.rotation);
            //GameObject newGround = objectPool.GetObjectPool();

            //newGround.transform.position = transform.position;
            //newGround.transform.rotation = transform.rotation;
            //newGround.SetActive(true);
        }
	}
}
