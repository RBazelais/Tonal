using UnityEngine;
using System.Collections;

public class Bead : MonoBehaviour {
	DistanceJoint2D dj2d;
	public Rigidbody2D rb2d;
	public bool isActive;
	AudioSource musicalPhrase;
	SpriteRenderer sr;


	// Use this for initialization
	void Start () {
		isActive = true;
		//assign distance joint 2d to the component made in the editor
		dj2d = gameObject.GetComponent<DistanceJoint2D> ();
		dj2d.enabled = false;
		//assign rigidbody2d to the rigidbody of the bead
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		sr = gameObject.GetComponent<SpriteRenderer> ();
		musicalPhrase = gameObject.GetComponent<AudioSource> ();
		SetupBead ();
	
	}

	public void SetupBead(){
	
		int beadID = Mathf.RoundToInt (Random.Range (1, 6));
			
		switch (beadID) {

		case 1:
			sr.color = Color.blue;
			break;
		case 2:
			sr.color = Color.red;
			break;
		case 3:
			sr.color = Color.green;
			break;
		case 4:
			sr.color = Color.cyan;
			break;
		case 5:
			sr.color = Color.yellow;
			break;
		case 6:
			sr.color = Color.magenta;
			break;
		case 7:
			break;
		case 8:
			break;
		case 9:
			break;
		case 10:
			break;
		case 11:
			break;
		case 12:
			break;
	
		default:
			break;
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AttachDistanceJoint(Rigidbody2D connectedRigidbody){
		dj2d.enabled = true;
		isActive = false;
		dj2d.connectedBody = connectedRigidbody;
		musicalPhrase.Play ();
		//Handheld.Vibrate ();


	}

	public Color GetColor(){
		return sr.color;
	}
}
