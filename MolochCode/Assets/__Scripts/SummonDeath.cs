using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SummonDeath : Enemy,IFacingMover
{
    [Header("Set in Inspector:SummonDeath")]
    public int speed=2;
    public float timeThinkMin=1f;
    public float timeThinkMax=4f;

    [Header("Set Dynamically:SummonDeath")]
    public int facing=0;
    public float timeNextDecision=0;
    private InRoom inRm;
private Animator anim;
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
        maxHealth=1;
        health=maxHealth;
        
    }

    // Update is called once per frame
   new  void Update()
    {
        if(invincible && Time.time>invincibleDone) invincible=false;
        sRend.color=invincible ? Color.red : Color.white;
        //anim.CrossFade("Summon_death_idle",0);
       if(Time.time>=timeNextDecision){
        DeciceDirection();
       }
       rigid.velocity=directions[facing]*speed;
    }

    void DeciceDirection(){
         facing=Random.Range(0,4);
    timeNextDecision=Time.time+Random.Range(timeThinkMin,timeThinkMax);
    }
     void OnTriggerEnter(Collider collid){
        if(invincible) return ;
        DamageEffect def=collid.gameObject.GetComponent<DamageEffect>();
        if(def==null)return ;
        health-=def.damage;
        if(health<=0) Die();
        invincible=true;
        invincibleDone=Time.time+invincibleDuration;
       
    }
     void Die(){
        anim.CrossFade("SummonDeath_death",0);
        Destroy(gameObject,0.7f);}
}
