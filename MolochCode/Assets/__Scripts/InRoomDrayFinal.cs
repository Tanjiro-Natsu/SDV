using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InRoomDrayFinal : MonoBehaviour
{
    static public float ROOM_W=32;
    static public float ROOM_H=22;
    static public float WALL_T=3;
    static public int MAX_RM_X=20;
    static public float MAX_RM_Y=20;
    

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

}
