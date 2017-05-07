using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Project: Team 1 (MangoWEB) Game Project for Software Design - CSC312, Spring 2017
 * File Name: Rotator.cs
 * Author(s): Julian Bertini '19, Collin Epstein '18
 * First Release: 4/18/17
 * Description: Continually rotates object about its center point.
 * License: None.
 * Updates:
 * - 4/24/17 - Edit comments/code to conform to coding conventions.
 */
public class Rotator : MonoBehaviour {
	
	/** Update is called once per frame (auto-generated Unity comment)
	 * 
	 * Increment object rotation.
	 */
	void Update () {
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	}
}