using UnityEngine;
using System.Collections;

/**
 * class to control camera movement around the game world
 * camera currently pegged to player avatar movement
 * 
 * CE'18
 */
public class CameraController : MonoBehaviour {

	// instance varialbes
	public GameObject player;
	private Vector3 offset;

	// functions

	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = player.transform.position + offset;
	}
}
