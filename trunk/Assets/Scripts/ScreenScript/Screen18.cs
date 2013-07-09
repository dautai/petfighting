using UnityEngine;
using System.Collections;

public class Screen18 : MonoBehaviour {
	
	public GUISkin skin;
	public string titleName;
	public Texture2D iconScene;
	GS.Skill[] listSkills;
	int NuSkills = 0;
	Vector2 scrollViewVector = Vector2.zero;
	
	// Use this for initialization
	void Start () {
		titleName = "Manage Skills: " + GS.curPet.petName; //get name of the current pet
		iconScene = Resources.Load("image5") as Texture2D; // Load avatar of pet
		listSkills = new GS.Skill[3]; //load skills from database
		listSkills[0] = new GS.Skill("image28", "hit");
		listSkills[1] = new GS.Skill("image291", "shoot");
		listSkills[2] = new GS.Skill("image30", "punch");
		NuSkills = GS.curPet.lSkill.Count; //get number of all skills
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
			
			
			GUIStyle style = new GUIStyle(GUI.skin.customStyles[2]);
			style.fontSize = 22;
			style.fontStyle = FontStyle.Bold;
			if(NuSkills>0)
			{
				GUI.Label(new Rect(80, 30, 150, 30), "Name", style);
				GUI.Label(new Rect(220, 30, 100, 30), "Command", style);
				GUI.Box(new Rect(0, 50, 476, 220), "", "BoxGroup1");
				scrollViewVector = GUI.BeginScrollView (new Rect (10, 58, 456, 197), scrollViewVector, new Rect (0, 0, 440, (63*NuSkills>197)?(63*NuSkills):198)); //63 is height of a skill row
					for(int i = 0; i<NuSkills; i++)
					{
						drawSkillRow(i, 440, 63);
					}
				GUI.EndScrollView();
			}
			else{
				GUI.Box(new Rect(0, 50, 476, 220), "You have no skill", "BoxGroup1");
			}
	
					
			
			if(GUI.Button(new Rect(10, 275, 100, 40), "Back", "ButtonGeneral"))
			{
				Application.LoadLevel("Screen14");	
			}
			if(GUI.Button(new Rect(370, 275, 100, 40), "Add", "ButtonGeneral"))
			{
				Application.LoadLevel("Screen19");
			}
		}
		else{
			GS.PressAvatar();	
		}
	}
	
	void drawSkillRow(int id, int width, int height)
	{
		GUI.BeginGroup(new Rect(0, id*height, width, height));
			height = height-3;
			Texture2D avatar = Resources.Load(listSkills[id].symbol) as Texture2D;
			GUI.Label(new Rect(5, 5, height-10, height-10), avatar, "LabelNormal");
			GUI.Label(new Rect(height+5, 0, width-3*height-85, height), listSkills[id].name, "LabelNormal");
			if(GUI.Button(new Rect(width-2*height-80+7, 7, height-14, height-14), "", "ButtonCommand"))
			{
			}
			if(GUI.Button(new Rect(width-height-80, height/2-17, 80, 35), "Edit", "ButtonGeneral"))
			{
			}
			if(GUI.Button(new Rect(width-height+10, 7,  height-14, height-14), "", "ButtonStop"))
			{
			}
			GUI.Label(new Rect(0, height, width, 2), "", "WindowCover");
		GUI.EndGroup();
	}
}
