using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCamera : MonoBehaviour
{
    private static int W,H;
    static private int [,] MAP;
    static public Sprite[] SPRITES;
    static public Transform TILE_ANCHOR;
    public static Tile[,] TILES;
    static public string COLLISIONS;

    [Header("Set in Inspector")]
    public TextAsset mapData;
    public Texture2D mapTiles;
    public TextAsset mapCollision;
    public Tile tilePrefab;

    void Awake(){
        COLLISIONS=Utils.RemoveLineEndings(mapCollision.text);
        LoadMap();
        DungeonCreator.setmap();
    }

    void LoadMap(){
        GameObject go=new GameObject("TILE_ANCHOR");
        TILE_ANCHOR=go.transform;
        SPRITES=Resources.LoadAll<Sprite>(mapTiles.name);
        string [] lines=mapData.text.Split("\n");
        H=lines.Length;
        string [] tileNums=lines[0].Split(' ');
        W=tileNums.Length;
        Debug.Log("W="+W+"  H="+H);
        System.Globalization.NumberStyles hexnum;
        hexnum=System.Globalization.NumberStyles.HexNumber;
        MAP=new int[W,H];
        for(int i=0;i<H;i++){
            tileNums=lines[i].Split(' ');
            for(int j=0;j<W;j++){
                if(tileNums[j]==".."){
                    MAP[j,i]=0;
                } else {
                    MAP[j,i]=int.Parse(tileNums[j],hexnum);

                }

            }
        }
       

ShowMap();

    }
    void ShowMap(){
        TILES=new Tile[W,H];
        for (int j=0;j<H;j++){
            for (int i=0;i<W;i++){
                if(MAP[i,j]!=0){
                    Tile ti=Instantiate<Tile>(tilePrefab);
                    ti.transform.SetParent(TILE_ANCHOR);
                    ti.SetTile(i,j);
                    TILES[i,j]=ti;
                    
                      
                }
            } 
        }

    }
    static public int GET_MAP(int x,int y){
        if(x<0 || x>=W || y<0 || y>=H){
            return -1;
        } 
        return MAP[x,y];
    }
    static public float  GET_MAP(float x,float y){
        int tX=Mathf.RoundToInt(x);
        int tY=Mathf.RoundToInt(y-0.25f);
        return GET_MAP(tX,tY);

    }

    static public void SET_MAP(int x,int y,int tNum){
        if(x<0 || x>=W || y<0 || y>=H){
            return ;
        }
        MAP[x,y]=tNum;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
