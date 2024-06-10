using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Map : MonoBehaviour
{
    [Header("Set in Inspector")]
    public TileMap tilePrefab;
     static public Transform TILE_ANCHOR_Map;
    static public  TileMap [,] Tile;
    static public  int [,] map;
    void Start(){


      Screen.SetResolution(10,10,true);
        map=new int[7,7];
      setmap();
     Invoke("finddray",1);
      
    }

    void finddray(){
 Vector3 pos=GameObject.Find("/Dray").GetComponent<Transform>().position;
map[((int)pos.y/11),((int)pos.x/16)]=23;
      showMap();
      Vector3 vector=transform.position;
      vector.x+=(int)pos.x/16;
      vector.y+=(int)pos.y/11;
      transform.position=vector;
    }

void showMap(){

  Tile=new TileMap[7,7];
        for (int j=0;j<7;j++){
            for (int i=0;i<7;i++){
                    TileMap ti=Instantiate<TileMap>(tilePrefab);
                    ti.transform.SetParent(TILE_ANCHOR_Map);
                    ti.SetTile(i,j,map[j,i]);
                    Tile[i,j]=ti;             
            } 
        }
}

void setmap(){
  for(int i=0;i<7;i++){
            for(int k=0;k<7;k++){
            
             map[k,i]=DungeonCreator.nstanze[i,k];
             if((i==DungeonCreator.Boss1x && k==DungeonCreator.Boss1y) || (i==DungeonCreator.Boss2x && k==DungeonCreator.Boss2y) || (i==DungeonCreator.Boss3x && k==DungeonCreator.Boss3y)  )
              map[k,i]=3;
        }}
        
}

void Update(){
 

}

}