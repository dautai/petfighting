using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class GlobalScript : object 
{	
	//------------------------------
	public static List<PetData> petDatas;
	public static int playerID;
	public static List<PetDetail> petDetails;
	//---------------------------
	
	//variable for user
	public static bool logined = false;
	public static Texture2D avatar = Resources.Load("image24") as Texture2D;
	public static string username = "";
	public static int numberOfPet = 0;
	public static ArrayList petlist = new ArrayList();
	//variable for action
	public static bool pressAvatar = false;
	public static bool showPopup = false;
	//variable for Options
	public static float brightness = 50f;
	public static float volumn = 50f;
	public static string resolution = "480x320";	
	//14
	public static int currentPet = -1;

	
	static GlobalScript()
	{
		petDatas = null;
		playerID = -100;
		petDetails = null;
	}
public class Skill
	{
		public string symbol;
		public string name;	//phan am thanh, tam thoi chua dung
		
		
		public Skill ()
		{
		}
		
		public Skill (string symbol1, string name1)
		{
			symbol = symbol1;
			name = name1;
		}
	}	//draw avatar
	public static void DrawAvatar()
	{
		GUI.BeginGroup(new Rect(0, 0, 50, 50));
			if(GUI.Button (new Rect (0, 0, 50, 50), "", "Avatar"))
				if(pressAvatar==true)
					pressAvatar = false;
				else{
					pressAvatar = true;	
				}
			GUI.Box(new Rect(3, 3, 44, 44), GlobalScript.avatar, pressAvatar?"Avatar2":GUI.skin.box);
		GUI.EndGroup();
		Rect windowsTabs = new Rect(0, 50, 480, 270);
		
		if(pressAvatar)
		{
			GUI.Box (new Rect(50, 0, 430, 50),"", "WindowCover");
			windowsTabs = GUI.Window(0, windowsTabs, ShowAccountTabs, "", "WindowCover");
		}
	}	
	public static void ShowAccountTabs(int windowID)
	{
		GUIStyle accountBackgroundStyle = new GUIStyle(GUI.skin.box);
		accountBackgroundStyle.border = new RectOffset(2, 2, 2, 2);
		accountBackgroundStyle.normal.background = Resources.Load("Screen5-AvatarBackground") as Texture2D;
		GUI.BeginGroup(new Rect(0, 0, 400, 150), accountBackgroundStyle);
			if(GUI.Button(new Rect(10, 10, 100, 50), "Quit", "ButtonGeneral"))
		{
			Application.Quit();
		}
		GUI.EndGroup();
	}
	public static void  PopupPleaseLogin()
	{
		Rect windows = new Rect(0, 0, Screen.width, Screen.height);
		GUI.depth +=1;
		windows = GUI.Window(1, windows, DrawPopup, "", "WindowCover");
		GUI.depth-=1;
	}
	public static void DrawPopup(int windowID)
	{
		
		GUI.BeginGroup(new Rect(140, 110, 200, 100), "Notice", "MessageBackground");
		
			GUIStyle style = new GUIStyle(GUI.skin.customStyles[2]);
			GUI.Label(new Rect(10, 30, 180, 55), "You are in log out status, please log in to play game!", style);
			if(GUI.Button(new Rect(50, 70, 100, 25), "Cancel", "ButtonGeneral"))
			{
				showPopup = false;
			}
		GUI.EndGroup();
	}
	static string Label1;
	static string content1;
	public static void  PopupRegister(string Label, string content)
	{
		Rect windows = new Rect(0, 0, Screen.width, Screen.height);
		GUI.depth +=1;
		Label1 = Label;
		content1 = content;
		windows = GUI.Window(2, windows, DrawPopupRegister, "", "WindowCover");
		GUI.depth-=1;
	}		
	public static void DrawPopupRegister(int windowID)
	{
		
		GUI.BeginGroup(new Rect(140, 110, 250, 100), Label1, "MessageBackground");
		
			GUIStyle style = new GUIStyle(GUI.skin.customStyles[2]);
			GUI.Label(new Rect(10, 30, 230, 55), content1, style);
			if(GUI.Button(new Rect(50, 70, 100, 25), "OK", "ButtonGeneral"))
			{
				Application.LoadLevel("Screen2");
			}
		GUI.EndGroup();
	}
	
	public static void drawStretch(int type, Rect rect1, int value1, int valuemax, bool showValue)
	{
		string pic1;
		string pic2;
		if(type == 1)  //mana = 1
		{
			pic1 = "Screen7-StatusBar1";
			pic2 = "Screen7-StatusNum1";
		}
		else //Blood = 2
		{
			pic1 = "Screen7-StatusBar2";
			pic2 = "Screen7-StatusNum2";
		}
		GUIStyle stretchStyle = new GUIStyle(GUI.skin.customStyles[13]);
		stretchStyle.normal.background = Resources.Load(pic1) as Texture2D;
		GUI.Label(rect1, "", stretchStyle);
		int percent = value1*((int)rect1.width-4)/valuemax;
		stretchStyle.normal.background = Resources.Load(pic2) as Texture2D;
		GUI.Label(new Rect((int)rect1.x+2, (int)rect1.y+2, percent, (int)rect1.height-4), "", stretchStyle);
		if(showValue)
		{
			if(type == 1) stretchStyle.normal.textColor = Color.white;
			GUI.Label(rect1, value1.ToString() +"/"+ valuemax.ToString(), "LabelNormal");
		}
	}
	
	public static void GetPetData()
	{
		string str;
		string[] strs;
		Service1 ser = new Service1();
		str = ser.GetListPet(playerID);
		strs = str.Split(':');		
		
		
		//set pet data
		petDatas = new System.Collections.Generic.List<PetData>();
		for(int i = 0; i < strs.Length; ++i)
		{
			if(strs[i] == "")
				continue;
			PetData tPet = new PetData();
			tPet.SetData(strs[i]);
			
			petDatas.Add(tPet);
		}
		
		numberOfPet = GlobalScript.petDatas.Count;
	}
}
