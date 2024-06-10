using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TileCamera2 : MonoBehaviour
{
     private GameObject dray;
     [Header("Set in Inspector")]
   public Tile1 tilePrefab;
    static public Transform TILE_ANCHOR;
    public static Tile1[,] TILES;
    public float  startx;
    public  float starty;
    public GameObject EnemyType1;
    public GameObject EnemyType2;
    public GameObject BossType1;
    public GameObject BossType2;
    public GameObject BossType3;
    public List<GameObject> EnemyType;



    

void Awake(){
    LoadMap();
    for (int i=0;i<7;i++){
        for (int j=0;j<7;j++){
            if(DungeonCreator.nstanze[i,j]==1 && i!=DungeonCreator.Boss1x && i!=DungeonCreator.Boss2x && i!=DungeonCreator.Boss3x && j!=DungeonCreator.Boss1y && j!=DungeonCreator.Boss2y && j!=DungeonCreator.Boss3y && j!=DungeonCreator.nextLevelx && i!=DungeonCreator.nextLevely){
                startx=i*16+7;
                starty=j*11+4.5f;
                Vector3 pos;
                if((SceneManager.GetActiveScene().buildIndex)==3){
pos=new Vector3(i*16+5.63f,j*11+5,-10);
                }
                else{
 pos=new Vector3(i*16+7.5f,j*11+5,-10);
                }
                
                GetComponent<Transform>().position=pos;
            }
        }
    }
}


   void LoadMap(){
    GameObject go=new GameObject("TILE_ANCHOR");
   
        TILE_ANCHOR=go.transform;
         DungeonCreator.setmap();
         ShowMap();
         
   }

   void Start(){
   dray=GameObject.Find("/Dray");
    dray.transform.position=new Vector3(startx,starty+1,0);

    EnemyType=new List<GameObject>(){EnemyType1,EnemyType2};
    SetEnemy();
 
    
   }
       void ShowMap(){
        int W=112;
        int H=77;
        TILES=new Tile1[W,H];
        for (int j=0;j<H;j++){
            for (int i=0;i<W;i++){
                if(DungeonCreator.dungeon[i,j]!=0){
                    Tile1 ti=Instantiate<Tile1>(tilePrefab);
                    ti.transform.SetParent(TILE_ANCHOR);
                    ti.SetTile(i,j);
                    TILES[i,j]=ti;
                    
                      
                }
            } 
        }

    }
    public   void SetEnemy(){
List <GameObject> enemy=new List<GameObject>();
GameObject go;
GameObject go1;
GameObject go2;
GameObject go3;

      
                

GameObject Boss1=Instantiate<GameObject>(BossType1);
Boss1.transform.position=new Vector3(DungeonCreator.Boss1x*16+8,DungeonCreator.Boss1y*11+5);
 

GameObject Boss2=Instantiate<GameObject>(BossType2);
Boss2.transform.position=new Vector3(DungeonCreator.Boss2x*16+8,DungeonCreator.Boss2y*11+5);


GameObject Boss3=Instantiate<GameObject>(BossType3);
Boss3.transform.position=new Vector3(DungeonCreator.Boss3x*16+8,DungeonCreator.Boss3y*11+5);




           
         for (int k=0;k<7;k++){
            for (int i=0;i<7;i++){
                if(DungeonCreator.nstanze[i,k]==1 )
            {
               if( (i==DungeonCreator.Boss1x && k==DungeonCreator.Boss1y) || (i==DungeonCreator.Boss2x && k==DungeonCreator.Boss2y) || (i==DungeonCreator.Boss3x && k==DungeonCreator.Boss3y) || (i==(startx-7)/16  && k==(starty-4.5f)/11 ) ) {
               }
               else{   
 int enemynumber=Random.Range(1,5);
 switch(enemynumber){
        case 1:
go=Instantiate<GameObject>(EnemyType[Random.Range(0,2)]);
go.transform.position=new Vector3(i*16+8,k*11+5);
        break;
        case 2:
        go=Instantiate<GameObject>(EnemyType[Random.Range(0,2)]);
go.transform.position=new Vector3(i*16+6,k*11+5);
go1=Instantiate<GameObject>(EnemyType1);
go1.transform.position=new Vector3(i*16+8,k*11+5);
enemy.Add(go);
enemy.Add(go1);
        break;
        case 3:
go=Instantiate<GameObject>(EnemyType[Random.Range(0,2)]);
go.transform.position=new Vector3(i*16+8,k*11+4);
go1=Instantiate<GameObject>(EnemyType[Random.Range(0,2)]);
go1.transform.position=new Vector3(i*16+6,k*11+4);
go2=Instantiate<GameObject>(EnemyType[Random.Range(0,2)]);
go2.transform.position=new Vector3(i*16+8,k*11+6);
enemy.Add(go);
enemy.Add(go1);
enemy.Add(go2);
        break;
        case 4:
go=Instantiate<GameObject>(EnemyType[Random.Range(0,2)]);
go.transform.position=new Vector3(i*16+6,k*11+4);
go2=Instantiate<GameObject>(EnemyType[Random.Range(0,2)]);
go2.transform.position=new Vector3(i*16+8,k*11+4);
go1=Instantiate<GameObject>(EnemyType[Random.Range(0,2)]);
go1.transform.position=new Vector3(i*16+643,k*11+6);
go3=Instantiate<GameObject>(EnemyType[Random.Range(0,2)]);
go3.transform.position=new Vector3(i*16+8,k*11+6);
enemy.Add(go);
enemy.Add(go1);
enemy.Add(go2);
enemy.Add(go3);
        break;
    }

            }

            }
            
            
            }}
    }

   
}