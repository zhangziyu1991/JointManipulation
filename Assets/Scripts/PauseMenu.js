
var mainMenuSceneName : String;
//var reloadScene: String;
var pauseMenuFont : Font;
private var pauseEnabled = false;	

// #pragma strict	
var button: UI.Button;	

function Start(){
	pauseEnabled = false;
	Time.timeScale = 1;
	AudioListener.volume = 1;
	Cursor.visible = true;

	button.onClick.AddListener(TaskOnClick);
}

function Update(){

	//check if pause button (escape key) is pressed
	if(Input.GetKeyDown("escape")){
	
		//check if game is already paused		
		if(pauseEnabled == true){
			//unpause the game
			pauseEnabled = false;
			Time.timeScale = 1;
			AudioListener.volume = 1;
			Cursor.visible = true;			
		}
		
		//else if game isn't paused, then pause it
		else if(pauseEnabled == false){
			pauseEnabled = true;
			AudioListener.volume = 0;
			Time.timeScale = 0;
			Cursor.visible = true;
		}
	}
}


function TaskOnClick() {
	Debug.Log("Clicked");
	if(pauseEnabled == true){
			//unpause the game
			pauseEnabled = false;
			Time.timeScale = 1;
			AudioListener.volume = 1;
			Cursor.visible = true;			
		}
		
		//else if game isn't paused, then pause it
		else if(pauseEnabled == false){
			pauseEnabled = true;
			AudioListener.volume = 0;
			Time.timeScale = 0;
			Cursor.visible = true;
		}	
}

private var showGraphicsDropDown = false;

function OnGUI(){

GUI.skin.box.font = pauseMenuFont;
GUI.skin.button.font = pauseMenuFont;
GUI.skin.box.fontSize = 30;
GUI.skin.button.fontSize = 30;

	if(pauseEnabled == true){
		//audio.Stop();
		
		//Make a background box
		GUI.Box(Rect(Screen.width /2 - 120,Screen.height /2 - 100,250,280), "Pause Menu");


		if(GUI.Button(Rect(Screen.width /2 - 120,Screen.height /2 - 30,250,70), "Return to Play")){
			pauseEnabled = false;
			Time.timeScale = 1;
			AudioListener.volume = 1;
			Cursor.visible = true;
		}

		//Make Main Menu button
		if(GUI.Button(Rect(Screen.width /2 - 120,Screen.height /2 + 40,250,70), "Main Menu")){
			Application.LoadLevel(mainMenuSceneName);
		}
		
		
		//Make quit game button
		if (GUI.Button (Rect (Screen.width /2 - 120,Screen.height /2 + 110,250,70), "Quit Game")){
			Application.Quit();
		}
	}
}