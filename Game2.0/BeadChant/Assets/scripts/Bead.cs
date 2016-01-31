using UnityEngine;
using System.Collections;

public class Bead : MonoBehaviour {
	DistanceJoint2D dj2d;
	public Rigidbody2D rb2d;
	public bool isActive;
	LevelManager levelManager;
	//AudioSource musicalPhrase;
	SpriteRenderer srParent;
    SpriteRenderer srChild;
	public int beadID;

	// Use this for initialization
	void Start () {
		isActive = true;
		//assign distance joint 2d to the component made in the editor
		dj2d = gameObject.GetComponent<DistanceJoint2D>();

		dj2d.enabled = false;
		//assign rigidbody2d to the rigidbody of the bead
		rb2d = gameObject.GetComponent<Rigidbody2D>();
        //sr = transform.Find("CoreBead").GetComponent<SpriteRenderer>();
		//sr = gameObject.GetComponent<SpriteRenderer>();
		levelManager = GameObject.FindGameObjectWithTag ("LevelManager").GetComponent<LevelManager>();

		//musicalPhrase = gameObject.GetComponent<AudioSource> ();
		//SetupBead ();
	
	}

	public void SetupBead(int beadNum, Sprite sprite){
		srChild = transform.Find("CoreBead").GetComponent<SpriteRenderer>();
        srParent = gameObject.GetComponent<SpriteRenderer>();
		srParent.sprite = sprite;

		float red = Random.Range (0.0f, 1.0f);
		float green = Random.Range (0.0f, 1.0f);
		float blue = Random.Range (0.0f, 1.0f);
		
		Color beadColor = new Vector4 (red, green, blue, 1.0f);
		srChild.color = beadColor;

		beadID = beadNum;

		//int beadID = Mathf.RoundToInt (Random.Range (1, 6));
		/**	
		beadID = beadNum;
		switch (beadID) {

		case 1:
			sr.color = Color.red;
			break;
		case 2:
			sr.color = Color.blue;
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
			sr.color = new Vector4(128, 0, 0, 1);
			break;
		case 7:
			sr.color = new Vector4(0, 128, 0, 1);
			break;
		case 8:
			sr.color = new Vector4(0, 128, 0, 1);
			break;
		case 9:
			sr.color = new Vector4(0, 128, 128, 1);
			break;	
		default:
			break;


		}*/

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AttachDistanceJoint(Rigidbody2D connectedRigidbody){
		dj2d.enabled = true;
		isActive = false;
		dj2d.connectedBody = connectedRigidbody;
		levelManager.PlayPhrase (beadID);


	}

	public Color GetColor(){
		return srChild.color;
	}
}
