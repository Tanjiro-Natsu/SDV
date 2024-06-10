using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class AbyssalGolem :Enemy,IFacingMover
{

    private float degree;
    private int  counter;
    private int death=0;
   
[Header("Set in Inspector:AbyssalGolem")]
    public int speed=2;
    public float timeThinkMin=1f;
    public float timeThinkMax=2f;

    [Header("Set Dynamically:AbyssalGolem")]
    public int facing=0;
    public float timeNextDecision=0;
    private InRoom inRm;
    public float hitDuration=1f;
    public bool hit=false;
    private SphereCollider sphere;
    public GameObject Sound;

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


    // Start is called before the first frame update
    void Start()
    {
        maxHealth=(SceneManager.GetActiveScene().buildIndex+1)*4;
        health=maxHealth;
        sphere=GetComponent<SphereCollider>();
        sphere.enabled=false;
     
    }

    // Update is called once per frame
   protected override void Update(){
    if(death==0){
   base.Update();
    sphere.enabled=false;
      
       if(Time.time>=timeNextDecision){
        DeciceDirection();
       }
       if(counter<2){
        if(facing==0){
anim.CrossFade("AbyssalGolem_attack_0",0);
sphere.center=new Vector3(0.34f,0,0);
 sphere.enabled=true;
        }
        else{
anim.CrossFade("AbyssalGolem_attack_1",0);
sphere.center=new Vector3(-0.34f,0,0);
 sphere.enabled=true;
        }

    }
    else{
if(facing==0){
    anim.CrossFade("AbyssalGolem_move_0",0);
}
else{
     anim.CrossFade("AbyssalGolem_move_1",0);
}
    rigid.velocity=directions[facing]*speed;
}}}

    void DeciceDirection(){
         facing=Random.Range(0,4);
         counter=Random.Range(0,4);
    timeNextDecision=Time.time+Random.Range(timeThinkMin,timeThinkMax);
    }
      void OnTriggerEnter(Collider collid){
        if(invincible) return ;
        DamageEffect def=collid.gameObject.GetComponent<DamageEffect>();
        if(def==null)return ;
        health-=def.damage;
        if(health<=0) {Die();}

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
        Destroy(Instantiate(Sound),1);
        Destroy(gameObject);
        GameObject go;
        int a=Random.Range(0,20);
        if(a<5){
                 go=Instantiate<GameObject>(item1);
            go.transform.position=transform.position;
        }
           else if(a>14){
            go=Instantiate<GameObject>(item2);
            go.transform.position=transform.position;}
        
        Destroy(gameObject);
        }

}

