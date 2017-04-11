using UnityEngine;
using System.Collections;

/**
 * class to control player avatar movement around the game world
 * 
 * CE'18
 */
public class PlayerController : MonoBehaviour {

	// instance variables
	public float speed = 5.0f;


	// functions

	// Use this for initialization
	void Start () {
	
	}


	// Update is called once per frame
	void Update () {

		// move right
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Translate (new Vector3 (speed * Time.deltaTime, 0f, 0f));
		}
		// move left
		if (Input.GetKey (KeyCode.LeftArrow)) { 
			transform.Translate (new Vector3 (-speed * Time.deltaTime, 0f, 0f));
		}
		// move 'up' - away from camera
		if (Input.GetKey (KeyCode.UpArrow)) { 
			transform.Translate (new Vector3 (0f, 0f, speed * Time.deltaTime));
		}
		// move 'down' - away from camera
		if (Input.GetKey (KeyCode.DownArrow)) {
			transform.Translate (new Vector3 (0f, 0f, -speed * Time.deltaTime));
		}
	}
}
