using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class TileCamera3 : MonoBehaviour
{
     private GameObject dray;
     [Header("Set in Inspector")]
   public Tile3 tilePrefab;
    static public Transform TILE_ANCHOR;
    public static Tile3[,] TILES;
    public float  startx;
    public  float starty;
    static public int[,] finalBossStage;
    public GameObject FInalBoss;
      public GameObject bar;
    public GameObject name;
    private GameObject o1;
private GameObject o2;
    
    
void Awake(){
    finalBossStage=new int[32,22];
   LoadMap();
}
void LoadMap(){
    GameObject go=new GameObject("TILE_ANCHOR");
    Vector3 pos=go.transform.position;
    pos.z+=10;
    go.transform.position=pos;
        TILE_ANCHOR=go.transform;
         setmap();
         ShowMap();
         
   }

   void Start(){
  dray=GameObject.Find("/Dray");
    dray.transform.position=new Vector3(16,7,0);
   Invoke("SpawnFinalBoss",4.3f);
 
    
   }
    
        void ShowMap(){
        int W=32;
        int H=22;
        TILES=new Tile3[W,H];
        for (int j=0;j<H;j++){
            for (int i=0;i<W;i++){
                if(finalBossStage[i,j]!=0){
                    Tile3 ti=Instantiate<Tile3>(tilePrefab);
                    ti.transform.SetParent(TILE_ANCHOR);
                    ti.SetTile(i,j);
                    TILES[i,j]=ti;
                    
                      
                }
            } 
        }

    }
    
    void setmap(){

for(int i=0;i<22;i++){
    for(int k=0;k<32;k++){
if(k==0 || k==31 || i==0 || i==21){
    finalBossStage[k,i]=10;
}

else if(k==1 || k==30){
    if(Random.Range(0,100)<30){
        finalBossStage[k,i]=6;
    }
    else{
        finalBossStage[k,i]=10;
    }
}
else if(i==1 || i==20){
    if(Random.Range(0,100)<30){
        finalBossStage[k,i]=6;
    }
    else{
        finalBossStage[k,i]=10;
    }
}
else if(i==2 || i==19 || k==2 || k==29){
    finalBossStage[k,i]=6;
}
else{
finalBossStage[k,i]=1;}
    }
}


    }

void SpawnFinalBoss(){
 Instantiate(FInalBoss).transform.position=new Vector3(15,13,0);
}
    
    }