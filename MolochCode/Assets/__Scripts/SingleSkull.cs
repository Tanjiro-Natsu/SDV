using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SingleSkull : Enemy,IFacingMover
{ public int speed=2;

[Header("Set in Inspector:SingleSkull")]
public GameObject Red;
public GameObject Blue;
public GameObject Purple;
public GameObject Green;

    [Header("Set Dynamically:SingleSkull")]
  public int facing=0;
    public float timeNextDecision=0;
    private InRoom inRm;
    public float hitDuration=1f;
    private float hitDone=0;
    public bool hit=false;
  
    private GameObject go;
   private int degree=0;
   public int frame;
   private GameObject go1;

Animator anim;

private Transform positionStart;
new  void Awake(){
    sRend=GetComponent<SpriteRenderer>();
    inRm=GetComponent<InRoom>();
    anim=GetComponent<Animator>();
         maxHealth=((SceneManager.GetActiveScene().buildIndex+1)*10)/4;
         health=maxHealth;
          
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


    void Start()
    {
       
         go=GameObject.Find("/FloatingSkull");
         
         
switch(gameObject.name){
    case "orangeSkul" :
degree=90;
    break;
    case "redSkul":
degree=270;
    break;
    case "greenSkul":
degree=180;
    break;
    case "violetSkul":
degree=0;
    break;

}
    }

    // Update is called once per frame
    void Update()
    {
        
         if(invincible && Time.time>invincibleDone) invincible=false;
        sRend.color=invincible ? Color.red : Color.white;
      
switch(gameObject.name){
    case "orangeSkul" :
    anim.CrossFade("orangeSkul",0);
    break;
    case "redSkul":
anim.CrossFade("redSkull",0);
    break;
    case "greenSkul":
anim.CrossFade("greenSkull",0);
    break;
    case "violetSkul":
anim.CrossFade("purpleSkull",0);
    break;

}
        
            Transform pos=transform.parent.transform; 
             float angle=Mathf.PI * degree / 180;
             Vector3 equa=transform.position;
 transform.position=new Vector3(pos.position.x+Mathf.Cos(angle)*1.7f,pos.position.y+Mathf.Sin(angle)*1.7f,0);
 degree+=1;
if(transform.parent.gameObject.active){
if(frame==0){
    if(Random.Range(0,2)==1){
        GameObject dray=GameObject.Find("/Dray");
        Vector3 r=dray.transform.position;
switch(gameObject.name){
    case "orangeSkul" :

if(r.x>DungeonCreator.Boss1x*16 && r.x<DungeonCreator.Boss1x*16+15 && r.y>DungeonCreator.Boss1y*11 && r.y<DungeonCreator.Boss1y*11+10){
go1=Instantiate(Blue);
}
    break;
    case "redSkul":
if(r.x>DungeonCreator.Boss1x*16 && r.x<DungeonCreator.Boss1x*16+15 && r.y>DungeonCreator.Boss1y*11 && r.y<DungeonCreator.Boss1y*11+10){
go1=Instantiate(Red);
}
    break;
    case "greenSkul":
if(r.x>DungeonCreator.Boss1x*16 && r.x<DungeonCreator.Boss1x*16+15 && r.y>DungeonCreator.Boss1y*11 && r.y<DungeonCreator.Boss1y*11+10){
go1=Instantiate(Green);
}
    break;
    case "violetSkul":
if(r.x>DungeonCreator.Boss1x*16 && r.x<DungeonCreator.Boss1x*16+15 && r.y>DungeonCreator.Boss1y*11 && r.y<DungeonCreator.Boss1y*11+10){
go1=Instantiate(Purple);
}
    break;

}
if(r.x>DungeonCreator.Boss1x*16 && r.x<DungeonCreator.Boss1x*16+15 && r.y>DungeonCreator.Boss1y*11 && r.y<DungeonCreator.Boss1y*11+10){
go1.transform.position=transform.position;
}

}
 }
 frame++;
 if(frame==30 && go1!=null){
    Destroy(go1);
    frame=0;
 }
 if(go1==null){
    frame=0;
 }

        
    }}

      void OnTriggerEnter(Collider collid){
         if(invincible) return ;
          DamageEffect def=collid.gameObject.GetComponent<DamageEffect>();
        if(def==null)return ;
        invincible=true;
        invincibleDone=Time.time+invincibleDuration;}
}
