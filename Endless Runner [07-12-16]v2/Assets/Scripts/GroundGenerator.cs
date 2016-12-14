using UnityEngine;
using System.Collections;

public class GroundGenerator : MonoBehaviour
{

    public GameObject ground;
    public Transform generator;
    public float groundDistance;

    private float platformWidth;

    //Generates a random distance between ground blocks.
    public float distanceMin;
    public float distanceMax;


	//object to spawn items. (pages)
	public GameObject[] item;
    public Vector3 itemY = new Vector3(0, 1, 0);
    //public float pageDistance;

    //public float pDistanceMin;
    //public float pDistanceMax;
    //public GameObject[] objectsToSpawn;
    //public GameObject spawnPoint;

    // Use this for initialization
    void Start ()
    {
        platformWidth = ground.GetComponent<BoxCollider2D>().size.x;
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Checks distance between generation point and the ground generator
        if (transform.position.x < generator.position.x)
        {
            groundDistance = Random.Range(distanceMin, distanceMax);

            transform.position = new Vector3(transform.position.x + platformWidth + groundDistance, transform.position.y, transform.position.z);

            Instantiate(ground, transform.position, transform.rotation);

            //pageDistance = Random.Range(pDistanceMin, pDistanceMax);

            //transform.position = new Vector3(transform.position.x + pageDistance, transform.position.y, transform.position.z);

            //Instantiate(item[5], transform.position + itemY, transform.rotation);



            Instantiate(item[Random.Range(0, item.Length)], transform.position + itemY, transform.rotation);
            
        }
    }
	

	 			// Help from a YouTube tutorial from GamesPlusJames.  Link included.
}
