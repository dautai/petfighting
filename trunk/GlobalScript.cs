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

	public class Pet
	{
		public string petName;
		public int petType; //id of type in databse pettype
		public int level;
		public int[] medal; //list of IDs of table medal in database
		public int mana;
		public int maxMana;
		public int blood;
		public int maxBlood;
		public int food;
		public int maxFood;
		public int rate;
		public int XP;
		public string[] skills; //list of skill name
		public string avatar; //avatar resource file name

		public Pet ()
		{
		}
		public Pet( string petName1, int petType1, int level1, int[] medal1, int mana1, int maxMana1, int blood1, 
			int maxBlood1, int rate1, int XP1, string[] skills1, string avatar1)
		{
			petName = petName1;
			petType = petType1;
			level = level1;
			medal = medal1;
			mana = mana1;
			maxMana = maxMana1;
			blood = blood1;
			maxBlood = maxBlood1;

			rate = rate1;
			XP = XP1;
			skills = skills1;
			avatar = avatar1;
		}
	}
	static GlobalScript()
	{
		petDatas = null;
		playerID = -100;
		petDetails = null;
	}
	//draw avatar
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
