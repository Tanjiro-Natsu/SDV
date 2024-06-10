using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Map1 : MonoBehaviour
{

     [Header("Set in Inspector")]
    public TileMap tilePrefab;
     static public Transform TILE_ANCHOR_Map;
    static public  TileMap [,] Tile;
    static public  int [,] map;
    void Start(){
map=new int[6,6];
for(int i=0;i<6;i++){
    for(int k=0;k<6;k++){
        map[i,k]=0;
    }
}
map[1,5]=1;
map[2,5]=1;
map[2,4]=1;
map[0,3]=3;
map[1,3]=1;
map[2,3]=1;
map[3,3]=1;
map[4,3]=1;
map[4,4]=1;
map[5,4]=3;
map[1,2]=1;
map[2,2]=1;
map[3,2]=1;
map[2,1]=1;
map[3,0]=1;
map[2,0]=1;
map[1,0]=23;
showMap();

    }
    void showMap(){

  Tile=new TileMap[6,6];
        for (int j=0;j<6;j++){
            for (int i=0;i<6;i++){
                    TileMap ti=Instantiate<TileMap>(tilePrefab);
                    ti.transform.SetParent(TILE_ANCHOR_Map);
                    ti.SetTile(i,j,map[i,j]);
                    Tile[i,j]=ti;             
            } 
        }
}
}