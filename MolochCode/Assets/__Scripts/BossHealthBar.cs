using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BossHealthBar : MonoBehaviour{
private List<GameObject> healthbarPart;
[Header("Set Dinamically")]
public int health;

 [Header("Set in Inspector")]
public Sprite health_0;
public Sprite health_1;
public Sprite health_2;
public Sprite health_3;
public Sprite health_4;
public Sprite health_5;
public Sprite health_6;
public Sprite health_7;
public Sprite health_8;
public Sprite health_9;
public Sprite health_10;

private List<Sprite> Lista;

private int u=0;
int b;
void Start(){
    Lista=new List<Sprite>(){health_0,health_1,health_2,health_3,health_4,health_5,health_6,health_7,health_8,health_9,health_10};
healthbarPart=new List<GameObject>();
int a=(SceneManager.GetActiveScene().buildIndex+1)*10;
b=health/10;
for(int i=0;i<10;i++){
    GameObject go=GameObject.Find("empty_bar_"+(i+1));
switch (b){
    case 0:
    go.GetComponent<SpriteRenderer>().sprite=health_0;
healthbarPart.Add(go);
    break;
    case 1:
    go.GetComponent<SpriteRenderer>().sprite=health_1;
healthbarPart.Add(go);
    break;
     case 2:
    go.GetComponent<SpriteRenderer>().sprite=health_2;
healthbarPart.Add(go);
    break;
     case 3:
    go.GetComponent<SpriteRenderer>().sprite=health_3;
healthbarPart.Add(go);
    break;
     case 4:
    go.GetComponent<SpriteRenderer>().sprite=health_4;
healthbarPart.Add(go);
    break;
     case 5:
    go.GetComponent<SpriteRenderer>().sprite=health_5;
healthbarPart.Add(go);
    break;
      case 6:
    go.GetComponent<SpriteRenderer>().sprite=health_6;
healthbarPart.Add(go);
    break;
      case 7:
    go.GetComponent<SpriteRenderer>().sprite=health_7;
healthbarPart.Add(go);
    break;
      case 8:
    go.GetComponent<SpriteRenderer>().sprite=health_8;
healthbarPart.Add(go);
    break;
      case 9:
    go.GetComponent<SpriteRenderer>().sprite=health_9;
healthbarPart.Add(go);
    break;
      case 10:
    go.GetComponent<SpriteRenderer>().sprite=health_10;
healthbarPart.Add(go);
    break;
}
}
if(a>health){
    int c=0;
    if(a-health>10){
        c=a-health-10;
    }
    else{
        c=a-health;
    }
        for(int i=9;i>-1;i--){
         if(i<(10-c)){
          healthbarPart[i].GetComponent<SpriteRenderer>().sprite=Lista[b+1];
        }
}

}
}


    void Update(){
      
        if(health>0 && health<(SceneManager.GetActiveScene().buildIndex+1)*10){
          load();
         }
    }



void load(){
    int row=health/10;
    int column=health%10;
for(int i=9;i>-1;i--){
    if(i>=column){
healthbarPart[i].GetComponent<SpriteRenderer>().sprite=Lista[row];
    }
    else{
       healthbarPart[i].GetComponent<SpriteRenderer>().sprite=Lista[row+1]; 
    }
  
}



    
    /*if(b*10<health){
c=10-Mathf.Abs(b*10-health);
    }
    if(b*10==health){
     c=10;
    } 
    else{
        c=Mathf.Abs(b*10-health);
    }

    for(int i=9;i>-1;i--){
        if(i>=10-c){
             healthbarPart[i].GetComponent<SpriteRenderer>().sprite=Lista[b-1];
             u=1;
        }
        if(c>=9 && u==1){
            b-=1;
            u=0;
        }
    }*/
          
        }
}

