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
	bool WrongUsername = false;
	bool success = false;
	//debug
	string debugstr = "";
	string[] avatar;
	int selectedAvatar = -1;
	
	void Start () 
	{
		avatar = new string[5];
		avatar[0] = "image15";
		avatar[1] = "image16";
		avatar[2] = "image17";
		avatar[3] = "image47";
		avatar[4] = "image52";
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void OnGUI () {
		GUI.skin = skin;
		GUI.Box(new Rect(10, 0, 460, 30), titleName, "Title");
		if(success)
		{
			GS.PopupRegister("Register complete! ", "Success! You can now log in.");
		}
		else
		{
			//draw Form
			GUI.BeginGroup(new Rect((Screen.width)/2-190, (Screen.height)/2-85, 380, 195));
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
					GUI.Label(new Rect(300, 80, 20, 30), "**", redLabel);
				}
				if(WrongUsername)
				{
					GUI.Label(new Rect(300, 0, 20, 30), "**", redLabel);
				}
				email = GUI.TextField(new Rect(160, 120, 160, 30), email, "TextfieldGeneral");
				
				GUI.Label(new Rect(0, 159, 80, 30), "Avatar");
				for(int i = 0; i<5; i++)
					{
						Texture2D av = Resources.Load(avatar[i]) as Texture2D;
						if(GUI.Button(new Rect(80+i*35, 159, 30, 30), av, "ButtonNonBackground"))
						{
							selectedAvatar = i;
						}	
					}
				GUI.Label(new Rect(265, 159, 80, 40), "Selected:");
				GUI.Box(new Rect(340, 155, 38, 38), "", "Title");
					if(selectedAvatar>-1)
						GUI.Button(new Rect(344, 159, 30, 30), Resources.Load(avatar[selectedAvatar]) as Texture2D, "ButtonNonBackground");
					
			GUI.EndGroup();
			
			//draw Buttons
			GUI.BeginGroup(new Rect((Screen.width)/2-160, (Screen.height)/2+120, 320, 30));	
			{
				if(GUI.Button(new Rect(0, 0, 100, 30), "Register", "ButtonGeneral"))
				{
					if(username.Contains("#") || username.Contains("?"))
					{
						if(password!="" && password == confirmPassword)
						{
							Register(username, password, email, avatar[selectedAvatar]);
						}
						else
						{
							wrongConfirmPass = true;
						}
					}
					else
					{
						WrongUsername = true;	
					}
				}
				if(GUI.Button(new Rect(220, 0, 100, 30), "Cancel", "ButtonGeneral"))
				{
					Application.LoadLevel ("Screen1");
				}
			}
			GUI.EndGroup();
			
		}
	}
	
	int Register(string user1, string pass1, string email1, string avatar1)
	{
		int rs;
		rs = GS.service.Register(user1, pass1, email1, avatar1);
		debugstr = rs.ToString();
		switch(rs)
		{
		case 1 :
			//success
			success = true;
			break;
		case 2 :
			//trung username
			WrongUsername = true;
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
