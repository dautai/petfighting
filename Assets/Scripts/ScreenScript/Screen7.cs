using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Screen7 : MonoBehaviour {
	
	public GUISkin skin;
	public string titleName;
	public Texture2D iconScene;
	
	
	//variable from database
	int money = 100;
	int[] medal = {1, 5, 6};
	int numberOfPets;
	
	public Texture2D buttonMap;
	public Texture2D buttonWarehouse;
	public Texture2D defence;

	void Start () {
		numberOfPets = GS.numberOfPet;
		//petList = new GlobalScript.Pet[numberOfPets];
		for(int i = 0; i<numberOfPets; i++)
		{
			//string[] skills = {"Jumpiee", "Punch it", "Hithithit", "Fire"};

			//petList[i] = new GlobalScript.Pet("Lika", 20, 26, medal, 420, 500, 400, 600, 1807, 500, skills, "image5");
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
		
		if(!GS.pressAvatar)
		{
			GS.DrawAvatar();
			
			GUI.Label(new Rect(0, 120, 55, 55), buttonMap);
			
			if(GUI.Button(new Rect(0, 120, 55, 55), "",  "ButtonCover"))
			{
				//Go to scene map
				Application.LoadLevel("Screen23");
			}
			
			GUI.Label(new Rect(0, 190, 55, 55), buttonWarehouse);
			
			if(GUI.Button(new Rect(0, 190, 55, 55), "",  "ButtonCover"))
			{
				//Go to scene warehouse 
				Application.LoadLevel("Screen10");
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
			if(GS.petDatas.Count>0)
			{
				ShowPetsNew();
				if(GS.petDatas.Count < 3)
					ShowChoosePet(GS.petDatas.Count);
			}
			else
			{
				ShowChoosePet(0);
			}
		}
		else{
			GS.PressAvatar();	
		}
	}
	
	void ShowChoosePet(int n)
	{
		GUIStyle stretchStyle1 = new GUIStyle(GUI.skin.customStyles[13]);
		stretchStyle1.normal.background = Resources.Load("boxChoosePet") as Texture2D;
		stretchStyle1.border = new RectOffset(6, 8, 5, 10);
		if(GUI.Button(new Rect(67+130*n, 91, 130, 163), "Choose a pet", stretchStyle1))
		{
			Application.LoadLevel("Screen34");
		}
	}

	void ShowPetsNew()
	{
		GUI.BeginGroup(new Rect(65, 88, 405, 171));
		for(int i = 0; i<GS.petDatas.Count; i++)
		{
			GUI.BeginGroup(new Rect(i*130, 0, 130, 171));
				if(GUI.Button(new Rect(0, 0, 130, 171), "", "BoxGroup2"))
				{
					GS.currentPet = i;
					Application.LoadLevel("Screen14");

				}
			
				//Petname
				GUI.Label(new Rect(10, 10, 110, 22),GS.petDatas[i].petName, "LabelPet");	
				//Pet avatar
				Texture avatarPet = Resources.Load("image5") as Texture2D;
				GUI.Label(new Rect(10, 28, 85, 95),avatarPet, "LabelNormal");
				//Pet Level
				GUI.Label(new Rect(90, 50, 30, 30), GS.petDatas[i].levelPet.ToString(), "LabelLevel");
				//Pet Medal
				GUI.Label(new Rect(90, 80, 20, 30), GS.petDatas[i].medals.Count.ToString());
				Texture medalStar = Resources.Load("image10") as Texture2D;
				GUI.Label(new Rect(104, 83, 16, 16), medalStar, "LabelNormal");
				//Pet mana
				GS.drawStretch(1, new Rect(18, 125, 94, 12), GS.petDatas[i].mana, GS.petDatas[i].maxMana, false);
				//Pet Blood
				GS.drawStretch(2, new Rect(18, 142, 94, 12), GS.petDatas[i].food, GS.petDatas[i].maxFood, false);
			GUI.EndGroup();
		}
		GUI.EndGroup();
	}
	
}


