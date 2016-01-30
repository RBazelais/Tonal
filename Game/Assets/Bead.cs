using UnityEngine;
using System.Collections;

public class Bead : MonoBehaviour {
	DistanceJoint2D dj2d;
	public Rigidbody2D rb2d;
	public bool isActive;

	// Use this for initialization
	void Start () {
		isActive = true;
		//assign distance joint 2d to the component made in the editor
		dj2d = gameObject.GetComponent<DistanceJoint2D> ();
		dj2d.enabled = false;
		//assign rigidbody2d to the rigidbody of the bead
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AttachDistanceJoint(Rigidbody2D connectedRigidbody){
		dj2d.enabled = true;
		isActive = false;
		dj2d.connectedBody = connectedRigidbody;


	}
}
