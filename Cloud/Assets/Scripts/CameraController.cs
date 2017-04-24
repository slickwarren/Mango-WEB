using UnityEngine;
using System.Collections;

/**
 * Project: Team 1 (MangoWEB) Game Project for Software Design - CSC312, Spring 2017
 * File Name: CameraController.cs
 * Author(s): Collin Epstein '18
 * First Release: 4/2/17
 * Description: Controls camera movement around the game world - currently pegged to
 * player avatar movement.
 * License: None.
 * Updates:
 * - 4/24/17 - Edit comments/code to conform to coding conventions.
 */
public class CameraController : MonoBehaviour {

	// instance variables
	public GameObject player;
	private Vector3 offset;

	/** Use this for initialization (auto-generated Unity comment)
	 * 
	 * Calculates and saves the camera position offset based on the initial positions
	 * of the camera and the player avatar.
	 */
	void Start () {
		offset = transform.position - player.transform.position;
	}
	
	/** Update is called once per frame (auto-generated Unity comment)
	 * 
	 * Calculates and updates the new camera position once per frame.
	 * Camera is updated last, so all objects are in correct positions
	 * when frame is computed and displayed.
	 */
	void LateUpdate () {
		transform.position = player.transform.position + offset;
	}
}