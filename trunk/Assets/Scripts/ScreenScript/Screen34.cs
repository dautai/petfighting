using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Screen34 : MonoBehaviour {
	
	public GUISkin skin;
	public string titleName;
	public Texture2D iconScene;
	public Texture2D buttonBack;
	public Texture2D buttonOK;
	int selectingType = 0;
	//------------------
	string selectingTypeStr;
	List<PetDetail> curPetDetails;
	string debugStr;
	//------------
	string[] typePet = {"Fire", "Water", "Wind", "Earth", "Metal"};
	private Vector2 scrollViewVector = Vector2.zero;
	int selectingPet = -1;
	int[] petShowingList = {2, 4, 7, 8, 12, 35};
	int listPetLength;
	// Use this for initialization
	void Start () 
	{
		listPetLength = petShowingList.Length;
		selectingTypeStr = "Fire";
		curPetDetails = GetPetDetailOfType(selectingTypeStr);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI()
	{
		GUI.skin = skin;
		GUI.Box(new Rect(55, 0, 370, 30), titleName, "Title");
		GUI.Label(new Rect(430, 0, 50, 50), iconScene, "LabelNormal");
		GS.DrawAvatar();
		
		GUIStyle selectedButton = new GUIStyle(GUI.skin.customStyles[1]); //Button General
		selectedButton.normal.background = selectedButton.active.background;
		
		//Choose type of pet
		for(int i=0; i<5; i++)
		{			
			if(GUI.Button(new Rect(70+i*70, 50, 60, 30), typePet[i], i==selectingType?selectedButton:"ButtonGeneral"))
			{
				selectingType = i;
				selectingPet = -1;
				ApplyNumberOfType(i); 
				updatePetShowingList(selectingType); //update list pet of this type
			}
		}
		GUI.Box(new Rect(0, 80, 480, 150), "", "BoxGroup1");
		GUI.Box(new Rect(50, 215, 380, 110), "", "BoxGroup1");
		
		//draw button
		GUI.Label(new Rect(5, 275, 40, 40),buttonBack);
		if(GUI.Button(new Rect(5, 275, 40, 40), "", "ButtonCover"))
		{
			Application.LoadLevel("Screen7");
		}
		
		GUI.Label(new Rect(435, 275, 40, 40),buttonOK);
		if(GUI.Button(new Rect(435, 275, 40, 40), "", "ButtonCover"))
		{
			if(selectingPet!=-1)
			{
				GS.numberOfPet++;
				CreateNewPet();
				Application.LoadLevel("Screen7");
			}
		}
		
		ShowPetList();
		
		//Show Detail about list
		string detail;
		if(selectingPet==-1)
		{
			detail = "please choose a pet";
		}
		else
		{
			//detail = selectingPet.ToString() + " is pet very cute";
			detail = curPetDetails[selectingPet].detail;
		}
		GUI.Label(new Rect(64, 225, 352, 84), detail, "LabelNormal");
		
		//debug
		debugStr = selectingType.ToString();
		GUI.Label(new Rect(0, 0, 500, 500), debugStr);
	}
	
	
	void updatePetShowingList(int selectingType)
	{
		for(int i =0; i<petShowingList.Length; i++)
		{
			petShowingList[i] +=selectingPet;
		}
		listPetLength = petShowingList.Length;
	}
	
	void ShowPetList()
	{
			//Draw choose pet style
		GUIStyle stretchStyle1 = new GUIStyle(GUI.skin.customStyles[13]);
		stretchStyle1.normal.background = Resources.Load("boxChoosePet") as Texture2D;
		stretchStyle1.border = new RectOffset(6, 8, 5, 10);
		
		//draw list pet
		scrollViewVector = GUI.BeginScrollView (new Rect (14, 90, 452, 124), scrollViewVector, new Rect (0, 0, 93*listPetLength, 105)); //93 is width of a pet cell

		// draw list of pet
		curPetDetails = GetPetDetailOfType(selectingTypeStr);
		for(int i =0; i<curPetDetails.Count; i++)
		{
			Texture petAvatar = Resources.Load(curPetDetails[i].avatar) as Texture2D;
			GUIContent content = new GUIContent();
			content.image = petAvatar;
			content.text = curPetDetails[i].typeName;
			stretchStyle1.imagePosition = ImagePosition.ImageAbove;
			if(i==selectingPet)
			{
				if(GUI.Button(new Rect(i*93, 0, 93, 105), content, stretchStyle1))
				{
				}
			}
			else
			{
				if(GUI.Button(new Rect(i*93, 0, 93, 105), content, "LabelNormal"))
				{
					selectingPet = i;
				}
			}
		}

		// End the ScrollView
		GUI.EndScrollView();
	}
	
	public void ApplyNumberOfType(int type)
	{
		switch(type)
		{
		case 0 :
			selectingTypeStr = "Fire";
			break;
		case 1 :
			selectingTypeStr = "Water";
			break;
		case 2 :
			selectingTypeStr = "Wind";
			break;
		case 3 :
			selectingTypeStr = "Earth";
			break;
		case 4 :
			selectingTypeStr = "Metal";
			break;			
		default :
			selectingTypeStr = "";
			break;
		}
	}
	
	public List<PetDetail> GetPetDetailOfType(string type)
	{
		List<PetDetail> rs = new List<PetDetail>();
		foreach(PetDetail pet in GS.petDetails)
		{
			if(pet.atomType.Equals(type))
			{
				rs.Add(pet);
			}
		}
		
		return rs;
	}
	
	public void CreateNewPet()
	{
		
		string sendStr = "";
		sendStr += GS.playerID.ToString() + '_';
		sendStr += curPetDetails[selectingPet].typeName + '_';
		sendStr += curPetDetails[selectingPet].id.ToString() + '_';
		sendStr += "1" + '_';
		sendStr += "1" + '_';
		sendStr += "200" + '_';
		sendStr += "200" + '_';
		sendStr += "400" + '_';
		sendStr += "400" + '_';
		sendStr += "10" + '_';
		sendStr += "0" + '_';
		
		Service1 ser = new Service1();
		ser.CreateNewPet(sendStr);
		
		GS.GetPetData();
		
	}
}
