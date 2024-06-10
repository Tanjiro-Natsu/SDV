using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FloatingSkul :MonoBehaviour,IFacingMover
{
    

 [Header("Set in Inspector:FloatingSkull")]
 public int speed=2;
    public float timeThinkMin=1f;
    public float timeThinkMax=2f;
    public GameObject bar;
    public GameObject name;
    public GameObject chestlvl1;
    public GameObject chestlvl2;
    public GameObject chestlvl3;
[Header("Set Dynamically")]

public int facing=0;
public int health;
public int maxHealth;
    public float timeNextDecision=0;
    private GameObject red;
    private GameObject orange;
    private GameObject green;
    private GameObject purple;
    public  int choice;
    public int hp;
    private static float x;
    
private static float y;
private static float x1;
private static float y1;
private InRoom inRm;

private GameObject o1;
private GameObject o2;
private Rigidbody rigid;
private int bossinforcreated=0;
public bool active=false;
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
       GameObject.Find("BossName(Clone)/Name").GetComponent<Text>().text="FloatingSkull";  
       bossinforcreated=1;
}

new void Awake(){
     maxHealth=(SceneManager.GetActiveScene().buildIndex+1)*10;
        health=maxHealth;
     rigid=GetComponent<Rigidbody>();
        red=GameObject.Find("/FloatingSkul/redSkul");
        orange=GameObject.Find("/FloatingSkul/orangeSkul");
        green=GameObject.Find("/FloatingSkul/greenSkul");
        purple=GameObject.Find("/FloatingSkul/violetSkul");
        inRm=GetComponent<InRoom>();
}
   new void Start()
    {
       
        Transform positionStart=GetComponent<Transform>();
      x=positionStart.position.x-2.7f;
   y=positionStart.position.y-5;
   x1=positionStart.transform.position.x+1.8f;
   y1=positionStart.transform.position.y-4;
    }

    // Update is called once per frame
    void Update()
    {
      
     
         Transform dray=transform.Find("/Dray");
          
         if(dray.position.x>DungeonCreator.Boss1x*16 && dray.position.y>DungeonCreator.Boss1y*11 && dray.position.y<DungeonCreator.Boss1y*11+10 && dray.position.x<DungeonCreator.Boss1x*16+15 && SceneManager.GetActiveScene().buildIndex>0)
    {
         if(bossinforcreated==0){
        CreateInforBoss();
      }
       o1.GetComponent<BossHealthBar>().health=health;
       active=true;
    }
    else{
    bossinforcreated=0;
    active=false;
    if(o1!=null && o2!=null){
        Destroy(o1);
        Destroy(o2);
    }}

    }
     void OnTriggerEnter(Collider collid){
        DamageEffect def=collid.gameObject.GetComponent<DamageEffect>();
        if(def==null)return ;
        health-=def.damage;
 
    if(health<=0) {
        
            Destroy(o1);
        Destroy(o2);
        Destroy(gameObject);}}
}
