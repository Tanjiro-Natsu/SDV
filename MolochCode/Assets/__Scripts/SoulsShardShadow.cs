using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoulShardShadow:Enemy,IFacingMover

{
    private float timeattack=0;
    private int counter=0;
    [Header("Set in Inspector:SoulShardShadow")]
    public int speed=2;
    public float timeThinkMin=1f;
    public float timeThinkMax=2f;

    [Header("Set Dynamically:SoulShardShadow")]
    public int facing=0;
    public int space=-20;
    public float timeNextDecision=0;
    private InRoom inRm;
    public float hitDuration=1f;
    private float hitDone=0;
    public bool hit=false;
    private int death=0;
    private GameObject go;
private int frame=0;
private SphereCollider box;
private BoxCollider collider;

private int ai=0;
protected override void Awake(){
    base.Awake();
    inRm=GetComponent<InRoom>();
    
          
}

public  int GetFacing(){
    return facing;
}
public bool moving{
    get{return true;}
}
public float GetSpeed(){
    return speed;
}
public float gridMult{
    get{
        return inRm.gridMult;
    }
}
public Vector2 roomPos{
    get{return inRm.roomPos;}
    set{inRm.roomPos=value;}
}

public Vector2 roomNum{
    get{return inRm.roomNum;}
    set{inRm.roomNum=value;}
}
public Vector2 GetRoomPosOnGrid(float mult=-1){
    return inRm.GetRoomPosOnGrid(mult);
}

    // Start is called before the first frame update
    void Start()
    {
        maxHealth=(SceneManager.GetActiveScene().buildIndex+1)*10;
        health=maxHealth;
        timeattack=Time.time+2f;
        collider=GetComponent<BoxCollider>();
        collider.enabled=false;
        box=GetComponent<SphereCollider>();
    box.enabled=false;
    
    }

     new void Update()
     
    {
        ai=0; 
        if(death==0){
              if(Random.Range(0,100)<5) {

        if(space==-20 && ai==0){
            ai=1;
            space=-0;
            collider.enabled=true;
            box.enabled=false;
        }
        if(space==0 && ai==0){
            space=-20;
            collider.enabled=false;
             box.enabled=false;
        }


}
            if(space==-20){
                anim.CrossFade("SoulsShard_invisible",0);
            }
            else{
base.Update();
            
            box.enabled=false;
        
         Transform dray=transform.Find("/Dray");
 if(dray.position.x>DungeonCreator.Boss3x*16 && dray.position.y>DungeonCreator.Boss3y*11 && dray.position.y<DungeonCreator.Boss3y*11+10 && dray.position.x<DungeonCreator.Boss3x*16+15 && SceneManager.GetActiveScene().buildIndex>0)
    {
        payload();
    }
    else{anim.CrossFade("SoulShard_idle",0);
    }
    }
    
    }
    }


    void DeciceDirection(){
        counter=Random.Range(0,5);
         facing=Random.Range(0,4);
    timeNextDecision=Time.time+Random.Range(timeThinkMin,timeThinkMax);
    }

void payload(){
    
        if(knockback) return ;
        
         
       if(Time.time>=timeNextDecision){
        DeciceDirection();
       }
       if(counter<3){
if(facing==2){
    anim.CrossFade("SoulShard_attack_0",0); 
    box.center=new Vector3(-0.17f,-0.1f,space);
    box.enabled=true;
}
else{
anim.CrossFade("SoulShard_attack_1",0);
box.center=new Vector3(0.1f,-0.1f,space);
    box.enabled=true;
}
       }
       else if(counter>2) {
       box.enabled=false;
  if(facing==2){
 anim.CrossFade("SoulsShard_move_0",0);
        }
        else{
 anim.CrossFade("SoulShard_move_1",0);
        }
         rigid.velocity=directions[facing]*speed;
       }
}
     void OnTriggerEnter(Collider collid){
       if(invincible) return ;
         DamageEffect def=collid.gameObject.GetComponent<DamageEffect>();
        if(def==null)return ;
        health-=def.damage;
      
  if(health<=0){
        Die();
       
      }
         invincible=true;
        invincibleDone=Time.time+invincibleDuration;
       
         

     }
     void Die(){
        death=1;
          if(facing==2){
 anim.CrossFade("SoulShard_death_0",0);
        }
        else{
 anim.CrossFade("SoulShard_death_1",0);
        }
        Destroy(gameObject,1.3f);
      

        
       /* GameObject go;
                 go=Instantiate<GameObject>(guaranteedItemDrop);
            go.transform.position=transform.position;
        Destroy(go);*/
    }
   

}
