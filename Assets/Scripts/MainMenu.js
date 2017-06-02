
var Arcade : String;
var Classic : String;
var HelpPage : String;
var MainMenuFont : Font;



function OnGUI(){

GUI.skin.box.font = MainMenuFont;
GUI.skin.button.font = MainMenuFont;
GUI.skin.box.fontSize = 40;
GUI.skin.button.fontSize = 40;

	if (true) {
		
		//Make a background box
		GUI.Box(Rect(Screen.width/2 - 250,Screen.height/2 - 80,500,400), "Main Menu");


		if(GUI.Button(Rect(Screen.width/2 - 250,Screen.height/2 ,500,80), "Classic Mode")){
			Application.LoadLevel(Classic);
		}

		//Make Main Menu button
		if(GUI.Button(Rect(Screen.width/2 - 250,Screen.height/2 + 80,500,80), "Arcade Mode")){
			Application.LoadLevel(Arcade);
		}
		
		if (GUI.Button (Rect (Screen.width/2 - 250,Screen.height/2 + 160,500,80), "Help")){
			Application.LoadLevel(HelpPage);
		}

		//Make quit game button
		if (GUI.Button (Rect (Screen.width/2 - 250,Screen.height/2 + 240,500,80), "Quit Game")){
			Application.Quit();
		}
	}
}
