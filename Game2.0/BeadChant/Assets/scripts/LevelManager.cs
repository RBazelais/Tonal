using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public Bead beadPrefab;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadNextLevel(){

		Application.LoadLevel (Application.loadedLevel);

	}

	public void MakeBead(){
		int positionX = Random.Range(-10, 10);
		int positionY = Random.Range(-10, 10);
		Vector2 position = new Vector2 (positionX, positionY);
		Instantiate (beadPrefab, position, Quaternion.identity);
	}
}
