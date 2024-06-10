using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InRoomDray : MonoBehaviour
{
    static public float ROOM_W=16;
    static public float ROOM_H=11;
    static public float WALL_T=2;
    static public int MAX_RM_X=9;
    static public float MAX_RM_Y=9;
    static public int stanzattuale=1;
static public int lvl=1;
    static public List<Vector2[]> DoorsMap1=new List<Vector2[]>();
    static public List<int> coordinateportelvl1=new List<int>(){52,53,70,67,56,57,84,85,88,89,72,73,74,75};

    static public  List<Vector2> closedoorMap1=new List<Vector2>(){new Vector2(39.5f,8.1f),new Vector2(17,38),new Vector2(71.5f,41.1f),new Vector2(39.5f,52.1f),new Vector2(33.9f,60)};
    
    static public List<Vector2[]> ListaStanze=new List<Vector2[]>();
    

    [Header("Set in Inspector")]
    public bool keepInRoom=true;
    public float gridMult=1;
    



    public Vector2 roomPos{
        get{
        Vector2 tPos=transform.position;
        tPos.x%=ROOM_W;
        tPos.y%=ROOM_H;
        return tPos;
        }
        set{
            Vector2 rm=roomNum;
            rm.x*=ROOM_W;
            rm.y*=ROOM_H;
            rm+=value;
            transform.position=rm;

        }
    }

    public Vector2 roomNum{
        get{
Vector2 tPos=transform.position;
tPos.x=Mathf.Floor(tPos.x/ROOM_W);
tPos.y=Mathf.Floor(tPos.y/ROOM_H);
return tPos;

        }
        set{
Vector2 rPos=roomPos;
Vector2 rm=value;
rm.x*=ROOM_W;
rm.y*=ROOM_H;
transform.position=rm+rPos;

        }
    }
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(keepInRoom){
            Vector2 rPos=roomPos;
            rPos.x=Mathf.Clamp(rPos.x,WALL_T,ROOM_W-1-WALL_T);
            rPos.y=Mathf.Clamp(rPos.y,WALL_T,ROOM_H-1-WALL_T);
            roomPos=rPos;
        }
        
    }
    public Vector2 GetRoomPosOnGrid(float mult=-1){
        if(mult==-1){
            mult=gridMult;
        }
Vector2 rPos=roomPos;
         rPos/=mult;
        rPos.x=Mathf.Round(rPos.x);
        rPos.y=Mathf.Round(rPos.y);
        rPos*=mult;
        return rPos;
    }

    void Update(){
        DoorsMap1.Insert(0, new Vector2[]{
    new Vector2(29.1f+(11+5)*(stanzattuale-1),5),new Vector2(23.5f+(11+5)*(stanzattuale-1),8.1f),new Vector2(17.9f+(11+5)*(stanzattuale-1),5),new Vector2(23.5f+(11+5)*(stanzattuale-1),1.9f)
    });
    DoorsMap1.Insert(1,new Vector2[]{new Vector2(0,0),new Vector2(39.5f,19.1f),new Vector2(0,0),new Vector2(39.5f,12.9f)});
    DoorsMap1.Insert(2, new Vector2[]{
    new Vector2(29.1f+(11+5)*(stanzattuale-1),27),new Vector2(23.5f+(11+5)*(stanzattuale-1),30.1f),new Vector2(17.9f+(11+5)*(stanzattuale-1),27),new Vector2(23.5f+(11+5)*(stanzattuale-1),23.9f)
    });
    DoorsMap1.Insert(3, new Vector2[]{
    new Vector2(29.1f+(11+5)*(stanzattuale-1),38),new Vector2(23.5f+(11+5)*(stanzattuale-1),41.1f),new Vector2(17.9f+(11+5)*(stanzattuale-1),38),new Vector2(23.5f+(11+5)*(stanzattuale-1),34.9f)
    });
      DoorsMap1.Insert(4,new Vector2[]{
    new Vector2(29.1f+(11+5)*(stanzattuale-1),49),new Vector2(23.5f+(11+5)*(stanzattuale-1),52.1f),new Vector2(17.9f+(11+5)*(stanzattuale-1),49),new Vector2(23.5f+(11+5)*(stanzattuale-1),45.9f)
    });
    DoorsMap1.Insert(5,new Vector2[]{
    new Vector2(29.1f+(11+5)*(stanzattuale-1),60),new Vector2(23.5f+(11+5)*(stanzattuale-1),63.1f),new Vector2(17.9f+(11+5)*(stanzattuale-1),60),new Vector2(23.5f+(11+5)*(stanzattuale-1),56.9f)
    });
    
    }
}
