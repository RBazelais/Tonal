using UnityEngine;
using System.Collections;

public class Gate : MonoBehaviour {

	LevelManager levelManager;
	SpriteRenderer sr;
	public float acceptableRange;
    AudioSource[] audioSourceArray;

	// Use this for initialization
	void Start () {
	
		levelManager = GameObject.FindGameObjectWithTag ("LevelManager").GetComponent<LevelManager>();
		sr = gameObject.GetComponent<SpriteRenderer> ();
        audioSourceArray = gameObject.GetComponents<AudioSource>();
		SetupGoal ();
	}

	void SetupGoal(){
		//int beadID = Mathf.RoundToInt (Random.Range (1, 6));
		float red = Random.Range (0.0f, 1.0f);
		float green = Random.Range (0.0f, 1.0f);
		float blue = Random.Range (0.0f, 1.0f);

		Color gateColor = new Vector4 (red, green, blue, 1.0f);
		sr.color = gateColor;

		}


	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){

		if(other.CompareTag("Player")){
			CheckColorMatch(other.gameObject);
		}  

	}

	void CheckColorMatch(GameObject player){
		Color playerColor;

		playerColor = player.GetComponent<Player>().GetColor ();
		Debug.Log ("PLAYER COLOR: " + playerColor +"\nGATE COLOR: "+sr.color);

		bool canPassGate = true;

		if(Mathf.Abs(playerColor.r - sr.color.r)>acceptableRange){
			canPassGate = false;
		}
		
		if(Mathf.Abs(playerColor.g - sr.color.g)>acceptableRange){
			canPassGate = false;
		}
		
		if(Mathf.Abs(playerColor.b - sr.color.b)>acceptableRange){
			canPassGate = false;
		}

		if (canPassGate) {
            //audioSourceArray[0].Play();
			player.GetComponent<Player>().PlayPhrase();
			//levelManager.LoadNextLevel ();
		
		} else {
            audioSourceArray[1].Play();
			player.GetComponent<Player>().DropAllNotes();
		}



	}
}
