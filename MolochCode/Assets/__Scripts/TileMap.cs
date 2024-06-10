using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour
{
    [Header("Set Dynamically")]
    public int x;
    public int y;
    public int tileNum;
 public Sprite bossroom;
public Sprite empty;
public Sprite normal;
public Sprite Dray;



    public void SetTile(int eX,int eY,int value){
    x=eX;
    y=eY;
    transform.localPosition=new Vector3(x+300,y+300,0);
    gameObject.name=x.ToString("D3")+"x"+y.ToString("D3");
    int eTilenum=value;
   switch(eTilenum){
      case 0:
     GetComponent<SpriteRenderer>().sprite=empty;
    break;
    case 1:
     GetComponent<SpriteRenderer>().sprite=normal;
    break;
    case 3:
     GetComponent<SpriteRenderer>().sprite=bossroom;
    break;
    case 23:
     GetComponent<SpriteRenderer>().sprite=Dray;
    break;
    
   }
   

}



}