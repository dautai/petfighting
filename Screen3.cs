using UnityEngine;
using System.Collections;

public class Screen3 : MonoBehaviour {
	
	public GUISkin skin;
	public string titleName;
	string username = "username";
	string password = "password";
	string confirmPassword = "password";
	string email = "email@domain";
	bool wrongConfirmPass = false;
	bool duplicateUsername = false;
	bool success = false;
	//debug
	string debugstr = "";
	
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void OnGUI () {
		GUI.skin = skin;
		GUI.Box(new Rect(10, 0, 460, 30), titleName, "Title");
		
		//draw Form
		GUI.BeginGroup(new Rect((Screen.width)/2-170, (Screen.height)/2-85, 340, 170));
			GUI.Label(new Rect(0, 5, 150, 40), "Username"); 
			GUI.Label(new Rect(0, 45, 150, 40), "Password");
			GUI.Label(new Rect(0, 85, 150, 40), "Confirm Password"); 
			GUI.Label(new Rect(0, 125, 150, 40), "Email");
			username = GUI.TextField(new Rect(160, 0, 160, 30), username, "TextfieldGeneral");
			password = GUI.PasswordField(new Rect(160, 40, 160, 30), password, "*"[0], "TextfieldGeneral");			
			confirmPassword = GUI.PasswordField(new Rect(160, 80, 160, 30), confirmPassword, "*"[0], "TextfieldGeneral");
			GUIStyle redLabel = new GUIStyle(GUI.skin.label);
			redLabel.normal.textColor = Color.red;
			if(wrongConfirmPass)
			{
				GUI.Label(new Rect(325, 80, 15, 30), "**", redLabel);
			}
			if(duplicateUsername)
			{
				GUI.Label(new Rect(155, 7, 15, 30), "**", redLabel);
			}
			email = GUI.TextField(new Rect(160, 120, 160, 30), email, "TextfieldGeneral");
			
		GUI.EndGroup();
		
		//draw Buttons
		GUI.BeginGroup(new Rect((Screen.width)/2-160, (Screen.height)/2+100, 320, 30));	
		{
			if(GUI.Button(new Rect(0, 0, 100, 30), "Register", "ButtonGeneral"))
			{
				if(password == confirmPassword)
				{
					Register(username, password, email);
				}
				else
				{
					wrongConfirmPass = true;
				}
			}
			if(GUI.Button(new Rect(220, 0, 100, 30), "Cancel", "ButtonGeneral"))
			{
				Application.LoadLevel ("Screen1");
			}
		}
		GUI.EndGroup();
		
		//success
		if(success)
		{
			GlobalScript.PopupRegister("Register complete! ", "Success! You can now log in.");
		}
		
		//debug
		GUI.Label(new Rect(10, 10, 100, 30), debugstr);
	}
	
	int Register(string user, string pass, string email)
	{
		int rs;
		Service1 ser = new Service1();
		rs = ser.Register(user, pass, email, "image");
		debugstr = rs.ToString();
		switch(rs)
		{
		case 1 :
			//success
			success = true;
			break;
		case 2 :
			//trung username
			duplicateUsername = true;
			break;
		case 3 :
			//het dao
			break;
		default :
			break;
		}
		return 1;
	}
}
