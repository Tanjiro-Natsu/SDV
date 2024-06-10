using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EvilWizard : Enemy,IFacingMover

{
    private float timeattack=0;
    private int counter=0;
    [Header("Set in Inspector:EvilWizard")]
    public int speed=2;
    public float timeThinkMin=1f;
    public float timeThinkMax=4f;
    public GameObject bar;
    public GameObject name;
    public GameObject Chest1;
    public GameObject Chest2;
    public GameObject Chest3;


    [Header("Set Dynamically:EvilWizard")]
    public int facing=0;
    public float timeNextDecision=0;
    private InRoom inRm;
    public float hitDuration=1f;
    private float hitDone=0;
    public bool hit=false;
    private int death=0;
    private GameObject o1;
private GameObject o2;
private int bossinforcreated=0;
private static float x;
private static float y;
private static float x1;
private static float y1;

protected override void Awake(){
    base.Awake();
    inRm=GetComponent<InRoom>();
}
public int GetFacing(){
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

void CreateInforBoss(){
  o1=Instantiate<GameObject>(bar);
        o1.transform.position=new Vector3(x,y,-10);
         o2=Instantiate<GameObject>(name);
        o2.transform.position=new Vector3(x1,y1,0);
        Transform trans=o2.GetComponent<Transform>().Find("/Name");
       GameObject.Find("BossName(Clone)/Name").GetComponent<Text>().text="EvilWizard";  
       bossinforcreated=1;
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
        timeattack=Time.time+2f;
maxHealth=(SceneManager.GetActiveScene().buildIndex+1)*10;
health=maxHealth;
Transform pos=GetComponent<Transform>();
      x=pos.position.x-1.3f;
   y=pos.position.y-5;
   x1=pos.transform.position.x+3;
   y1=pos.transform.position.y-4;
    }

     override protected void Update()
    {
        
        if(death==0){
            base.Update();
        if(hit && Time.time>hitDone) hit=false;
        if(hit){
            if(facing==2){
 anim.CrossFade("EvilWizard_hit_1",0);
        }
        else{
 anim.CrossFade("EvilWizard_hit_0",0);
        }
        return ;
        }
        else{
    
         Transform dray=transform.Find("/Dray");
        if(dray.position.x<14 && dray.position.y>34 && dray.position.y<42){
      if(bossinforcreated==0){
        CreateInforBoss();
      }
      o1.GetComponent<BossHealthBar>().health=(int)health;
        if(knockback) return ;
         CapsuleCollider collider=GetComponent<CapsuleCollider>();
         
       if(Time.time>=timeNextDecision){
        DeciceDirection();
       }
       if(counter==0){
if(facing==2){
    anim.CrossFade("EvilWizard_attack_1",0);
    collider.center=new Vector3(-0.45f,0.225f,0);
    collider.enabled=true;
}
else{
anim.CrossFade("EvilWizard_attack_0",0);
collider.center=new Vector3(0.45f,0.225f,0);
collider.enabled=true;
}
       }
       else{
        collider.enabled=false;
anim.CrossFade("EvilWizard_walk_"+facing,0);  
       }
      rigid.velocity=directions[facing]*speed;
       
    }
    else{
        anim.CrossFade("EvilWizard_idle",0);
          bossinforcreated=0;
    if(o1!=null && o2!=null){
        Destroy(o1);
        Destroy(o2);
    }
    }
    }}
    }


    void DeciceDirection(){
        counter=Random.Range(0,2);
         facing=Random.Range(0,4);
    timeNextDecision=Time.time+Random.Range(timeThinkMin,timeThinkMax);
    }

        void OnTriggerEnter(Collider collid){
        if(invincible) return ;
        DamageEffect def=collid.gameObject.GetComponent<DamageEffect>();
        if(def==null)return ;
        health-=def.damage;
        if(health<=0) Die();
hit=true;
        invincible=true;
        invincibleDone=Time.time+invincibleDuration;
        if(def.knockback){
            Vector3 delta=transform.position-collid.transform.root.position;
            if(Mathf.Abs(delta.x)>=Mathf.Abs(delta.y)){
                delta.x=(delta.x > 0) ? 1 : -1;
                delta.y=0;
            } else {
                delta.x=0;
                delta.y=(delta.y>0) ? 1 :-1;

            }
            knockbackVel=delta*knockbackSpeed;
            rigid.velocity=knockbackVel;

            knockback=true;
            knockbackDone=Time.time+knockbackDuration;
            anim.speed=0;
        }
    }
     void Die(){
        death=1;
         anim.CrossFade("EvilWizard_dead",0);
         Destroy(o1);
        Destroy(o2);
        Destroy(gameObject,2.5f);
        int percentage=Random.Range(1,100);
        if(percentage>=23 && percentage<33){
            GameObject chest=Instantiate(Chest3);
            chest.transform.position=new Vector3(6,38);
        }
        if(percentage>=33 && percentage<63){
            GameObject chest=Instantiate(Chest2);
            chest.transform.position=new Vector3(6,38);
        }
        if(percentage<23 && percentage>=63){
            GameObject chest=Instantiate(Chest1);
            chest.transform.position=new Vector3(6,38);
        }
    }

}
