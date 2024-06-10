using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Mimic:Enemy,IFacingMover

{
    private float timeattack=0;
    private int counter=0;
    [Header("Set in Inspector:Mimic")]
    public int speed=2;
    public float timeThinkMin=1f;
    public float timeThinkMax=2f;
    public GameObject bar;
    public GameObject name;
    public GameObject chestlvl1;
    public GameObject chestlvl2;
    public GameObject chestlvl3;

    [Header("Set Dynamically:Mimic")]
    public int facing=0;
    public float timeNextDecision=0;
    private InRoom inRm;
    public float hitDuration=1f;
    private float hitDone=0;
    public bool hit=false;
    private int death=0;
    private GameObject go;
private int frame=0;
private Animator armspellanimator;
private GameObject o1;
private GameObject o2;
private int bossinforcreated=0;

private static float x;
private static float y;
private static float x1;
private static float y1;
private Transform positionStart;
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
void CreateInforBoss(){
  o1=Instantiate<GameObject>(bar);
        o1.transform.position=new Vector3(x,y,-10);
         o2=Instantiate<GameObject>(name);
        o2.transform.position=new Vector3(x1,y1,0);
        Transform trans=o2.GetComponent<Transform>().Find("/Name");
       GameObject.Find("BossName(Clone)/Name").GetComponent<Text>().text="Mimic";  
       bossinforcreated=1;
}
    // Start is called before the first frame update
    void Start()
    {
        maxHealth=(SceneManager.GetActiveScene().buildIndex+1)*10;
        health=maxHealth;
        timeattack=Time.time+2f;
      positionStart=GetComponent<Transform>();
      x=positionStart.position.x-2.7f;
   y=positionStart.position.y-5;
   x1=positionStart.transform.position.x+1.8f;
   y1=positionStart.transform.position.y-4;
    }

     new void Update()
      
    {
        
        if(death==0){
        if(hit && Time.time>hitDone) hit=false;
        if(hit){
            if(facing==2){
 anim.CrossFade("Mimic_hit_1",0);
        }
        else{
 anim.CrossFade("Mimic_hit_0",0);
        }
        return ;
        }
        else{
    
         Transform dray=transform.Find("/Dray");

   if(maxHealth>health)
    {
        payload();
    }
    else{anim.CrossFade("Mimic",0);
    bossinforcreated=0;
    if(o1!=null && o2!=null){
        Destroy(o1);
        Destroy(o2);
    }}
    }}
    }


    void DeciceDirection(){
        counter=Random.Range(0,4);
         facing=Random.Range(0,4);
    timeNextDecision=Time.time+Random.Range(timeThinkMin,timeThinkMax);
    }

void payload(){
        if(bossinforcreated==0){
        CreateInforBoss();
      }
        o1.GetComponent<BossHealthBar>().health=(int)health;
        if(knockback) return ;
         
       if(Time.time>=timeNextDecision){
        DeciceDirection();
       }
       Vector3 pos=GetComponent<Transform>().position;
 switch(counter){
    case 0:
anim.CrossFade("Mimic_attack_0",0);
rigid.velocity=directions[facing]*speed;
    break;
     case 1:
    anim.CrossFade("Mimic_attack_2",0);
transform.position=new Vector3(pos.x+1,pos.y+1,0);
    break;
     case 2:
    anim.CrossFade("Mimic_attack_1",0);
rigid.velocity=directions[facing]*speed;
    break;
     case 3:
    anim.CrossFade("Mimic_attack_2",0);
transform.position=new Vector3(pos.x-1,pos.y-1,0);
    break;
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
 anim.CrossFade("Mimic_death_1",0);
        }
        else{
 anim.CrossFade("Mimic_death_1",0);
        }
        Destroy(o1);
        Destroy(o2);
        Destroy(gameObject,1.3f);
       if(SceneManager.GetActiveScene().buildIndex==0){
  int percentage=Random.Range(1,100);
        if(percentage>=23 && percentage<33){
            GameObject chest=Instantiate(chestlvl3);
            chest.transform.position=new Vector3(87.5f,49);
        }
        if(percentage>=33 && percentage<63){
            GameObject chest=Instantiate(chestlvl2);
            chest.transform.position=new Vector3(87.5f,49);
        }
        if(percentage<23 && percentage>=63){
            GameObject chest=Instantiate(chestlvl1);
            chest.transform.position=new Vector3(87.5f,49);
        }
       }
       else{
          int percentage=Random.Range(1,100);
        if(percentage>=23 && percentage<33){
            GameObject chest=Instantiate(chestlvl3);
            chest.transform.position=new Vector3(x+2.7f,y+5);
        }
        if(percentage>=33 && percentage<63){
            GameObject chest=Instantiate(chestlvl2);
            chest.transform.position=new Vector3(x+2.7f,y+5);
        }
        if(percentage<23 && percentage>=63){
            GameObject chest=Instantiate(chestlvl1);
            chest.transform.position=new Vector3(x+2.7f,y+5);
        }
       }

        
       /* GameObject go;
                 go=Instantiate<GameObject>(guaranteedItemDrop);
            go.transform.position=transform.position;
        Destroy(go);*/
    }
   

}
