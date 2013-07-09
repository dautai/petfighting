using UnityEngine;
using System.Collections;

public class Screen20 : MonoBehaviour {
	
	public GUISkin skin;
	public string titleName;
	public Texture2D iconScene;
	
	string petname = "";
	string[] avatar;
	int selected = -1;
	int volumn = 100;
	// Use this for initialization
	void Start () {
		titleName = "Lika: Create Skill, Step 1"; //get name of the current pet
		iconScene = Resources.Load("image5") as Texture2D; // Load avatar of pet
		avatar = new string[5];
		avatar[0] = "image28";
		avatar[1] = "image29";
		avatar[2] = "image291";
		avatar[3] = "image30";
		avatar[4] = "noel";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI()
	{
		GUI.skin = skin;
		GUI.Box(new Rect(55, 0, 370, 30), titleName, "Title");
		GUI.Label(new Rect(430, 0, 50, 50), iconScene, "LabelNormal");
		if(!GS.pressAvatar)
		{
			GS.DrawAvatar();
			
			GUI.BeginGroup(new Rect(20, 0, 460, 270));
				GUI.Label(new Rect(10, 60, 80, 40), "Name:"); 
				GUI.Label(new Rect(10, 105, 80, 40), "Symbol");
				petname = GUI.TextField(new Rect(100, 60, 260, 30), petname, "TextfieldGeneral");
				for(int i = 0; i<5; i++)
				{
					Texture2D av = Resources.Load(avatar[i]) as Texture2D;
					if(GUI.Button(new Rect(100+i*35, 105, 30, 30), av, "ButtonNonBackground"))
					{
						selected = i;
					}	
				}
				GUI.Label(new Rect(295, 105, 80, 40), "Selected:");
				GUI.Box(new Rect(371, 101, 38, 38), "", "Title");
				if(selected>-1)
					GUI.Button(new Rect(375, 105, 30, 30), Resources.Load(avatar[selected]) as Texture2D, "ButtonNonBackground");
				
				//record
				GUI.Label(new Rect(0, 140, 440, 30), "Record the voice command to call this skill", "LabelNormal");
				GUI.Button(new Rect(180, 175, 80, 30), "Record", "ButtonGeneral");
				GUI.Box(new Rect(20, 215, 380, 38), "", "Title");
				GUIStyle stretchStyle = new GUIStyle(GUI.skin.customStyles[13]);
				stretchStyle.normal.background = Resources.Load("Screen7-StatusNum2") as Texture2D;
				GUI.Label(new Rect(24, 219, volumn, 30), "", stretchStyle);
			GUI.EndGroup();
			
			if(GUI.Button(new Rect(10, 275, 100, 40), "Back", "ButtonGeneral"))
			{
				Application.LoadLevel("Screen19");
			}
			GUI.Button(new Rect(370, 275, 100, 40), "Save", "ButtonGeneral");
		}
		else{
			GS.PressAvatar();	
		}
	}
}
