using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GuiPanel :MonoBehaviour{
[Header("Set in Inspector")]
public Dray dray;
public DrayFinal drayfinal;
public Sprite healthEmpty;
public Sprite healthFull;

Text keyCountText;
List<Image> healthImages;
Text lvl;

void Start(){
    Transform trans=transform.Find("Key Count");
    Transform sword=transform.Find("Swordlvl");
    lvl=sword.GetComponent<Text>();
    keyCountText=trans.GetComponent<Text>();
    Transform healthPanel=transform.Find("Health Panel");
    healthImages=new List<Image>();
    if(healthPanel!=null){
        for(int i=0;i<10;i++){
healthImages.Add(healthPanel.Find("H_"+i).GetComponent<Image>());

        }


        }
        for(int i=0;i<healthImages.Count;i++){
            healthImages[i].sprite=healthEmpty; 
    }
    }

void Update(){
    if(SceneManager.GetActiveScene().buildIndex==9){ keyCountText.text=drayfinal.numKeys.ToString();}
    else{
 keyCountText.text=dray.numKeys.ToString();
    }
   
    int level=GameObject.Find("/Dray/SwordController/Sword").GetComponent<DamageEffect>().damage;
switch(level){
    case 2:
lvl.text="Sword";
    break;
    case 3:
lvl.text="Sword+1";
    break;
    case 4:
lvl.text="Sword+2";
    break;
    case 5:
lvl.text="Sword+3";
    break;
    case 6:
lvl.text="Sword+4";
    break;
    case 7:
lvl.text="Sword+5";
    break;
    case 8:
lvl.text="Sword+6";
    break;
    case 9:
lvl.text="Sword+7";
    break;
    case 10:
lvl.text="Sword+8";
    break;
    case 11:
lvl.text="Sword+9";
    break;
    case 15:
lvl.text="Sword+10";
    break;
}
if(SceneManager.GetActiveScene().buildIndex==9){
 int health=drayfinal.health;
    for(int i=0;i<healthImages.Count;i++){
       if(i<drayfinal.health){
    healthImages[i].sprite=healthFull;}
    else {
        healthImages[i].sprite=healthEmpty;
    }
     
    }
}
else{
    int health=dray.health;
    for(int i=0;i<healthImages.Count;i++){
       if(i<dray.health){
    healthImages[i].sprite=healthFull;}
    else {
        healthImages[i].sprite=healthEmpty;
    }
     
    } 
}
   
}
}