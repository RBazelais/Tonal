using UnityEngine;
using System.Collections.Generic;
using System;

public class Player : MonoBehaviour {

	public float speed = 1000.0F;

	Stack<GameObject> beads = new Stack<GameObject>();
	Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {

		rb2d = gameObject.GetComponent<Rigidbody2D> ();

	
	
	}

	// Update is called once per frame
	void Update () {

			Vector2 dir = Vector3.zero;
			dir.y = Input.acceleration.y;
			dir.x = Input.acceleration.x;
			if (dir.sqrMagnitude > 1)
				dir.Normalize();
			
			
			rb2d.velocity = speed * dir;

	}

	void  OnTriggerEnter2D(Collider2D other){
		GameObject tempBead;
		//ifthe player encounters a bead aaddd the bead to the bead array
		//and attach the bead to the correct rigidbody
		if(other.gameObject.CompareTag("Bead")){

			tempBead = other.gameObject;
			//cjheck if the bead is already on the string
			if(!tempBead.GetComponent<Bead>().isActive){
				return;
			}

			/**if there are no beads in the array then attach the bead to the playerand add it to the array*/
			if(beads.Count == 0){
				tempBead.GetComponent<Bead>().AttachDistanceJoint(rb2d);
				beads.Push(tempBead);
			}

			/**if there are beads in the array attach the bead the player
			 and change the rigidbody of the previous bead to the current bead */
			else{
				tempBead.GetComponent<Bead>().AttachDistanceJoint(rb2d);
				beads.Peek().GetComponent<Bead>().AttachDistanceJoint(tempBead.GetComponent<Bead>().rb2d);
				beads.Push (tempBead);

			}

			tempBead.GetComponent<Bead>().AttachDistanceJoint(rb2d);


		}

	}
}
