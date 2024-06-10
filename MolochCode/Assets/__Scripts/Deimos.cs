using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Deimos:Enemy,IFacingMover

{
    private float timeattack=0;
    private int counter=0;
    [Header("Set in Inspector:Deimos")]
    public int speed=2;
    public float timeThinkMin=1f;
    public float timeThinkMax=2f;
    public GameObject bar;
    public GameObject name;
    public GameObject Wrath;
    public GameObject Bullet;


    [Header("Set Dynamically:Deimos")]
    public int facing=0;
    public float timeNextDecision=0;
    private InRoomFinal inRm;
    public float hitDuration=1f;
    private float hitDone=0;
    public bool hit=false;
    private int death=0;
    private GameObject go;
private int frame=0;
private GameObject o1;
private GameObject o2;
private Vector3 oss;
private int chooseattack=2;
private GameObject bullet1;
private GameObject bullet2;
private GameObject bullet3;
private GameObject bullet4;
private GameObject bullet5;
private GameObject bullet6;
private GameObject bullet7;
private GameObject bullet8;
private CapsuleCollider capsule;
protected override void Awake(){
    base.Awake();
    inRm=GetComponent<InRoomFinal>();
    
          
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
void CreateInforBoss(){
     GameObject Dray=GameObject.Find("/Dray");
   oss=Dray.transform.position;
  o1=Instantiate<GameObject>(bar);
        o1.transform.position=new Vector3(oss.x-2.53f,oss.y-3.71f,-11);
         o2=Instantiate<GameObject>(name);
         o1.GetComponent<BossHealthBar>().health=(int)health;
        o2.transform.position=new Vector3(oss.x+1.8f,oss.y-2.51f,0);
        Transform trans=o2.GetComponent<Transform>().Find("/Name");
       GameObject.Find("BossName(Clone)/Name").GetComponent<Text>().text="Deimos";  
}
    // Start is called before the first frame update
    void Start()
    {
        maxHealth=100;
        health=maxHealth;
        timeattack=Time.time+2f;
        capsule=GetComponent<CapsuleCollider>();
        capsule.enabled=false;
         CreateInforBoss();
    }

     protected override void Update()
      
    {
        
        if(death==0){
base.Update();
capsule.enabled=false;
if(bullet1!=null){
    Vector3 pos1=bullet1.transform.position;
Vector3 pos2=bullet2.transform.position;
Vector3 pos3=bullet3.transform.position;
Vector3 pos4=bullet4.transform.position;
Vector3 pos5=bullet5.transform.position;
Vector3 pos6=bullet6.transform.position;
Vector3 pos7=bullet7.transform.position;
Vector3 pos8=bullet8.transform.position;
pos1.y+=0.5f;
pos2.x+=0.5f;
pos2.y+=0.5f;
pos3.x+=0.5f;
pos4.x+=0.5f;
pos4.y-=0.5f;
pos5.y-=0.5f;
pos6.x-=0.5f;
pos6.y-=0.5f;
pos7.x-=0.5f;
pos8.x-=0.5f;
pos8.y+=0.5f;
bullet1.transform.position=pos1;
bullet2.transform.position=pos2;
bullet3.transform.position=pos3;
bullet4.transform.position=pos4;
bullet5.transform.position=pos5;
bullet6.transform.position=pos6;
bullet7.transform.position=pos7;
bullet8.transform.position=pos8;
}
       payload();
    }
    
    }
    


    void DeciceDirection(){
        counter=Random.Range(0,6);
         facing=Random.Range(0,4);
    timeNextDecision=Time.time+Random.Range(timeThinkMin,timeThinkMax);
    }

void payload(){
     GameObject Dray=GameObject.Find("/Dray");
   oss=Dray.transform.position;
        o1.transform.position=new Vector3(oss.x-2.53f,oss.y-3.71f,-11);
         o1.GetComponent<BossHealthBar>().health=(int)health;
        o2.transform.position=new Vector3(oss.x+1.8f,oss.y-2.51f,0);
        if(knockback) return ;
          
       if(Time.time>=timeNextDecision){
        DeciceDirection();
       }
        if(counter<3){
            if(facing==2){
            anim.CrossFade("Deimos_move_1",0);}
            else{
                anim.CrossFade("Deimos_move_0",0);
            }
            rigid.velocity=directions[facing]*speed;
        }
        else {
            GameObject fi=GameObject.Find("/Dray");
            Vector3 check=fi.transform.position;
            Vector3 checkboss=transform.position;
            if(Mathf.Abs(check.x-checkboss.x)<3 && Mathf.Abs(check.y-checkboss.y)<3){
  if(facing==2){
anim.CrossFade("Deimos_attack_0_1",0);
capsule.center=new Vector3(0.6f,-0.5f,0);
capsule.enabled=true;
            }
            else{
anim.CrossFade("Deimos_attack_1_1",0);
capsule.center=new Vector3(-0.6f,-0.5f,0);
capsule.enabled=true;
            }

            }
            
            else{
            if(chooseattack<3){
            if(frame==0){
   wrath();
          if(facing==2){
anim.CrossFade("Deimos_attack_0_2",0);
            }
            else{
anim.CrossFade("Deimos_attack_1_2",0);
            }

}
frame++;
if(frame==30){
    frame=0;
    chooseattack=Random.Range(0,6);
}
        }
        else{
            
            
                  if(frame==0){
                     transform.position=new Vector3(15,13,0);
                    bullet();
  
          if(facing==2){
anim.CrossFade("Deimos_attack_0_2",0);
            }
            else{
anim.CrossFade("Deimos_attack_1_2",0);
            }

}
frame++;
if(frame==30){
    frame=0;
    chooseattack=Random.Range(0,6);
}
        }
             
        }}
   
      
}
     void OnTriggerEnter(Collider collid){
        if(invincible) return ;
         DamageEffect def=collid.gameObject.GetComponent<DamageEffect>();
        if(def==null)return ;
        health-=def.damage;
      
  if(health<=0){
    Destroy(o1);
    Destroy(o2);
     Destroy(gameObject);
       
      }
        invincible=true;
        invincibleDone=Time.time+invincibleDuration;
         

     }
 
void wrath(){
GameObject attack1=Instantiate(Wrath);
attack1.transform.position=new Vector3(Random.Range(3,28),Random.Range(3,18),0);
Destroy(attack1,1);
GameObject attack2=Instantiate(Wrath);
attack2.transform.position=new Vector3(Random.Range(3,28),Random.Range(3,18),0);
Destroy(attack2,1);
GameObject attack3=Instantiate(Wrath);
attack3.transform.position=new Vector3(Random.Range(3,28),Random.Range(3,18),0);
Destroy(attack3,1);
GameObject attack4=Instantiate(Wrath);
attack4.transform.position=new Vector3(Random.Range(3,28),Random.Range(3,18),0);
Destroy(attack4,1);
GameObject attack5=Instantiate(Wrath);
attack5.transform.position=new Vector3(Random.Range(3,28),Random.Range(3,18),0);
Destroy(attack5,1);
}
void bullet(){
 bullet1=Instantiate(Bullet);
 bullet2=Instantiate(Bullet);
 bullet3=Instantiate(Bullet);
 bullet4=Instantiate(Bullet);
 bullet5=Instantiate(Bullet);
 bullet6=Instantiate(Bullet);
 bullet7=Instantiate(Bullet);
 bullet8=Instantiate(Bullet);
 bullet1.transform.position=new Vector3(15,14,0);
 bullet2.transform.position=new Vector3(16,14,0);
 bullet3.transform.position=new Vector3(16,13,0);
 bullet4.transform.position=new Vector3(16,12,0);
 bullet5.transform.position=new Vector3(15,12,0);
 bullet6.transform.position=new Vector3(14,12,0);
 bullet7.transform.position=new Vector3(14,13,0);
 bullet8.transform.position=new Vector3(14,14,0);
 Destroy(bullet1,1);
 Destroy(bullet2,1);
 Destroy(bullet3,1);
 Destroy(bullet4,1);
 Destroy(bullet5,1);
 Destroy(bullet6,1);
 Destroy(bullet7,1);
 Destroy(bullet8,1);
}
}
