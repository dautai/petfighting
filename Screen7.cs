using UnityEngine;
using System.Collections;


public class Screen7 : MonoBehaviour {
	
	public GUISkin skin;
	public string titleName;
	public Texture2D iconScene;
	
	
	public GlobalScript.Pet[] petList;
	
	//variable from database
	int money = 100;
	int[] medal = {1, 5, 6};
	int numberOfPets;
	
	
	
	
	public Texture2D buttonMap;
	public Texture2D buttonWarehouse;
	public Texture2D defence;
	// Use this for initialization
	void Start () {
		numberOfPets = GlobalScript.numberOfPet;
		petList = new GlobalScript.Pet[numberOfPets];
		for(int i = 0; i<numberOfPets; i++)
		{
			string[] skills = {"Jumpiee", "Punch it", "Hithithit", "Fire"};

			petList[i] = new GlobalScript.Pet("Lika", 20, 26, medal, 420, 500, 400, 600, 1807, 500, skills, "image5");
		}
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
		
		GUI.Label(new Rect(0, 120, 55, 55), buttonMap);
		
		if(GUI.Button(new Rect(0, 120, 55, 55), "",  "ButtonCover"))
		{
			//Go to scene map
		}
		
		GUI.Label(new Rect(0, 190, 55, 55), buttonWarehouse);
		
		if(GUI.Button(new Rect(0, 190, 55, 55), "",  "ButtonCover"))
		{
			//Go to scene warehouse 
		}
	
		for(int i = 0; i<35; i++)
		{
			GUI.Label(new Rect(i*14, 276, 15, 44), defence, "LabelNormal");
		}
		
		GUI.Label(new Rect(80, 50, 60, 30), "Money:", "LabelNormal");
		GUI.Label(new Rect(140, 50, 60, 30), money.ToString(), "LabelNormal");
		GUI.Label(new Rect(250, 50, 60, 30), "Medal:", "LabelNormal");
		for(int i= 0; i<medal.Length; i++)
		{
			GUI.Label(new Rect(310+i*35, 50, 30, 30), medal[i].ToString(), "LabelNormal");
		}
		
		//Show pets list
		GUI.Box(new Rect(55, 80, 425, 190), "", "BoxGroup1");
		//Pet 1
		if(numberOfPets>0)
		{
			ShowPets();
		}
		else
		{
			ShowChoosePet();
		}
	}
	
	void ShowChoosePet()
	{
		GUIStyle stretchStyle1 = new GUIStyle(GUI.skin.customStyles[13]);
		stretchStyle1.normal.background = Resources.Load("boxChoosePet") as Texture2D;
		stretchStyle1.border = new RectOffset(6, 8, 5, 10);
		if(GUI.Button(new Rect(67, 91, 123, 163), "Choose a pet", stretchStyle1))
		{
			Application.LoadLevel("Screen34");
		}
	}
	
	void ShowPets()
	{
		GUI.BeginGroup(new Rect(65, 88, 405, 171));
		for(int i = 0; i<numberOfPets; i++)
		{
			GUI.BeginGroup(new Rect(i*130, 0, 130, 171));
				if(GUI.Button(new Rect(0, 0, 130, 171), "", "BoxGroup2"))
				{
					GlobalScript.currentPet = i;
					Application.LoadLevel("Screen14");
				}
				//Petname
				GUI.Label(new Rect(10, 10, 110, 22),petList[i].petName, "LabelPet");	
				//Pet avatar
				Texture avatarPet = Resources.Load(petList[i].avatar) as Texture2D;
				GUI.Label(new Rect(10, 28, 85, 95),avatarPet, "LabelNormal");
				//Pet Level
				GUI.Label(new Rect(90, 50, 30, 30), petList[i].level.ToString(), "LabelLevel");
				//Pet Medal
				GUI.Label(new Rect(90, 80, 20, 30), petList[i].medal.Length.ToString());
				Texture medalStar = Resources.Load("image10") as Texture2D;
				GUI.Label(new Rect(104, 83, 16, 16), medalStar, "LabelNormal");
				//Pet mana
				GlobalScript.drawStretch(1, new Rect(18, 125, 94, 12), petList[i].mana, petList[i].maxMana, false);
				//Pet Blood
				GlobalScript.drawStretch(2, new Rect(18, 142, 94, 12), petList[i].blood, petList[i].maxBlood, false);
			GUI.EndGroup();
		}
		GUI.EndGroup();
	}
}


