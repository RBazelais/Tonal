using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Player : MonoBehaviour {

	public float speed = 1000.0F;
	public int maxLength;

	List<GameObject> beads = new List<GameObject>();
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
			//check if the bead is already on the string
			if(!tempBead.GetComponent<Bead>().isActive){
				return;
			}

			/**if there are no beads in the array then attach the bead to the playerand add it to the array*/
			if(beads.Count == 0){
				tempBead.GetComponent<Bead>().AttachDistanceJoint(rb2d);
				beads.Add(tempBead);
			}

			/**if there are beads in the array attach the bead the player
			 and change the rigidbody of the previous bead to the current bead */
			//if you've encountered a bead and you're not at your maxLength...
			else if(beads.Count != maxLength){
				//
				tempBead.GetComponent<Bead>().AttachDistanceJoint(rb2d);

				//Go to the last index and return 1 from that slot in thhe previousBead array
				GameObject[] previousBead = beads.GetRange(beads.Count-1, 1).ToArray();
				//
				previousBead[0].GetComponent<Bead>().AttachDistanceJoint(tempBead.GetComponent<Bead>().rb2d);
				beads.Add(tempBead);


			}else if(beads.Count == maxLength){
				//Give me the element of the first thing
				GameObject[] firstBead = beads.GetRange(0,1).ToArray();
				//
				Destroy(firstBead[0]);
				GameObject[] previousBead = beads.GetRange(beads.Count-1, 1).ToArray();
				//
				previousBead[0].GetComponent<Bead>().AttachDistanceJoint(tempBead.GetComponent<Bead>().rb2d);
				tempBead.GetComponent<Bead>().AttachDistanceJoint(rb2d);
				beads.Add(tempBead);

			}

			tempBead.GetComponent<Bead>().AttachDistanceJoint(rb2d);


		}

	}
}
