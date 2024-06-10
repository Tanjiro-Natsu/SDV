using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveMap1 : MonoBehaviour
{
    [Header("Set in Inspector")]
    public Sprite dray;
    public Sprite normal; 

    private int wait=0;
private int x;
private int y;
void Start(){
Invoke("findray",1);

}

void Update(){
    wait++;
if(wait>120){
   chanchepositioncam(); 
}
}
void findray(){
    Vector3 pos=transform.position;
GameObject dray=GameObject.Find("/Dray");
Vector3 draypos=dray.transform.position;
pos.x+=(int)(draypos.x/16);
pos.y-=(int)(draypos.y/11);
x=(int)(draypos.x/16);
y=(int)(draypos.y/11);
transform.position=pos;
}

void chanchepositioncam(){
    Vector3 pos=transform.position;
GameObject dray=GameObject.Find("/Dray");
Vector3 draypos=dray.transform.position;
if((int)(draypos.x/16)>x){
pos.x+=1;
x=(int)(draypos.x/16);
transform.position=pos;
changeTile(x,y,0);
return;
}
if((int)(draypos.x/16)<x){
pos.x-=1;
x=(int)(draypos.x/16);
transform.position=pos;
changeTile(x,y,1);
return;
}
if((int)(draypos.y/11)>y){
pos.y+=1;
y=(int)(draypos.y/11);
transform.position=pos;
changeTile(x,y,2);
return;
}
if((int)(draypos.y/11)<y){
pos.y-=1;
y=(int)(draypos.y/11);
transform.position=pos;
changeTile(x,y,3);
return;
}

}
void changeTile(int x,int y,int direction){
    switch(direction){
        case 0:
if(Map1.map[x,y]==1 && Map1.map[x-1,y]!=3){
  
    Map1.map[x,y]=23;
    Map1.map[x-1,y]=1;
    Map1.Tile[x,y].GetComponent<SpriteRenderer>().sprite=dray;
    Map1.Tile[x-1,y].GetComponent<SpriteRenderer>().sprite=normal;
}
if(Map1.map[x,y]==3){
     Map1.Tile[x-1,y].GetComponent<SpriteRenderer>().sprite=normal;
     Map1.map[x-1,y]=1;
}
if(Map1.map[x-1,y]==3){
    Map1.Tile[x,y].GetComponent<SpriteRenderer>().sprite=dray;
    Map1.map[x,y]=23;
}
        break;
         case 1:
if(Map1.map[x,y]==1 && Map1.map[x+1,y]!=3 ){
    Map1.map[x,y]=23;
    Map1.map[x+1,y]=1;
   Map1.Tile[x,y].GetComponent<SpriteRenderer>().sprite=dray;
    Map1.Tile[x+1,y].GetComponent<SpriteRenderer>().sprite=normal;
}
if(Map1.map[x,y]==3){
     Map1.map[x+1,y]=1;
    Map1.Tile[x+1,y].GetComponent<SpriteRenderer>().sprite=normal;
}
if(Map1.map[x+1,y]==3){
    Map1.Tile[x,y].GetComponent<SpriteRenderer>().sprite=dray;
    Map1.map[x,y]=23;
}
        break;
         case 2:
if(Map1.map[x,y]==1 && Map1.map[x,y-1]!=3){
     Map1.map[x,y]=23;
    Map1.map[x,y-1]=1;
   Map1.Tile[x,y].GetComponent<SpriteRenderer>().sprite=dray;
    Map1.Tile[x,y-1].GetComponent<SpriteRenderer>().sprite=normal;
}
if(Map1.map[x,y]==3){
     Map1.map[x,y-1]=1;
    Map1.Tile[x,y-1].GetComponent<SpriteRenderer>().sprite=normal;
}
if(Map1.map[x,y-1]==3){
     Map1.Tile[x,y].GetComponent<SpriteRenderer>().sprite=dray;
      Map1.map[x,y]=23;
}
        break;
         case 3:
if(Map1.map[x,y]==1 && Map1.map[x,y+1]!=3){
      Map1.map[x,y]=23;
    Map1.map[x,y+1]=1;
     Map1.Tile[x,y].GetComponent<SpriteRenderer>().sprite=dray;
    Map1.Tile[x,y+1].GetComponent<SpriteRenderer>().sprite=normal;
}
if(Map1.map[x,y]==3){
    Map1.map[x,y+1]=1;
    Map1.Tile[x,y+1].GetComponent<SpriteRenderer>().sprite=normal;
}
if(Map1.map[x,y+1]==3){
    Map1.map[x,y]=23;
    Map1.Tile[x,y].GetComponent<SpriteRenderer>().sprite=dray;
}
        break;
    }
    

}

}