using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateKeeper : MonoBehaviour
{
    const int lockedR=73;
    const int lockedUR=56;
    const int lockedUL=57;
    const int lockedL=72;
    const int lockedDL=88;
    const int lockedDR=89;

    const int openR=70;
    const int openUR=52;
    const int openUL=53;
    const int openL=67;
    const int openDL=84;
    const int openDR=85;

    private KeyMaster keys;
    

    void Awake(){
        keys=GetComponent<KeyMaster>();

    }
    void OnCollisionStay(Collision coll){
        print("Entrato nel metodo");
        if(keys.keyCount<1){ 
            
            return ;
            }
            Tile ti=coll.gameObject.GetComponent<Tile>();
            if(ti==null) return ;


int facing =keys.GetFacing();
Tile ti2;

switch(ti.tileNum){
    case lockedR:
    if(facing!=0) return ;
    ti.SetTile(ti.x,ti.y,openR);
    break;
     case lockedUR:
     if(facing!=1) return ;
     ti.SetTile(ti.x,ti.y,openUR);
     ti2=TileCamera.TILES[ti.x-1,ti.y];
     ti2.SetTile(ti2.x,ti2.y,openUL);
    break;
     case lockedUL:
     if(facing!=1) return ;
     ti.SetTile(ti.x,ti.y,openUL);
     ti2=TileCamera.TILES[ti.x+1,ti.y];
     ti2.SetTile(ti2.x,ti2.y,openUR);
    break;
     case lockedL:
     if(facing!=2) return ;
     ti.SetTile(ti.x,ti.y,openUR);
    break;
     case lockedDL:
     if(facing!=3) return;
     ti.SetTile(ti.x,ti.y,openDL);
     ti2=TileCamera.TILES[ti.x+1,ti.y];
     ti2.SetTile(ti2.x,ti2.y,openDR);
    break;
     case lockedDR:
     if(facing!=3) return ;
     ti.SetTile(ti.x,ti.y,openDR);
     ti2=TileCamera.TILES[ti.x-1,ti.y];
     ti2.SetTile(ti2.x,ti2.y,openDL);
    break;
    default:
    return;
}
keys.keyCount--;
        


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
