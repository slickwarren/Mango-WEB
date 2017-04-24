using UnityEngine;
using System.Collections;

/**
 * Project: Team 1 (MangoWEB) Game Project for Software Design - CSC312, Spring 2017
 * File Name: PositionReset.cs
 * Author(s): Collin Epstein '18
 * First Release: 4/20/17
 * Description: Resets object to initial position on button press.
 * License: None.
 * Updates:
 * - 4/24/17 - Edit comments/code to conform to coding conventions.
 */
public class PositionReset : MonoBehaviour {

	// instance variables
	private Vector3 initialPos;

	/** Use this for initialization (auto-generated Unity comment)
	 * 
	 * Saves the initial position of the object.
	 */
	void Start () {
		initialPos = transform.position;
	}
	
	/** Update is called once per frame (auto-generated Unity comment)
	 * 
	 * On button press, return object to its initial position.
	 * For testing purposes, button is currently 'R' key on keyboard.
	 */
	void Update () {
		if (Input.GetKey (KeyCode.R)) {
			transform.position = initialPos;
		}
	}
}