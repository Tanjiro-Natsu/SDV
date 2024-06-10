using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class KingGreenSlime :Enemy,IFacingMover
{

    private float degree;
    private int  counter;
    private int death=0;
   
[Header("Set in Inspector:KingGreenSlime")]
    public int speed=2;
    public float timeThinkMin=1f;
    public float timeThinkMax=4f;
    public GameObject bar;
    public GameObject name;
    public GameObject Chest1;
    public GameObject Chest2;
    public GameObject Chest3;

    [Header("Set Dynamically:KingGreenSlime")]
    public int facing=0;
    public float timeNextDecision=0;
    private InRoom inRm;
    public float hitDuration=1f;
    public bool hit=false;
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
    anim=GetComponent<Animator>();
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
       GameObject.Find("BossName(Clone)/Name").GetComponent<Text>().text="KingGreenSlime";  
       bossinforcreated=1;
}

    // Start is called before the first frame update
    void Start()
    {
        maxHealth=(SceneManager.GetActiveScene().buildIndex+1)*10;
        health=maxHealth;
        Transform pos=GetComponent<Transform>();
      x=pos.position.x-2.7f;
   y=pos.position.y-5;
   x1=pos.transform.position.x+1.8f;
   y1=pos.transform.position.y-4;
    }

    // Update is called once per frame
   protected override void Update(){
    if(death==0){
   base.Update();
        Transform dray=transform.Find("/Dray");
        if(dray.position.x<DungeonCreator.Boss2x*16 || dray.position.x>DungeonCreator.Boss2x*16+15 || dray.position.y<DungeonCreator.Boss2y*11 || dray.position.y>DungeonCreator.Boss2y*11+10 ){
        anim.CrossFade("KingGreenSlime_idle",0);    
        bossinforcreated=0;
    if(o1!=null && o2!=null){
        Destroy(o1);
        Destroy(o2);
    }
        }
else{
     if(bossinforcreated==0){
        CreateInforBoss();
      }
      o1.GetComponent<BossHealthBar>().health=(int)health;
       if(Time.time>=timeNextDecision){
        DeciceDirection();
       }
       if(counter<6){
anim.CrossFade("KingGreenSlime_attack",0);

float angle=Mathf.PI * degree / 180;
Transform pos=GetComponent<Transform>();

degree+=Random.Range(-180,180);
if(pos.position.y+Mathf.Sin(angle)<DungeonCreator.Boss2y*11+10 && pos.position.y+Mathf.Sin(angle)>DungeonCreator.Boss2y*11 && pos.position.x+Mathf.Cos(angle)<DungeonCreator.Boss2x*16+15 && pos.position.x+Mathf.Cos(angle)>DungeonCreator.Boss2x*16 )
       transform.position=new Vector3(pos.position.x+Mathf.Cos(angle),pos.position.y+Mathf.Sin(angle),0);}

else{
if(facing==0){
    anim.CrossFade("KingGreenSlime_move_0",0);
}
else{
     anim.CrossFade("KingGreenSlime_move_1",0);
}
    rigid.velocity=directions[facing]*speed;
}}
    }

    void DeciceDirection(){
         facing=Random.Range(0,4);
         counter=Random.Range(0,10);
    timeNextDecision=Time.time+Random.Range(timeThinkMin,timeThinkMax);
    }}
      void OnTriggerEnter(Collider collid){
        if(invincible) return ;
        DamageEffect def=collid.gameObject.GetComponent<DamageEffect>();
        if(def==null)return ;
        health-=def.damage;
        if(health<=0) Die();

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
       anim.CrossFade("KingGreenSlime_death",0);
        Destroy(o1);
        Destroy(o2);
        Destroy(gameObject,2.1f);
         int percentage=Random.Range(1,100);
        if(percentage>=23 && percentage<33){
            GameObject chest=Instantiate(Chest3);
            chest.transform.position=new Vector3(x+2.7f,y+5);
        }
        if(percentage>=33 && percentage<63){
            GameObject chest=Instantiate(Chest2);
            chest.transform.position=new Vector3(x+2.7f,y+5);
        }
        if(percentage<23 && percentage>=63){
            GameObject chest=Instantiate(Chest1);
            chest.transform.position=new Vector3(x+2.7f,y+5);
        }}

}

