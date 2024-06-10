using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RisedSkeletos : Enemy,IFacingMover
{
    [Header("Set in Inspector:RisedSkeletos")]
    public int speed=2;
    public float timeThinkMin=1f;
    public float timeThinkMax=4f;

    [Header("Set Dynamically:RisedSkeletos")]
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
        StartCoroutine(rise());
    }

    // Update is called once per frame
    override protected void Update()
    {
        base.Update();
        if(knockback) return ;
       if(Time.time>=timeNextDecision){
        DeciceDirection();
       }
       if(facing==2){
 anim.CrossFade("RisedSkeleton_move_0",0);
       }
       else{
 anim.CrossFade("RisedSkeleton_move_1",0);
       }
       rigid.velocity=directions[facing]*speed;
    }

    void DeciceDirection(){
         facing=Random.Range(0,4);
    timeNextDecision=Time.time+Random.Range(timeThinkMin,timeThinkMax);
    }
    IEnumerator rise(){
   anim.CrossFade("RisedSkeleton",0);
    yield return new WaitForSeconds(1.2f); 
   
}
}
