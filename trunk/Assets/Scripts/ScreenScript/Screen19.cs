using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Screen19 : MonoBehaviour {
	
	public GUISkin skin;
	public string titleName;
	public Texture2D iconScene;
	
	Vector2 scrollViewVector = Vector2.zero;
	Vector2 scrollTimeline = Vector2.zero;
	string[] movement;
	List<string> timeline;
	
	Texture2D buttonLoop;
	Texture2D buttonLoopCheck;
	bool loop = false; //set that this skill isLoop
	bool isPlaying =false;
	int selectingMovement = 0;
	int selectingTimeline = -1;
	bool showingDetail = false;
	float totalTime = 0;
	int totalMana = 0;
	int totalEnegy = 0;
	
	// Use this for initialization
	void Start () {
		titleName = "Lika: Create Skill, Step 2"; //get name of the current pet
		iconScene = Resources.Load("image5") as Texture2D; // Load avatar of pet
		movement = new string[15];
		movement[0] = "stopMove";
		movement[1] = "Screen19-Top";
		movement[2] = "Screen19-Down";
		movement[3] = "Screen19-Left";
		movement[4] = "Screen19-Right";
		movement[5] = "image34";
		movement[6] = "image32";
		movement[7] = "image37";
		movement[8] = "image33";
		movement[9] = "image36";
		movement[10] = "image38";
		movement[11] = "image35";
		movement[12] = "image39";
		movement[13] = "image29";
		movement[14] = "image29";
		timeline = new List<string>();
		buttonLoop = Resources.Load("Loop") as Texture2D;
		buttonLoopCheck = Resources.Load("image50") as Texture2D;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI()
	{
		GUI.skin = skin;
		if(!showingDetail)
		{
			if(!GS.pressAvatar)
			{
				GUI.Box(new Rect(55, 0, 370, 30), titleName, "Title");
				GUI.Label(new Rect(430, 0, 50, 50), iconScene, "LabelNormal");
				GS.DrawAvatar();
				
				//draw table
				Vector3 valueIn = new Vector3(selectingMovement,scrollViewVector.x, scrollViewVector.y);
				valueIn = GS.drawOneWayTable(3, true, movement, new Vector2(308, 50), 40, 190, valueIn, false, 0);
				selectingMovement = (int)valueIn.x;
				scrollViewVector.x = valueIn.y;
				scrollViewVector.y = valueIn.z;
					
				//finish table	
				if(GUI.Button(new Rect(322, 285, 60, 30), "Back", "ButtonGeneral"))
				{
					Application.LoadLevel("Screen18");
				}
				if(GUI.Button(new Rect(415, 285, 60, 30), "Next", "ButtonGeneral"))
				{
					Application.LoadLevel("Screen20");	
				}
				
				GUI.Box(new Rect(-5, 50, 320, 200), "put camera pet 3D to play animation skill here", "BoxGroup2");
				GUI.Label(new Rect(5, 240, 300, 30), "Time: "+totalTime+"; Mana: "+totalMana+"; Enegy: "+ totalEnegy);
				if(!isPlaying)
				{
					if(GUI.Button(new Rect(140, 145, 40, 40), "", "ButtonCommand"))
					{
						isPlaying = true;
					}
				}
				else //PLAY ANIIMATION
				{
					if(GUI.Button(new Rect(14, 60, 292, 164), ""))
					{
						isPlaying = false;
					}
				}
				
				GUI.Label(new Rect(100, 70, 150, 30), "SelectingM = " + selectingMovement.ToString());
				GUI.Label(new Rect(100, 100, 150, 30), "SelectingT = " + selectingTimeline.ToString());
				//draw button
				if(GUI.Button(new Rect(310, 233, 40, 40), "",  "ButtonAdd"))
				{
					totalEnegy++;
					totalMana++;
					totalTime++;
					//add movement to timeline
					pressAddButton();
				}
				if(GUI.Button(new Rect(353, 235, 40, 40), "", "ButtonStop"))
				{
					if(selectingTimeline!=-1)
					{
						timeline.RemoveAt(selectingTimeline);
						selectingTimeline--;
					}
				}
				GUI.Label(new Rect(393, 235, 51, 40), buttonLoop);
				if(GUI.Button(new Rect(393, 235, 51, 40), "", "ButtonCover")){
					if(loop){
						loop = false;
					}
					else{
						loop = true;
					}
				}
				if(loop){
					GUI.Label(new Rect(393, 230, 51, 40), buttonLoopCheck, "LabelNormal");
				}
				
				if(GUI.Button(new Rect(444, 237, 36, 36), "",  "buttonMore"))
				{
					//Show more detail
					if(selectingMovement!=-1)
						getMovementDetail(selectingMovement);
						showingDetail = true;
				}
				
				Vector3 valueInTimeline = new Vector3(selectingTimeline, scrollTimeline.x, scrollTimeline.y);
				valueInTimeline = GS.drawOneWayTable(1, false, timeline.ToArray(), new Vector2(-5, 240), 40, 320, valueInTimeline, true, 0); 
				/////valueIn = GS.drawTable(((int)nuMovment/3) + 1, 3, true, movement, new Vector2(308, 50), 40, 205, valueIn);
				selectingTimeline = (int)valueInTimeline.x;
				scrollTimeline.x = valueInTimeline.y;
				scrollTimeline.y = valueInTimeline.z;
			}
			else{
				GS.PressAvatar();
			}
		}
		else{
			
			showMovementDetail();
		}
	}
	
	void pressAddButton()
	{
		//selectingTimeline = selectingMovement;
		timeline.Add(movement[selectingMovement]);
	}
	
	Movement movement1;
	void getMovementDetail(int id){
		movement1 = new Movement("movement", "Attack", 10, 15, 0.5f, "image34");
	}
	
	void showMovementDetail()
	{
		Rect windows = new Rect(0, 0, Screen.width, Screen.height);
		GUI.Box(windows, "", "WindowCover");
		GUI.BeginGroup(new Rect(100, 50, 280, 195), "Movement detail", "MessageBackground");
		//draw usermap
		Texture2D avatar = Resources.Load(movement1.avatar) as Texture2D;
		GUI.Label(new Rect(5, 25, 80, 80), avatar);
		GUI.Label(new Rect(90, 25, 150, 25), "Name: "+ movement1.name);
		GUI.Label(new Rect(90, 50, 150, 25), "Type: " + movement1.typeMove);
		GUI.Label(new Rect(90, 75, 150, 25), "Cost mana: "+ movement1.manaCost.ToString());
		GUI.Label(new Rect(90, 100, 150, 25), "Energy: "+ movement1.energy.ToString());
		GUI.Label(new Rect(5, 125, 270, 25), "Time happen: "+ movement1.timeHappen.ToString() + " second(s)");
		if(GUI.Button(new Rect(90, 160, 100, 30), "OK", "ButtonGeneral")){
			showingDetail = false;
		}
		GUI.EndGroup();
	}
}
