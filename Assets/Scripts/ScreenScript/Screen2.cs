using UnityEngine;
using System.Collections;

public class Screen2 : MonoBehaviour {
	
	public GUISkin skin;
	public string titleName;
	string username = "SiuNhanDua";
	string password = "password";
	bool showerror = false;
	string ip = "-1";
	int id;
	bool isfindip = false;
	//debug
	string debugstr = "";

	void Start () 
	{	
		
	}
	
	void Update () 
	{	
		if(ip != "-1")
		{
			Service1 ser;
			ser = new Service1();

			id = ser.LogIn(username, password, ip);
			
			ip = "-1";
			if(id > 0)
			{
				GetAllPlayerData();
				Application.LoadLevel("Screen1");
			}
			else
			{
				showerror  = true;
			}
		}
	}
	
	void OnGUI () 
	{
		GUI.skin = skin;
		
//		GUILayout.BeginArea (new Rect (100, 50, Screen.width-200, Screen.height-100));
//		GUILayout.Button ("I am a regular Automatic Layout Button");
//		GUILayout.Button ("My width has been overridden", GUILayout.Width (95));
//		GUILayout.EndArea ();
		
		//draw title
		GUI.Box(new Rect(10, 0, 460, 30), titleName, "Title");
		
		GUI.BeginGroup(new Rect((Screen.width)/2-125, (Screen.height)/2-50, 250, 100));
			GUI.Label(new Rect(0, 5, 80, 40), "Username"); 
			GUI.Label(new Rect(0, 45, 80, 40), "Password");
			username = GUI.TextField(new Rect(90, 0, 160, 30), username, "TextfieldGeneral");
			password = GUI.PasswordField(new Rect(90, 40, 160, 30), password, "*"[0], "TextfieldGeneral");
		GUI.EndGroup();
		
		if(showerror)
		{
			//out error
			GUIStyle st = new GUIStyle(GUI.skin.label);
			st.normal.textColor = Color.red;
			st.alignment = TextAnchor.MiddleCenter;
			GUI.Label(new Rect((Screen.width)/2-125, (Screen.height)/2+30, 250, 30), "Wrong username or password", st);
		}
		
		GUI.BeginGroup(new Rect((Screen.width)/2-160, (Screen.height)/2+70, 320, 30));	
			if(GUI.Button(new Rect(0, 0, 100, 30), "Login", "ButtonGeneral"))
			{
				Login(username, password);
			}
			if(GUI.Button(new Rect(110, 0, 100, 30), "Register", "ButtonGeneral"))
			{
				
				Application.LoadLevel("Screen3");
			}
			if(GUI.Button(new Rect(220, 0, 100, 30), "Cancel", "ButtonGeneral"))
			{
				Application.LoadLevel ("Screen1");
			}
		GUI.EndGroup();
		//debug
		GUI.Label(new Rect(10, 10, 1000, 430), debugstr);
	}
	
	void Login(string username, string pass)
	{
		//GlobalScript.logined = true;
		//GlobalScript.avatar = Resources.Load("image3") as Texture2D;
		//GlobalScript.username = username;
		//Application.LoadLevel("Screen1");
				
		StartCoroutine(getIP());
	}
	
	IEnumerator getIP()
	{
		WWW myExtIPWWW = new WWW("http://checkip.dyndns.org");
		if (myExtIPWWW != null)
		{
			yield return myExtIPWWW;
			ip = myExtIPWWW.text;
			ip = ip.Substring (ip.IndexOf (":") + 2);
			ip = ip.Substring (0, ip.IndexOf ("<"));
		}
		else
		{
			ip = "error1";
		}
	}
	
	public void GetAllPlayerData()
	{
		GS.logined = true;
		GS.username = username;
		GS.playerID = id;
		
		GS.GetPetData();		
		
		Service1 ser  = new Service1();
		//pet detail
		string tStr2 = ser.GetAllPetDetail();
		string[] strPetDetails = tStr2.Split('+');
		GS.petDetails = new System.Collections.Generic.List<PetDetail>();

		for(int i = 0; i < strPetDetails.Length; ++i)
		{
			if(strPetDetails[i] == "")
				continue;
			PetDetail tPet = new PetDetail();
			tPet.SetData(strPetDetails[i]);
			GS.petDetails.Add(tPet);
		}

		
		debugstr = tStr2 + '{' + GS.petDetails.Count.ToString();
	}
}
