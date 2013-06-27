using UnityEngine;
using System.Collections;

public class Screen14 : MonoBehaviour {
	
	public GUISkin skin;
	public string titleName; //title is "Pet " + petname in pet table
	public Texture2D iconScene; //Icon is the avatar in pettype table
	
	public GlobalScript.Pet pet; //load Pet from database
	// Use this for initialization
	void Start () {
		//load Pet info from database, this is example
		int[] medal = {1, 5, 6};
		string[] skills = {"Jumpiee", "Punch it", "Hithithit", "Fire"};
		pet = new GlobalScript.Pet("Lika", 20, 26, medal, 420, 500, 400, 600, 1807, 500, skills, "image5");
		iconScene = Resources.Load(pet.avatar) as Texture2D;
		titleName = "Pet: " + pet.petName;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI ()
	{
		GUI.skin = skin;
		GUI.Box(new Rect(55, 0, 370, 30), titleName, "Title"); //title is "Pet " + petname in pet table
		GUI.Label(new Rect(430, 0, 50, 50), iconScene, "LabelNormal"); //Icon is the avatar in pettype table
		GlobalScript.DrawAvatar();	
		
		GUI.Box(new Rect(0, 50, 320, 225), "put camera pet 3D here", "BoxGroup2");
		
		//Write info
		GUI.BeginGroup(new Rect(320, 50, 160, 220));
			GUIStyle styleLabel = new GUIStyle(GUI.skin.label);
			//name
			styleLabel.fontStyle = FontStyle.Bold;
			styleLabel.fontSize = 25;
			GUI.Label(new Rect(5, 0, 60, 30), pet.petName, styleLabel); 
			
			styleLabel.fontStyle = FontStyle.BoldAndItalic;
			styleLabel.fontSize = 20;
			styleLabel.normal.textColor = Color.grey;
			//Level
			GUI.Label(new Rect(5, 35, 60, 22), "Level:");
			GUI.Label(new Rect(60, 35, 60, 22), pet.level.ToString(), styleLabel);
			//Medal
			GUI.Label(new Rect(5, 62, 60, 22), "Medal:");
			GUI.Label(new Rect(60, 62, 60, 22), pet.medal.Length.ToString()); //Load list of avatar of Medals
			//mana
			GUI.Label(new Rect(5, 89, 60, 22), "Mana:");
			GlobalScript.drawStretch(1, new Rect(60, 89, 95, 22), pet.mana, pet.maxMana, true);
			//blood
			GUI.Label(new Rect(5, 116, 60, 22), "Blood:");
			GlobalScript.drawStretch(2, new Rect(60, 116, 95, 22), pet.blood, pet.maxBlood, true);
			//Rate
			GUI.Label(new Rect(5, 143, 60, 22), "Rate:");
			GUI.Label(new Rect(60, 143, 60, 22), pet.rate.ToString(), styleLabel);
			//XP
			GUI.Label(new Rect(5, 170, 60, 22), "XP:");
			GUI.Label(new Rect(60, 170, 60, 22), pet.XP.ToString(), styleLabel);
			//Skills
			GUI.Label(new Rect(5, 197, 60, 22), "Skills:");
			GUI.Label(new Rect(60, 197, 60, 22), pet.skills.Length.ToString(), styleLabel);
		GUI.EndGroup();
		
		//Draw button
		GUI.BeginGroup(new Rect(0, 275, 480, 45));
			GUI.Button(new Rect(5, 0, 74, 40), "Feed", "ButtonGeneral");
			GUI.Button(new Rect(84, 0, 74, 40), "Suite", "ButtonGeneral");
			GUI.Button(new Rect(163, 0, 74, 40), "Skills", "ButtonGeneral");
			GUI.Button(new Rect(242, 0, 74, 40), "Hunt", "ButtonGeneral");
			GUI.Button(new Rect(321, 0, 74, 40), "Fight", "ButtonGeneral");
			GUI.Button(new Rect(400, 0, 74, 40), "Back", "ButtonGeneral");
		GUI.EndGroup();
	}
	
	
}
