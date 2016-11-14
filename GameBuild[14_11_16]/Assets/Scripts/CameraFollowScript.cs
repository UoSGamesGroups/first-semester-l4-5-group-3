using UnityEngine;
using System.Collections;

public class CameraFollowScript : MonoBehaviour {

	public GameObject player; //public reference to player

	private Vector3 offset; //public variable to store offset of camera from player.

	// Use this for initialization
	void Start () 
	{
		//find the player game object by searching for the tag "player"
		player = GameObject.FindGameObjectWithTag ("Player");
	
		//offset = distance between players position and the cameras position
		offset = transform.position - player.transform.position;

	}
	
	// Update is called once per frame
	void LateUpdate () 
	{
		//set position of cameras transform to = the players + offset
		transform.position = player.transform.position + offset;

	}
}
