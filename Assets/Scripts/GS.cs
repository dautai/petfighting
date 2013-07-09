using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class GS : object 
{	
	//------------------------------
	public static List<PetData> petDatas;
	public static int playerID;
	public static List<PetDetail> petDetails;
	public static PetData curPet
	{
		get{return petDatas[currentPet];}
	}
	
	
	//---------------------------
	
	//Service
	public static Service1 service;
	
	//variable for user
	public static bool logined = false;
	public static int idUser = 0;
	public static Texture2D avatar = Resources.Load("stopMove") as Texture2D;
	public static string username = "";
	public static int numberOfPet = 0;
	public static ArrayList petlist = new ArrayList();
	public static int money = 0;
	public static int wareHouse = 35;
	public static int currentWareHouse = 13;
	//variable for action
	public static bool pressAvatar = false;
	public static bool showPopup = false;
	//variable for Options
	public static float brightness = 50f;
	public static float volumn = 50f;
	public static string resolution = "480x320";	
	//14
	public static int currentPet = -1;
	//is fighting with another User
	
	public static bool showingItemDetail = false;
	public static Texture2D iconNewMessage;
	public static Texture2D iconFriend;
	
	static GS()
	{
		petDatas = null;
		playerID = -100;
		petDetails = null;
		service = new Service1();
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
	}	
	//draw avatar
	public static void PressAvatar()
	{
		
		Rect windowsTabs = new Rect(0, 50, 400, 200);
		
		if(pressAvatar)
		{
			Rect windows = new Rect(0, 0, Screen.width, Screen.height);
			GUI.Box(windows, "", "WindowCover");
			GUI.BeginGroup(new Rect(0, 0, 50, 50));
				if(GUI.Button (new Rect (0, 0, 50, 50),"", "Avatar"))
						pressAvatar = false;	
				GUI.Box(new Rect(3, 3, 44, 44), GS.avatar, "Avatar2");
			GUI.EndGroup();
			windowsTabs = GUI.Window(0, windowsTabs, ShowAccountTabs, "", "WindowCover");
		}
	}
	
	public static bool selectMessage = true;
	public static void ShowAccountTabs(int windowID)
	{
		GUIStyle accountBackgroundStyle = new GUIStyle(GUI.skin.box);
		accountBackgroundStyle.border = new RectOffset(2, 2, 2, 2);
		accountBackgroundStyle.normal.background = Resources.Load("Screen5-AvatarBackground") as Texture2D;
		GUI.BeginGroup(new Rect(0, 0, 400, 200), accountBackgroundStyle);
			
			iconNewMessage = Resources.Load("image13") as Texture2D;
			iconFriend = Resources.Load("image14") as Texture2D;
			
			GUI.Label(new Rect(5, 5, 40, 40), iconNewMessage);
			if(GUI.Button(new Rect(5, 5, 40, 40), "", "ButtonCover"))
			{
				selectMessage = true;
			}
			GUI.Label(new Rect(5, 50, 40, 40), iconFriend);
			if(GUI.Button(new Rect(5, 50, 40, 40), "", "ButtonCover"))
			{
				selectMessage = false;
			}
			if(selectMessage)
			{
				GUI.Box(new Rect(2, 50, 48, 148), "", "WindowCover");
			
				GUI.Label(new Rect(55, 5, 40, 40), Resources.Load("image16") as Texture2D);
				GUI.Label(new Rect(100, 5, 300, 40), "Wife has bought a ring");
				GUI.Label(new Rect(55, 55, 40, 40), Resources.Load("image15") as Texture2D);
				GUI.Label(new Rect(100, 55, 300, 40), "John had seen your house");
				GUI.Label(new Rect(55, 105, 40, 40), Resources.Load("image17") as Texture2D);
				GUI.Label(new Rect(100, 105, 300, 40), "Peter has bought a pet");
				GUI.Label(new Rect(55, 155, 40, 40), Resources.Load("image16") as Texture2D);
				GUI.Label(new Rect(100, 155, 300, 40), "wife has bought a pet");
			}
			else{
				GUI.Box(new Rect(2, 2, 48, 48), "", "WindowCover");
				GUI.Box(new Rect(2, 100, 48, 98), "", "WindowCover");
			
				GUI.Label(new Rect(55, 5, 40, 40), Resources.Load("image15") as Texture2D);
				GUI.Label(new Rect(100, 5, 125, 40), "John: 15");
				GUI.Label(new Rect(55, 55, 40, 40), Resources.Load("image16") as Texture2D);
				GUI.Label(new Rect(100, 55, 125, 40), "Marry: 17");
				GUI.Label(new Rect(225, 5, 40, 40), Resources.Load("image47") as Texture2D);
				GUI.Label(new Rect(275, 5, 125, 40), "David: 19");
				GUI.Label(new Rect(225, 55, 40, 40), Resources.Load("image17") as Texture2D);
				GUI.Label(new Rect(275, 55, 125, 40), "Peter: 6");
			}
			
			if(GUI.Button(new Rect(5, 155, 40, 40), "Quit", "ButtonGeneral"))
			{
				Application.Quit();
			}
		GUI.EndGroup();
	}
	
	public static void DrawAvatar()
	{
		GUI.BeginGroup(new Rect(0, 0, 50, 50));
			if(GUI.Button (new Rect (0, 0, 50, 50), "", "Avatar"))
					pressAvatar = true;	
			GUI.Box(new Rect(3, 3, 44, 44), GS.avatar, GUI.skin.box);
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
		
		numberOfPet = GS.petDatas.Count;
	}
	
	
	public static Vector3 drawOneWayTable(int rowOrCol, bool type, string[] array, Vector2 place, int cPx, int longPx, Vector3 valueIn, bool showOneMoreNullCell, int MaxNuCell) //type == true: scroll vertical ; if MaxNuCell = 0, pass this
	{
		int row = rowOrCol;
		int col = rowOrCol;
		int number = array.Length;
		int number1 = number;
		if(MaxNuCell<=0)
		{
			number1 = MaxNuCell;
		}
		if(type){
			if(number1%rowOrCol == 0)
			row = number1/rowOrCol;
			else row = number1/rowOrCol +1;
			
			if(showOneMoreNullCell){
				row++;
			}
		}
		else{
			if(number1%rowOrCol ==0)
			col = number1/rowOrCol; 
			else col = number1/rowOrCol +1;
			
			if(showOneMoreNullCell){
				col++;
			}
		}
		
		int selected = (int)valueIn.x;
		//Vector2 scrollViewVector = new Vector2(valueIn.y, valueIn.z);
		Vector2 scrollViewVectorOut =  new Vector2(valueIn.y, valueIn.z);
		int scrollV = 0;
		int scrollH = 0;
		int bH = row*(cPx+5)+5; //basic Height
		int bW = col*(cPx+5)+5; //basic Width
		if(type){
			scrollV = 16;
			int inH = longPx-21;
			if(bH<inH){
				row = inH/(cPx+5);
			}
			bH = inH;
		}
		else{
			scrollH = 16;
			int inW = longPx-18;
			if(bW<inW){
				col = inW/(cPx+5);
			}
			bW = inW;
		}
		
		GUI.Box(new Rect(place.x, place.y, bW+scrollV+18, bH+scrollH+21), "", "BoxGroup1");//(308, 50, 174, 192)
		if(!(col>0 && row >0)) return valueIn;
		
		//check viewLong, make sure that non error when alwayShow Slider
		//these are for view inside of scroll view
		int viewHeight = row*(cPx+5)+5;
		int viewWidth = col*(cPx+5)+5;
		if(bW>(col*(cPx+5)+5)){
			viewWidth = (bW+1);
		}
		else{
			viewWidth = (col*(cPx+5)+5);
		}
		if(bH>(row*(cPx+5)+5)){
			viewHeight = bH+1;
		}
		else{
			viewHeight = row*(cPx+5)+5;
		}
		//(bW>(col*(cPx+5)+5))?(bW+5):(col*(cPx+5)+5), (bH>(row*(cPx+5)+5))?(bH+5):(row*(cPx+5)+5)
		scrollViewVectorOut = GUI.BeginScrollView (new Rect (place.x+9, place.y+7, bW+scrollV, bH+scrollH), scrollViewVectorOut, new Rect (0, 0, viewWidth, viewHeight)); //45 is height of a movement cell	//, type?false:true, type?true:false
			int n = 0;
			for(int i=0; i<row; i++){
				for(int j = 0; j<col; j++){
					int thisCell = (i*col+j);
					Rect rectCell = new Rect(5+j*(cPx+5), 5+i*(cPx+5), cPx, cPx);
					if(n<number){	
						if(selected == thisCell){
							GUI.Box(new Rect(4+j*(cPx+5), 4+i*(cPx+5), (cPx+4), (cPx+4)), "", "Title");
						}
						else{
							GUI.Box (rectCell,"", "WindowCover");
						}
						Texture2D avatar = Resources.Load(array[thisCell])as Texture2D;
						//GUI.Label(rectCell, avatar, "LabelNormal");
						
						GUI.Label(rectCell, avatar);
						if(GUI.Button(rectCell, "", "ButtonCover")){
							selected = thisCell;
						}
					}
					else{
						if(MaxNuCell==0 || n<MaxNuCell)
							GUI.Box (rectCell,"", "WindowCover");	
					}
					n++;
				}
			}
		GUI.EndScrollView();
		
		Vector3 valueOut = new Vector3(selected, scrollViewVectorOut.x, scrollViewVectorOut.y);
		return valueOut;
	}
	
	/*
	 * 
	public static Vector3 drawOneWayTable(int rowOrCol, bool type, string[] array, Vector2 place, int cPx, int longPx, Vector3 valueIn, bool showOneMoreNullCell, int MaxNuCell) //type == true: scroll vertical 
	{
		int row = rowOrCol;
		int col = rowOrCol;
		int number = array.Length;

		if(type){
			if(number%rowOrCol == 0)
			row = number/rowOrCol;
			else row = number/rowOrCol +1;
			
			if(showOneMoreNullCell){
				row++;
			}
		}
		else{
			if(number%rowOrCol ==0)
			col = number/rowOrCol; 
			else col = number/rowOrCol +1;
			
			if(showOneMoreNullCell){
				col++;
			}
		}
		
		int selected = (int)valueIn.x;
		//Vector2 scrollViewVector = new Vector2(valueIn.y, valueIn.z);
		Vector2 scrollViewVectorOut =  new Vector2(valueIn.y, valueIn.z);
		int scrollV = 0;
		int scrollH = 0;
		int bH = row*(cPx+5)+5; //basic Height
		int bW = col*(cPx+5)+5; //basic Width
		if(type){
			scrollV = 16;
			int inH = longPx-21;
			if(bH<inH){
				row = inH/(cPx+5);
			}
			bH = inH;
		}
		else{
			scrollH = 16;
			int inW = longPx-18;
			if(bW<inW){
				col = inW/(cPx+5);
			}
			bW = inW;
		}
		
		GUI.Box(new Rect(place.x, place.y, bW+scrollV+18, bH+scrollH+21), "", "BoxGroup1");//(308, 50, 174, 192)
		if(!(col>0 && row >0)) return valueIn;
		
		//check viewLong, make sure that non error when alwayShow Slider
		//these are for view inside of scroll view
		int viewHeight = row*(cPx+5)+5;
		int viewWidth = col*(cPx+5)+5;
		if(bW>(col*(cPx+5)+5)){
			viewWidth = (bW+1);
		}
		else{
			viewWidth = (col*(cPx+5)+5);
		}
		if(bH>(row*(cPx+5)+5)){
			viewHeight = bH+1;
		}
		else{
			viewHeight = row*(cPx+5)+5;
		}
		//(bW>(col*(cPx+5)+5))?(bW+5):(col*(cPx+5)+5), (bH>(row*(cPx+5)+5))?(bH+5):(row*(cPx+5)+5)
		scrollViewVectorOut = GUI.BeginScrollView (new Rect (place.x+9, place.y+7, bW+scrollV, bH+scrollH), scrollViewVectorOut, new Rect (0, 0, viewWidth, viewHeight)); //45 is height of a movement cell	//, type?false:true, type?true:false
			int n = 0;
			for(int i=0; i<row; i++){
				for(int j = 0; j<col; j++){
					int thisCell = (i*col+j);
					Rect rectCell = new Rect(5+j*(cPx+5), 5+i*(cPx+5), cPx, cPx);
					if(n<number){	
						if(selected == thisCell){
							GUI.Box(new Rect(4+j*(cPx+5), 4+i*(cPx+5), (cPx+4), (cPx+4)), "", "Title");
						}
						else{
							GUI.Box (rectCell,"", "WindowCover");
						}
						Texture2D avatar = Resources.Load(array[thisCell])as Texture2D;
						//GUI.Label(rectCell, avatar, "LabelNormal");
						
						GUI.Label(rectCell, avatar);
						if(GUI.Button(rectCell, "", "ButtonCover")){
							selected = thisCell;
						}
					}
					else{
						GUI.Box (rectCell,"", "WindowCover");	
					}
					n++;
				}
			}
		GUI.EndScrollView();
		
		Vector3 valueOut = new Vector3(selected, scrollViewVectorOut.x, scrollViewVectorOut.y);
		return valueOut;
	}
	 * */
	
	public static Vector3 drawOneWayMap(int nuRow, string[] arrayAvatar, string[] arrayText
	, Vector2 place, int cPx, int longPx, Vector3 valueIn)
	{
		int row = nuRow;
		int col;
		int number = arrayAvatar.Length;
		
		if(number%nuRow ==0)
		col = number/nuRow; 
		else col = number/nuRow +1;
		
		int selected = (int)valueIn.x;
		//Vector2 scrollViewVector = new Vector2(valueIn.y, valueIn.z);
		Vector2 scrollViewVectorOut =  new Vector2(valueIn.y, valueIn.z);
		int scrollH = 16;
		int bH = row*(cPx+5)+5; //basic Height
		int bW = longPx-18;
		
		GUI.Box(new Rect(place.x, place.y, bW+18, bH+scrollH+21), "", "BoxGroup1");//(308, 50, 174, 192)
		if(!(col>0 && row >0)) return valueIn;
		
		//check viewLong, make sure that non error when alwayShow Slider
		//these are for view inside of scroll view
		int viewHeight = bH;
		int viewWidth;
		if(bW>(col*(cPx+5)+5)){
			viewWidth = (bW+1);
		}
		else{
			viewWidth = (col*(cPx+5)+5);
		}
		//Draw scrollview
		scrollViewVectorOut = GUI.BeginScrollView (new Rect (place.x+9, place.y+7, bW, bH+scrollH), scrollViewVectorOut, new Rect (0, 0, viewWidth, viewHeight));
			int n = 0;
			for(int i=0; i<col; i++){
				for(int j = 0; j<row; j++){
					int thisCell = (i*row+j);
					Rect rectCell = new Rect(5+i*(cPx+5), 5+j*(cPx+5), cPx, (cPx));
					if(n<number){	
						if(selected == thisCell){
							GUI.Box(new Rect(4+i*(cPx+5), 4+j*(cPx+5), (cPx+4), (cPx+4)), "", "Title");
						}
						else{
							//GUI.Box (rectCell,"", "WindowCover");
						}
						Texture2D avatar = Resources.Load(arrayAvatar[thisCell])as Texture2D;
						//GUI.Label(rectCell, avatar, "LabelNormal");
						
						GUI.BeginGroup(rectCell);
							GUI.Label(new Rect(10, 0, cPx-20, cPx-20), avatar);
							GUI.Label(new Rect(0, cPx-25, cPx, 25), arrayText[thisCell], "LabelNormal");
							if(GUI.Button(new Rect(0, 0, cPx, (cPx)), "", "ButtonCover")){
								selected = thisCell;
							}
						GUI.EndGroup();
					}
					n++;
				}
			}
		GUI.EndScrollView();
		
		Vector3 valueOut = new Vector3(selected, scrollViewVectorOut.x, scrollViewVectorOut.y);
		return valueOut;
	}
	
	public static bool showingMapDetail = false;
	public static islandUser islandUser1;
	public static islandHunt islandHunt1;
	public static islandArena islandArena1;
	public static void ShowMapDetail(int id, string islandTable)
	{
		Rect windows = new Rect(0, 0, Screen.width, Screen.height);
		GUI.Box(windows, "", "WindowCover");
		
			
			switch (islandTable)
			{
				case "userMap":
				{
					GUI.BeginGroup(new Rect(100, 50, 280, 170), "Map detail", "MessageBackground");
					//draw usermap
					Texture2D avatar = Resources.Load(islandUser1.avatar) as Texture2D;
					GUI.Label(new Rect(5, 25, 80, 80), avatar);
					GUI.Label(new Rect(90, 25, 150, 25), "Name: "+ islandUser1.name);
					GUI.Label(new Rect(90, 50, 150, 25), "Location: " + islandUser1.location.x.ToString() + ":" +islandUser1.location.y.ToString());
					GUI.Label(new Rect(90, 75, 150, 25), "Type: User's island");
					GUI.Label(new Rect(90, 100, 150, 25), "UserOwner: "+ islandUser1.userOwner);
					if(GUI.Button(new Rect(90, 135, 100, 30), "OK", "ButtonGeneral")){
						showingMapDetail = false;
					}
					GUI.EndGroup();
					break;
				}
				case "arenaMap":
				{
					GUI.BeginGroup(new Rect(100, 50, 280, 195), "Map detail", "MessageBackground");
					//draw usermap
					Texture2D avatar = Resources.Load(islandArena1.avatar) as Texture2D;
					GUI.Label(new Rect(5, 25, 80, 80), avatar);
					GUI.Label(new Rect(90, 25, 150, 25), "Name: "+ islandArena1.name);
					GUI.Label(new Rect(90, 50, 150, 25), "Location: " + islandArena1.location.x.ToString() + ":" +islandArena1.location.y.ToString());
					GUI.Label(new Rect(90, 75, 150, 25), "Type: hunting island");
					GUI.Label(new Rect(90, 100, 150, 25), "Available: "+ islandArena1.available);
					GUI.Label(new Rect(5, 125, 270, 25), "Price: "+ islandArena1.price.ToString() + " Gold | Area: "+ islandArena1.area.ToString() + " m2");
					if(GUI.Button(new Rect(90, 160, 100, 30), "OK", "ButtonGeneral")){
						showingMapDetail = false;
					}
					GUI.EndGroup();
					break;
				}
				case "huntMap":
				{
					GUI.BeginGroup(new Rect(100, 50, 280, 195), "Map detail", "MessageBackground");
					//draw usermap
					Texture2D avatar = Resources.Load(islandHunt1.avatar) as Texture2D;
					GUI.Label(new Rect(5, 25, 80, 80), avatar);
					GUI.Label(new Rect(90, 25, 150, 25), "Name: "+ islandHunt1.name);
					GUI.Label(new Rect(90, 50, 150, 25), "Location: " + islandHunt1.location.x.ToString() + ":" +islandHunt1.location.y.ToString());
					GUI.Label(new Rect(90, 75, 150, 25), "Type: hunting island");
					GUI.Label(new Rect(90, 100, 150, 25), "Resources: "+ islandHunt1.resourcePercent.ToString() + " %");
					GUI.Label(new Rect(5, 125, 270, 25), "Time Circle: "+ islandHunt1.time.ToString() + " hour(s)");
					if(GUI.Button(new Rect(90, 160, 100, 30), "OK", "ButtonGeneral")){
						showingMapDetail = false;
					}
					GUI.EndGroup();
					break;
				}
			}
		
			
		
	}
	
	public static void loadIslandUser()
	{
		islandUser1 = new islandUser("username", new Vector2(2, 3), "Dautai", "userMap");
	}
	
	public static void loadIslandHunt()
	{
		islandHunt1 = new islandHunt("username", new Vector2(2, 3), 70, 24, "huntMap");
	}
	
	public static void loadIslandArena()
	{
		islandArena1 = new islandArena("username", new Vector2(2, 3), 150, 60, "Yes", "arenaMap");
	}
	
	
	public static item item1;
	//public static Item
	public static void showItemDetail()
	{
		Rect windows = new Rect(0, 0, Screen.width, Screen.height);
		GUI.Box(windows, "", "WindowCover");
		GUI.BeginGroup(new Rect(100, 50, 280, 170), "Map detail", "MessageBackground");
		//draw usermap
			Texture2D avatar = Resources.Load(item1.avatar) as Texture2D;
			GUI.Label(new Rect(5, 25, 80, 80), avatar);
			GUI.Label(new Rect(90, 25, 150, 25), "Name: "+ item1.name);
			GUI.Label(new Rect(90, 50, 150, 25), "Value Mana: " + item1.priceSell.ToString());
			GUI.Label(new Rect(90, 75, 150, 25), "Value Blood: " + item1.valueBlood.ToString());
			GUI.Label(new Rect(10, 100, 260, 25), "Attack: " + item1.percentAttack.ToString()+ "Defence: " + item1.percentDefence.ToString());
			if(GUI.Button(new Rect(20, 135, 100, 30), "OK", "ButtonGeneral")){
				showingItemDetail = false;
			}
			if(GUI.Button(new Rect(160, 135, 100, 30), "Sell", "ButtonGeneral")){
			//Sell this item
				money += item1.priceSell;
				showingItemDetail = false;
			}
		GUI.EndGroup();
	}
	
	public static void loadItemDetail(int id)
	{
		item1 = new item("Cake", 80, 100, 20, 0, 0f, 0f, "image20");  
	}
	
}
