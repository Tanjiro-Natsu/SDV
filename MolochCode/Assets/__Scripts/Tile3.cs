using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile3 : MonoBehaviour
{
    [Header("Set Dynamically")]
    public int x;
    public int y;
    public int tileNum;
    public Sprite floor;
    public Sprite end;
    public Sprite Void;

    public void SetTile(int eX,int eY){
    x=eX;
    y=eY;
    transform.localPosition=new Vector3(x,y,0);
    gameObject.name=x.ToString("D3")+"x"+y.ToString("D3");
    int eTilenum=TileCamera3.finalBossStage[x,y];
   switch(eTilenum){
    case 1:
     GetComponent<SpriteRenderer>().sprite=floor;
    break;
    
    
    case 10:
GetComponent<SpriteRenderer>().sprite=end;
    break;
     case 6:
GetComponent<SpriteRenderer>().sprite=Void;
    break;
  
   }
   

}



}