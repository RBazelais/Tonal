using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

	public Bead beadPrefab;
	AudioSource[] audioSourceArray;
	public Sprite[] sprites;
	int horizontalMax = 100;
	int horizontalMin = -100;
	int verticalMax = 60;
	int verticalMin = -60;
	public int totalBeads;
	bool levelStarted = false;

	// Use this for initialization
	void Start () {
		audioSourceArray = gameObject.GetComponents<AudioSource>();
		//SetupLevel ();
	}
	
	// Update is called once per frame
	void Update () {

		if (!levelStarted) {
			levelStarted = true;
			SetupLevel ();
		}
	
	}


	public void SetupLevel(){

		for (int i=0; i<totalBeads; i++) {
			
			MakeBead();
				
		}
		
	}

	public void LoadNextLevel(){


		SceneManager.LoadScene ("Level2");

	}

	public void MakeBead(){
		int positionX = Random.Range(horizontalMin, horizontalMax);
		int positionY = Random.Range(verticalMin, verticalMax);
		Vector2 position = new Vector2 (positionX, positionY);
		Bead newBead = Instantiate (beadPrefab, position, Quaternion.identity) as Bead;


		int beadNum = Mathf.RoundToInt (Random.Range (1, 9));
		Debug.Log ("Bead number:" + beadNum);
		newBead.SetupBead (beadNum, sprites[beadNum-1]);

	}

	public void PlayPhrase(int phraseNumber){
		audioSourceArray[phraseNumber].Play ();
	}

	public void PlaySong(int[] audioClips){
		
		for(int i = 0; i<audioClips.Length; i++){
			audioSourceArray[audioClips [i]].Play();
			StartCoroutine(FinishClip());

		}


		LoadNextLevel ();
		

	}

	IEnumerator FinishClip(){
		
		yield return new WaitForSeconds (3.62f);


	}

	public Sprite GetSprite(int spriteNum){
		return sprites [spriteNum - 1];
	}
}
