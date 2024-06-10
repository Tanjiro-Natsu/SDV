using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveMap : MonoBehaviour
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
pos.y-=6-(int)(draypos.y/11);
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
changeTile(x,6-y,0);
return;
}
if((int)(draypos.x/16)<x){
pos.x-=1;
x=(int)(draypos.x/16);
transform.position=pos;
changeTile(x,6-y,1);
return;
}
if((int)(draypos.y/11)>y){
pos.y+=1;
y=(int)(draypos.y/11);
transform.position=pos;
changeTile(x,6-y,2);
return;
}
if((int)(draypos.y/11)<y){
pos.y-=1;
y=(int)(draypos.y/11);
transform.position=pos;
changeTile(x,6-y,3);
return;
}

}
void changeTile(int x,int y,int direction){
    switch(direction){
        case 0:
if(Map.map[6-y,x]==1 && Map.map[6-y,x-1]!=3){
    Map.map[6-y,x]=23;
    Map.map[6-y,x-1]=1;
    Map.Tile[x,6-y].GetComponent<SpriteRenderer>().sprite=dray;
    Map.Tile[x-1,6-y].GetComponent<SpriteRenderer>().sprite=normal;
}
if(Map.map[6-y,x]==3){
     Map.Tile[x-1,6-y].GetComponent<SpriteRenderer>().sprite=normal;
     Map.map[6-y,x-1]=1;
}
if(Map.map[6-y,x-1]==3){
    Map.Tile[x,6-y].GetComponent<SpriteRenderer>().sprite=dray;
    Map.map[6-y,x]=23;
}
        break;
         case 1:
if(Map.map[6-y,x]==1 && Map.map[6-y,x+1]!=3 ){
    Map.map[6-y,x]=23;
    Map.map[6-y,x+1]=1;
   Map.Tile[x,6-y].GetComponent<SpriteRenderer>().sprite=dray;
    Map.Tile[x+1,6-y].GetComponent<SpriteRenderer>().sprite=normal;
}
if(Map.map[6-y,x]==3){
     Map.map[6-y,x+1]=1;
    Map.Tile[x+1,6-y].GetComponent<SpriteRenderer>().sprite=normal;
}
if(Map.map[6-y,x+1]==3){
    Map.Tile[x,6-y].GetComponent<SpriteRenderer>().sprite=dray;
    Map.map[6-y,x]=23;
}
        break;
         case 2:
if(Map.map[6-y,x]==1 && Map.map[6-y-1,x]!=3){
     Map.map[6-y,x]=23;
    Map.map[6-y-1,x]=1;
   Map.Tile[x,6-y].GetComponent<SpriteRenderer>().sprite=dray;
    Map.Tile[x,6-y-1].GetComponent<SpriteRenderer>().sprite=normal;
}
if(Map.map[6-y,x]==3){
     Map.map[6-y-1,x]=1;
    Map.Tile[x,6-y-1].GetComponent<SpriteRenderer>().sprite=normal;
}
if(Map.map[6-y-1,x]==3){
     Map.Tile[x,6-y].GetComponent<SpriteRenderer>().sprite=dray;
      Map.map[6-y,x]=23;
}
        break;
         case 3:
if(Map.map[6-y,x]==1 && Map.map[6-y+1,x]!=3){
      Map.map[6-y,x]=23;
    Map.map[6-y+1,x]=1;
     Map.Tile[x,6-y].GetComponent<SpriteRenderer>().sprite=dray;
    Map.Tile[x,6-y+1].GetComponent<SpriteRenderer>().sprite=normal;
}
if(Map.map[6-y,x]==3){
    Map.map[6-y+1,x]=1;
    Map.Tile[x,6-y+1].GetComponent<SpriteRenderer>().sprite=normal;
}
if(Map.map[6-y+1,x]==3){
    Map.map[6-y,x]=23;
    Map.Tile[x,6-y].GetComponent<SpriteRenderer>().sprite=dray;
}
        break;
    }
    

}

}