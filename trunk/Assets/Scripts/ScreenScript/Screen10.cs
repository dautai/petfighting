using UnityEngine;
using System.Collections;

public class Screen10 : MonoBehaviour {
	
	public GUISkin skin;
	public string titleName;
	public Texture2D iconScene;
	
	Texture2D iconShop;
	Texture2D iconBack;
	int selectingItem =-1;
	Vector2 scrollViewVector = Vector2.zero;
	string[] itemList;
	// Use this for initialization
	void Start () {
		titleName = "Ware House";
		iconScene = Resources.Load("image12") as Texture2D;
		
		iconShop = Resources.Load("image18") as Texture2D;
		iconBack = Resources.Load("Back") as Texture2D;
		itemList = new string[GS.wareHouse];
		itemList[0] = "image20";
		itemList[1] = "image21";
		itemList[2] = "image21";
		itemList[3] = "image22";
		itemList[4] = "image20";
		itemList[5] = "image20";
		itemList[6] = "image20";
		itemList[7] = "image21";
		itemList[8] = "image20";
		itemList[9] = "image21";
		itemList[10] = "image23";
		itemList[11] = "image26";
		itemList[12] = "image22";
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI ()
	{
		GUI.skin = skin;
		GUI.Box(new Rect(55, 0, 370, 30), titleName, "Title"); //title is "Pet " + petname in pet table
		GUI.Label(new Rect(430, 0, 50, 50), iconScene, "LabelNormal"); //Icon is the avatar in pettype table
		if(!GS.showingItemDetail)
		{
			if(!GS.pressAvatar)
			{
				GS.DrawAvatar();	
				
				if(GUI.Button(new Rect(0, 70, 50, 50), "",  "buttonMore"))
				{
					GS.loadItemDetail(selectingItem);
					GS.showingItemDetail = true;
				}
				
				GUI.Label(new Rect(0, 160, 50, 50), iconShop);
				if(GUI.Button(new Rect(0, 160, 50, 50), "", "ButtonCover"))
				{
					Application.LoadLevel("Screen12");	
				}
				if(GUI.Button(new Rect(0, 100, 50, 50), "", "ButtonCover"))
				{
					Application.LoadLevel("Screen13");	
				}
				
				GUI.Label(new Rect(0, 250, 50, 50), iconBack);
				if(GUI.Button(new Rect(0, 250, 50, 50), "", "ButtonCover"))
				{
					Application.LoadLevel("Screen7");	
				}
				//draw percent of wareHouse
				GUI.Label(new Rect(50, 35, 150, 25), "Money: "+ GS.money);
				GS.drawStretch(1, new Rect(200, 35, 200, 25), GS.currentWareHouse,
					GS.wareHouse, true);
				//draw table
				Vector3 valueIn = new Vector3(selectingItem,scrollViewVector.x, scrollViewVector.y);
				valueIn = GS.drawOneWayTable(8, true, itemList, new Vector2(55, 60), 40, 260, valueIn, false, GS.wareHouse);
				selectingItem = (int)valueIn.x;
				scrollViewVector.x = valueIn.y;
				scrollViewVector.y = valueIn.z;
				
			}
			else{
				GS.PressAvatar();	
			}
		}
		else
		{
			GS.showItemDetail();	
		}
	}
}
