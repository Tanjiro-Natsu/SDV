using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile1 : MonoBehaviour
{
    [Header("Set Dynamically")]
    public int x;
    public int y;
    public int tileNum;
    public Sprite wall;
    public Sprite floor;
    public Sprite ldoor;
    public Sprite rdoor;
    public Sprite lupperdoor;
    public Sprite rupperdoor;
    public Sprite llowerdoor;
    public Sprite rlowerdoor;
    public Sprite ldooropen;
    public Sprite rdooropen;
    public Sprite lupperdooropen;
    public Sprite rupperdooropen;
    public Sprite llowerdooropen;
    public Sprite rlowerdooropen; 
    public Sprite abbellimento;
    public Sprite abbellimento1;
    public Sprite scala;

    public void SetTile(int eX,int eY){
    x=eX;
    y=eY;
    transform.localPosition=new Vector3(x,y,0);
    gameObject.name=x.ToString("D3")+"x"+y.ToString("D3");
    int eTilenum=DungeonCreator.GET_MAP(x,y);
   switch(eTilenum){
      case 2:
     GetComponent<SpriteRenderer>().sprite=scala;
    break;
    case 1:
     GetComponent<SpriteRenderer>().sprite=floor;
    break;
    case 3:
     GetComponent<SpriteRenderer>().sprite=wall;
    break;
    case 84:
     GetComponent<SpriteRenderer>().sprite=llowerdooropen;
    break;
    case 85:
     GetComponent<SpriteRenderer>().sprite=rlowerdooropen;
    break;
    case 52:
     GetComponent<SpriteRenderer>().sprite=lupperdooropen;
    break;
    case 53:
     GetComponent<SpriteRenderer>().sprite=rupperdooropen;
    break;
      case 67:
     GetComponent<SpriteRenderer>().sprite=ldooropen;
    break;
    case 70:
     GetComponent<SpriteRenderer>().sprite=rdooropen;
    break;
    case 88:
     GetComponent<SpriteRenderer>().sprite=llowerdoor;
    break;
    case 89:
     GetComponent<SpriteRenderer>().sprite=rlowerdoor;
    break;
    case 56:
     GetComponent<SpriteRenderer>().sprite=lupperdoor;
    break;
    case 57:
     GetComponent<SpriteRenderer>().sprite=rupperdoor;
    break;
      case 72:
     GetComponent<SpriteRenderer>().sprite=ldoor;
    break;
    case 73:
     GetComponent<SpriteRenderer>().sprite=rdoor;
    break;
    case 23:
     GetComponent<SpriteRenderer>().sprite=abbellimento;
    break;
      case 24:
     GetComponent<SpriteRenderer>().sprite=abbellimento1;
    break;
   }
   

}



}