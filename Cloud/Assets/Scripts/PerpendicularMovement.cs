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
 * -5/2/17 - changed world axis name to indicate constant, commented changeRotationConstraint() function
 * 		   - wrote updateAxisAngles() function, changed Update() to use that function
 */
public class PerpendicularMovement : MonoBehaviour {

	// instance variables
	private Vector3 WORLD_VERTICAL;
	private Vector3 localVerticalAxis;
	private Rigidbody myRb;

	public float threshold = 0.1f;

	/* Use this for initialization (auto-generated Unity comment)
	 */
	void Start () {
		myRb = GetComponent<Rigidbody> ();
		transform.hasChanged = false;
		WORLD_VERTICAL = new Vector3 (0f, 1f, 0f);
		updateLocalVertical ();
		changeRotationConstraint ();
	}
	
	/* Update is called once per frame (auto-generated Unity comment)
	 */
	void Update () {
		if (transform.hasChanged) {
			//updateLocalVertical ();
			//changeRotationConstraint ();
			updateAxisAngles();
		}
	}

	/* function to determine which local axis on an object is parallel\
	 * to the world vertical axis - which local axis is vertical?
	 */
	void updateLocalVertical(){

		//Debug.Log ("Method Called");

		// calculate cross-product vectors
		Vector3 xPerp = Vector3.Cross (WORLD_VERTICAL, transform.right);
		Vector3 yPerp = Vector3.Cross (WORLD_VERTICAL, transform.up);
		Vector3 zPerp = Vector3.Cross (WORLD_VERTICAL, transform.forward);

		//Debug.Log ("xMag = " + xPerp.magnitude + ", yMag = " + yPerp.magnitude + ", zMag = " + zPerp.magnitude);

		// vector with magnitude near zero is parallel to world vertical axis
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

		transform.hasChanged = false; // trip flag
	}

	/** limits object rotation to around axes within some threshold difference from the world horizontal axis
	 * 
	 * calculates angle between world vertical axis and each local axis
	 * locks rotation about local axis that isn't within threshold of perpendicular from world vertical axis
	 */
	void updateAxisAngles(){

		myRb.constraints = RigidbodyConstraints.None; // release rotation constraints

		// calculate angle between local axes and world vertical axis
		float xAngle = Mathf.Acos (Vector3.Dot (WORLD_VERTICAL, transform.right) / 
			(localVerticalAxis.magnitude * transform.right.magnitude));
		float yAngle = Mathf.Acos (Vector3.Dot (WORLD_VERTICAL, transform.up) / 
			(localVerticalAxis.magnitude * transform.up.magnitude));
		float zAngle = Mathf.Acos (Vector3.Dot (WORLD_VERTICAL, transform.forward) / 
			(localVerticalAxis.magnitude * transform.forward.magnitude));

		Debug.Log ("xAngle = " + xAngle + ", yAngle = " + yAngle + ", zAngle = " + zAngle);

		//
		if (Mathf.Abs(xAngle - (Mathf.PI / 2)) >= threshold) {
			myRb.constraints = RigidbodyConstraints.FreezeRotationX;
		}
		if (Mathf.Abs(yAngle - (Mathf.PI / 2)) >= threshold) {
			myRb.constraints = RigidbodyConstraints.FreezeRotationY;
		}
		if (Mathf.Abs(zAngle - (Mathf.PI / 2)) >= threshold) {
			myRb.constraints = RigidbodyConstraints.FreezeRotationZ;
		}

		transform.hasChanged = false; // trip flag
	}

	/** freezes rotation about local axes depending on which local axis points world vertical
	 * 
	 * reads which local axis is designated as parallel to world vertical
	 * freezes rotation around that axis and releases rotation about all other local axes
	 */
	void changeRotationConstraint(){
		
		myRb.constraints = RigidbodyConstraints.None; // release rotation constraints

		//Debug.Log ("xAngle = " + xAngle + ", yAngle = " + yAngle + ", zAngle = " + zAngle);

		if (localVerticalAxis == transform.right) {
			myRb.constraints = RigidbodyConstraints.FreezeRotationX;
		} else if (localVerticalAxis == transform.up) {
			myRb.constraints = RigidbodyConstraints.FreezeRotationY;
		} else if (localVerticalAxis == transform.forward) {
			myRb.constraints = RigidbodyConstraints.FreezeRotationZ;
		}
	}


}