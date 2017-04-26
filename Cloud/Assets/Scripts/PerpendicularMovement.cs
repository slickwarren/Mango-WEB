using UnityEngine;
using System.Collections;

/**
 * Project: Team 1 (MangoWEB) Game Project for Software Design - CSC312, Spring 2017
 * File Name: PerpendicularMovement.cs
 * Author(s): Collin Epstein '18
 * First Release: 4/25/17
 * Description: Restricts movement of an object to the direction perpendicular to the
 * face on which it experiences a collision.
 * License: None.
 * Updates:
 */
public class PerpendicularMovement : MonoBehaviour {

	// instance variables
	private Vector3 worldVerticalAxis;
	private Vector3 localVerticalAxis;
	private Rigidbody myRb;

	public float threshold = 0.1f;

	/* Use this for initialization (auto-generated Unity comment)
	 */
	void Start () {
		myRb = GetComponent<Rigidbody> ();
		transform.hasChanged = false;
		worldVerticalAxis = new Vector3 (0f, 1f, 0f);
		updateLocalVertical ();
		changeRotationConstraint ();
	}
	
	/* Update is called once per frame (auto-generated Unity comment)
	 */
	void Update () {
		if (transform.hasChanged) {
			updateLocalVertical ();
			changeRotationConstraint ();
		}
	}

	/* function to determine which local axis on an object is parallel\
	 * to the world vertical axis - which local axis is vertical?
	 */
	void updateLocalVertical(){

		//Debug.Log ("Method Called");

		Vector3 xPerp = Vector3.Cross (worldVerticalAxis, transform.right);
		Vector3 yPerp = Vector3.Cross (worldVerticalAxis, transform.up);
		Vector3 zPerp = Vector3.Cross (worldVerticalAxis, transform.forward);

		//Debug.Log ("xMag = " + xPerp.magnitude + ", yMag = " + yPerp.magnitude + ", zMag = " + zPerp.magnitude);

		if (xPerp.magnitude <= threshold) {
			localVerticalAxis = transform.right;
			//Debug.Log ("Local vertical axis is X");
		} else if (yPerp.magnitude <= threshold) {
			localVerticalAxis = transform.up;
			//Debug.Log("Local vertical axis is Y");
		} else if (zPerp.magnitude <= threshold) {
			localVerticalAxis = transform.forward;
			//Debug.Log("Local vertical axis is Z");
		}

		transform.hasChanged = false;
	}

	void changeRotationConstraint(){
		
		myRb.constraints = RigidbodyConstraints.None;

		if (localVerticalAxis == transform.right) {
			myRb.constraints = RigidbodyConstraints.FreezeRotationX;
		} else if (localVerticalAxis == transform.up) {
			myRb.constraints = RigidbodyConstraints.FreezeRotationY;
		} else if (localVerticalAxis == transform.forward) {
			myRb.constraints = RigidbodyConstraints.FreezeRotationZ;
		}
	}
}