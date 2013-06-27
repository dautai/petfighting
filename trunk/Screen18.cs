using UnityEngine;
using System.Collections;

public class Screen18 : MonoBehaviour {
	
	public GUISkin skin;
	public string titleName;
	public Texture2D iconScene;
	GlobalScript.Skill[] listSkills;
	int NuSkills;
	Vector2 scrollViewVector = Vector2.zero;
	Texture2D line;
	
	// Use this for initialization
	void Start () {
		titleName = "Manage Skills: Lika"; //get name of the current pet
		iconScene = Resources.Load("image5") as Texture2D; // Load avatar of pet
		listSkills = new GlobalScript.Skill[3]; //load skills from database
		listSkills[0] = new GlobalScript.Skill("image28", "hit");
		listSkills[1] = new GlobalScript.Skill("image291", "shoot");
		listSkills[2] = new GlobalScript.Skill("image30", "punch");
		NuSkills = 3; //get number of all skills
		line = Resources.Load("ButtonNonCover2") as Texture2D;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI()
	{
	
		GUI.skin = skin;
		GUI.Box(new Rect(55, 0, 370, 30), titleName, "Title");
		GUI.Label(new Rect(430, 0, 50, 50), iconScene, "LabelNormal");
		GlobalScript.DrawAvatar();
		
		
		
		scrollViewVector = GUI.BeginScrollView (new Rect (0, 50, 476, 220), scrollViewVector, new Rect (0, 0, 460, (50*NuSkills>220)?(50*NuSkills):221)); //50 is height of a skill row
			GUIStyle style = new GUIStyle(GUI.skin.customStyles[2]);
			style.fontSize = 22;
			style.fontStyle = FontStyle.Bold;
			GUI.Label(new Rect(5, 0, 80, 30), "Symbol", style);
			GUI.Label(new Rect(80, 0, 150, 30), "Name", style);
			GUI.Label(new Rect(220, 0, 100, 30), "Command", style);
			for(int i = 0; i< NuSkills; i++){
				GUI.BeginGroup(new Rect(5, 35+i*55, 450, 50));
					GUI.Label(new Rect(0, 0, 440, 2), "", "WindowCover");
					Texture2D avatar = Resources.Load(listSkills[i].symbol) as Texture2D;
					GUI.Label(new Rect(0, 2, 100, 50), avatar, "LabelNormal");
					GUI.Label(new Rect(80, 2, 150, 50), listSkills[i].name, "LabelNormal");
					if(GUI.Button(new Rect(250, 7, 40, 40), "", "ButtonCommand"))
					{
					}
					if(GUI.Button(new Rect(310, 7, 80, 40), "Edit", "ButtonGeneral"))
					{
					}
					if(GUI.Button(new Rect(410, 7, 40, 40), "", "ButtonStop"))
					{
					}
				GUI.EndGroup();
			}
		GUI.EndScrollView();
		
		if(GUI.Button(new Rect(10, 275, 100, 40), "Back", "ButtonGeneral"))
		{
			Application.LoadLevel("Screen14");	
		}
		if(GUI.Button(new Rect(370, 275, 100, 40), "Add", "ButtonGeneral"))
		{
			Application.LoadLevel("Screen20");
		}
	}
}
