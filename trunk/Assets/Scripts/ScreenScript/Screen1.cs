using UnityEngine;
using System.Collections;

public class Screen1 : MonoBehaviour {
	
	public Rect loginedRect;
	public GUISkin skin;
	GameObject Avatar;
	GameObject petBackground;
	//debug
	string debugstr = "";
	// Use this for initialization
	void Start () {
		loginedRect = new Rect(380, 60, 70, 50);
		Avatar = GameObject.Find("Avatar");
		petBackground = GameObject.Find("Pet");
		
		Service1 ser = new Service1();
		debugstr = ser.GetIP("SiuNhanDua");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI()
	{
		GUI.skin = skin;
		GUI.skin.button.fontSize = 22;
		
		if(GS.logined)
		{
			GUI.Label(loginedRect, "Hello "+ GS.username, "LabelNormal");	
			if(GUI.Button(new Rect(380, 130, 70, 40), "Logout", "ButtonGeneral"))
			{
				GS.logined = false;
			}
		}
		else
		{
			GUI.Label(loginedRect, "Hello Guest");
			if(GUI.Button(new Rect(380, 130, 70, 40), "Login", "ButtonGeneral"))
			{
					Application.LoadLevel ("Screen2");
			}
		}
		
		
		if(GUI.Button(new Rect(20, 165, 179, 40), "Play game", "ButtonGeneral"))
		{
			if(GS.logined)
			{
				GS.numberOfPet = 2;
				Application.LoadLevel("Screen7");
			}
			else
			{
				GS.showPopup = true;
			}
		}
		
		if(GS.showPopup)
		{
			GS.PopupPleaseLogin();
		}
		if(GUI.Button(new Rect(20, 215, 179, 40), "Options", "ButtonGeneral"))
		{
			Application.LoadLevel("Screen6");
		}
		
		if(GUI.Button(new Rect(20, 265, 82, 40), "Quit", "ButtonGeneral"))
		{
			Application.Quit();
		}
		if(GUI.Button(new Rect(110, 265, 89, 40), "Intro", "ButtonGeneral"))
		{
			 
		}
		
		
		if(GS.logined)
		{
			GUI.Label(new Rect(240, 195, 200, 110), "Welcome to PetFighting game, press Play game to visit your pets and take care them now!", "LabelNormal");
		}
		else
		{
			GUI.Label(new Rect(240, 195, 200, 110), "You are in log out status, please log in to play game!", "LabelNormal");
		}
		if(GS.logined)
		{
			Avatar.guiTexture.texture = (GS.avatar);
			petBackground.guiTexture.texture = skin.FindStyle("Title").normal.background;
			petBackground.guiTexture.border = skin.FindStyle("Title").border;
		}
		else
		{
			Avatar.guiTexture.texture = Resources.Load("Screen1-Nouser") as Texture2D;
			petBackground.guiTexture.texture = Resources.Load("Screen1-NoPet") as Texture2D;
			petBackground.guiTexture.border = new RectOffset(0,0,0,0);
		}
		
		//debug
		GUI.Label(new Rect(10, 10, 300, 30), debugstr);
	}
}
