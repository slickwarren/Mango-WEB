using UnityEngine;
using System.Collections;

/**
 * resets object to initial position on button press
 * 
 * CE'18
 * 4/20/17
 */
public class PositionReset : MonoBehaviour {

	// instance variables
	private Vector3 initialPos;

	// Use this for initialization
	void Start () {
		initialPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.R)) {
			transform.position = initialPos;
		}
	}
}
