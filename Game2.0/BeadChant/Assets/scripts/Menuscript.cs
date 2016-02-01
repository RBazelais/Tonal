using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Menuscript : MonoBehaviour {
	
	public Canvas quitMenu;
	public Button startText;
	public Button exitText;

		//Use this for initialization
	void Start(){
		//w.e is assigned to the quitMenu var. will get the canvas component
		quitMenu = quitMenu.GetComponent<Canvas>();
		
		startText = startText.GetComponent<Button>();
		exitText = exitText.GetComponent<Button>();
		quitMenu.enabled = false;
		
	}

		//whenever we press the exit or yes button in the start menu 
	//show exit menu and disable start menu buttons

	public void ExitPress(){
		quitMenu.enabled = true;
		startText.enabled = false;
		exitText.enabled = false; 
	}

		//Don't make quit menu available to player 

	public void NoPress(){
		quitMenu.enabled = false;
		startText.enabled = true;
		exitText.enabled = true;
	}

		//When play is clicked load the first level
	public void StartLevel(){
		SceneManager.LoadScene(1);
	}

		//When in the exit menu and yes is clicked quit the game appli
	public void ExitGame(){
		Application.Quit();
	}


	
}
