using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Mushroom:Enemy,IFacingMover

{
    private float timeattack=0;
    private int counter=0;
    [Header("Set in Inspector:Mushroom")]
    public int speed=2;
    public float timeThinkMin=1f;
    public float timeThinkMax=2f;

    [Header("Set Dynamically:Mushroom")]
    public int facing=0;
    public float timeNextDecision=0;
    private InRoom inRm;
    public float hitDuration=1f;
    private float hitDone=0;
    public bool hit=false;
    private int death=0;
    private GameObject go;
private int frame=0;
private GameObject o1;
private GameObject o2;

private static float x;
private static float y;
private static float x1;
private static float y1;
private SphereCollider box;
public GameObject Sound;
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
        maxHealth=(SceneManager.GetActiveScene().buildIndex+1)*4;
        health=maxHealth;
        timeattack=Time.time+2f;
        box=GetComponent<SphereCollider>();
    }

     new void Update()
      
    {
        
        if(death==0){
            box.enabled=false;
        if(hit && Time.time>hitDone) hit=false;
        if(hit){
            if(facing==2){
 anim.CrossFade("Mushroom_hit_1",0);
        }
        else{
 anim.CrossFade("Mushroom_hit_0",0);
        }
        return ;
        }
        else{
        payload();
    }}
    }


    void DeciceDirection(){
        counter=Random.Range(0,4);
         facing=Random.Range(0,4);
    timeNextDecision=Time.time+Random.Range(timeThinkMin,timeThinkMax);
    }

void payload(){
       
        
        
         
       if(Time.time>=timeNextDecision){
        DeciceDirection();
       }
       if(counter<2 ){
if(facing==2){
    anim.CrossFade("Mushroom_attack_1",0); 
    box.center=new Vector3(0.2f,0,0);
    box.enabled=true;
}
else{
anim.CrossFade("Mushroom_attack_0",0);
box.center=new Vector3(-0.2f,0,0);
    box.enabled=true;
}
       }
       else {
       box.enabled=false;
  if(facing==2){
 anim.CrossFade("Mushroom_move_0",0);
        }
        else{
 anim.CrossFade("Mushroom_move_1",0);
        }
         rigid.velocity=directions[facing]*speed;
       }  
}
     void OnTriggerEnter(Collider collid){
        if(hit) return;
         DamageEffect def=collid.gameObject.GetComponent<DamageEffect>();
        if(def==null)return ;
        health-=def.damage;
      
  if(health<=0){
        Die();
      }
        hit=true;
         hitDone=Time.time+hitDuration;
         

     }
     void Die(){
        death=1;
          if(facing==2){
 anim.CrossFade("Mushroom_death_0",0);
 anim.speed=1;
        }
        else{
 anim.CrossFade("Mushroom_death_1",0);
 anim.speed=1;
        }
       
Destroy(gameObject,1);
GameObject go;
 Destroy(Instantiate(Sound),1);
        int a=Random.Range(0,20);
        if(a<5){
                 go=Instantiate<GameObject>(item1);
            go.transform.position=transform.position;
        }
           else if(a>14){
            go=Instantiate<GameObject>(item2);
            go.transform.position=transform.position;}
        
        Destroy(gameObject);
        
       /* GameObject go;
                 go=Instantiate<GameObject>(guaranteedItemDrop);
            go.transform.position=transform.position;
        Destroy(go);*/
    }
}
