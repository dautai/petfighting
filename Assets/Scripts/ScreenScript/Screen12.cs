using UnityEngine;
using System.Collections;

public class Screen12 : MonoBehaviour {

	public GUISkin skin;
	public string titleName;
	public Texture2D iconScene;
	item[] listItem; //Load this list from Item table
	int NuItem = 0;
	Vector2 scrollViewVector = Vector2.zero;
	int selectingItem = -1;
	Texture2D iconBack;
	bool showMoneyLow = false;
		
	// Use this for initialization
	void Start () {
		titleName = "Shop"; //get name of the current pet
		iconScene = Resources.Load("image18") as Texture2D; // Load avatar of pet
		iconBack = Resources.Load("Back") as Texture2D;
		loadListitem();
		//NuItem = 3; //get number of all skills
	}
	
	
	void loadListitem()
	{
		WareHouse ser=new WareHouse();
		string[] a=ser.ReturnItem();
		NuItem=(a.Length+1)/9;
		listItem=new item[(a.Length+1)/9];
		for(int i=0;i<(a.Length+1)/9;i++)
		{			
			listItem[i] = new item(1,"Cake", 80, 100, 20, 0, 0f, 0f, "image20"); 
			listItem[i].id=int.Parse(a[i*9+0]);
			listItem[i].name=a[i*9+1];
			listItem[i].priceSell=int.Parse(a[i*9+2]);
			listItem[i].priceBuy=int.Parse(a[i*9+3]);
			listItem[i].valueMana=int.Parse(a[i*9+4]);
			listItem[i].valueBlood=int.Parse(a[i*9+5]);
			listItem[i].percentAttack=int.Parse(a[i*9+6]);
			listItem[i].percentDefence=int.Parse(a[i*9+7]);
			listItem[i].avatar=a[i*9+8];	
			print(listItem[i].name);
		}
		/*
		listItem = new item[3]; //load skills from database
		listItem[0] = new item("Cake", 80, 100, 20, 0, 0f, 0f, "image20"); 
		listItem[1] = new item("Cake", 80, 100, 20, 0, 0f, 0f, "image20"); 
		listItem[2] = new item("Cake", 80, 100, 20, 0, 0f, 0f, "image20"); */
	}
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI()
	{
	
		GUI.skin = skin;
		GUI.Box(new Rect(55, 0, 370, 30), titleName, "Title");
		GUI.Label(new Rect(430, 0, 50, 50), iconScene, "LabelNormal");
		if(!GS.showingItemDetail)
		{
			if(!GS.pressAvatar)
			{
				
				GS.DrawAvatar();		
				//draw percent of wareHouse
				GUI.Label(new Rect(50, 35, 150, 25), "Money: "+ GS.money);
					GS.drawStretch(1, new Rect(200, 35, 200, 25), GS.currentWareHouse,
						GS.wareHouse, true);
				
				GUIStyle style = new GUIStyle(GUI.skin.customStyles[2]);
				style.fontSize = 18;
				style.fontStyle = FontStyle.Bold;
				if(NuItem>0)
				{
	
					GUI.Label(new Rect(50, 60, 70, 30), " Name ", style);
					GUI.Label(new Rect(120, 60, 55, 30), "| Price ", style);
					GUI.Label(new Rect(175, 60, 70, 30), "| vMana ", style);
					GUI.Label(new Rect(245, 60, 70, 30), "| vBlood ", style);
					GUI.Label(new Rect(315, 60, 75, 30), "| %Attack ", style);
					GUI.Label(new Rect(390, 60, 90, 30), "| %Defence", style);
					
					GUI.Box(new Rect(-5, 80, 485, 200), "", "BoxGroup1");
					scrollViewVector = GUI.BeginScrollView (new Rect(6, 88, 465, 177), scrollViewVector, new Rect (0, 0, 449, (50*NuItem>177)?(50*NuItem):178)); //63 is height of a skill row
						for(int i = 0; i<NuItem; i++)
						{
							drawItemRow(i, 449, 50);
						}
					GUI.EndScrollView();
				}
				else{
					GUI.Box(new Rect(0, 50, 476, 220), "You have no skill", "BoxGroup1");
				}
		
						
				
				GUI.Label(new Rect(10, 270, 50, 50), iconBack);
				if(GUI.Button(new Rect(10, 270, 50, 50), "", "ButtonCover"))
				{
					Application.LoadLevel("Screen10");	
				}
				if(GUI.Button(new Rect(190, 275, 100, 40), "Buy", "ButtonGeneral"))
				{
					if(selectingItem!=-1 && GS.money>=listItem[selectingItem].priceBuy)
					{	
						GS.money -= listItem[selectingItem].priceBuy;
						WareHouse ser=new WareHouse();
						//update money
						int a=ser.UpdateMoneyUser(GS.idUser,GS.money);
						//update ware house
						a=ser.BuyItem(GS.idUser,listItem[selectingItem].id);
					}
					else
					{
						showMoneyLow =true;
					}
				}
				if(GUI.Button(new Rect(420, 270, 50, 50), "",  "buttonMore"))
				{
					if(selectingItem!=-1)
					{
						GS.loadItemDetail(selectingItem);
						GS.showingItemDetail = true;
					}
				}
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
	
	void drawItemRow(int id, int width, int height)
	{
		if(selectingItem == id)
		{
			GUI.Box(new Rect(0, id*height, width, height), "", "Title");	
		}
		GUI.BeginGroup(new Rect(0, id*height, width, height));
			height = height-3;
			
			Texture2D avatar = Resources.Load(listItem[id].avatar) as Texture2D;
			GUI.Label(new Rect(5, 5, height-10, height-10), avatar, "LabelNormal");
			GUI.Label(new Rect(50, 5, 65, height-10), listItem[id].name, "LabelNormal");
			GUI.Label(new Rect(115, 5, 55, height-10), listItem[id].priceBuy.ToString(), "LabelNormal");
			GUI.Label(new Rect(170, 5, 70, height-10), listItem[id].valueMana.ToString(), "LabelNormal");
			GUI.Label(new Rect(245, 5, 70, height-10), listItem[id].valueBlood.ToString(), "LabelNormal");
			GUI.Label(new Rect(315, 5, 75, height-10), listItem[id].percentAttack.ToString(), "LabelNormal");
			GUI.Label(new Rect(390, 5, 90, height-10), listItem[id].percentDefence.ToString(), "LabelNormal");
		
			GUI.Label(new Rect(0, height, width, 2), "", "WindowCover");
			if(GUI.Button(new Rect(0, 0, width, height), "", "ButtonCover"))
			{
				selectingItem = id;	
			}
		GUI.EndGroup();
	}
}
