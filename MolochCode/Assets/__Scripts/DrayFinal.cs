using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class DrayFinal : MonoBehaviour,IFacingMover
{
    public enum EMode{idle,move,attack,transition,knockback};
    [Header("Set in Inspector")]

     public int maxHealth=10;
    public float knockbackSpeed=10;
    public float knockbackDuration=0.25f;
    public float invincibleDuration=0.5f;
    public float speed=5;
    public float attackDuration=0.25f;
    public float attackDelay=0.5f;
    public float transitionDelay=0.5f;
    public GameObject fireball;
    public GameObject fireball1; 
    public GameObject capsule;
   
    [Header("Set Dynamically")]
    public int facing =1;
    public bool invincible=false;
    public EMode mode=EMode.idle;
    public  int NightBorne=0;
    public int numKeys=0;
    [SerializeField]
    private int _health;
    private float knockbackDone=0;
    private float invincibleDone=0;
    private  Vector3 knockbackVel;
    private SpriteRenderer sRend;
    public int DragonKnight=0;
    public int dragontransformation=0;
    private GameObject Hit;
    private GameObject beinghit;
    private GameObject ChestOpen;
    private GameObject HealEffect;
    private GameObject pickitem;
    public int NightBornepowerYeld=0;
    private int framehp=0;
   
    public int health{
        get{
return _health;
        }
        set{
            _health=value;

        }

    }
    private float timeAtkDone=0;
    private float timeAtkNext=0;
    private float transitionDone=0;
    private Vector2 transitionPos;
    public int dirHeld=-1;
    private Rigidbody rigid;
    private Vector3[] directions=new Vector3[]{Vector3.right,Vector3.up,Vector3.left,Vector3.down};
    private KeyCode[] keys=new KeyCode[]{KeyCode.D,KeyCode.W,KeyCode.A,KeyCode.S};
private Animator anim;
private InRoomDrayFinal  inRm;
private GameObject transition;
private Text text;
private string Scene;
static public int stanzattuale=1;
private int  fireballdelay=0;
private int delay=0;
public float hitDuration=1f;
    private float hitDone=0;
    public bool hit=false;
    public GameObject OptionMenu;
    private GameObject Sword;
    public  int dmgsdray;
    private CapsuleCollider CapsCollider;

public int keyCount{
    get{
        return numKeys;
    }
    set{
        numKeys=value;
    }
}
    void Awake(){
        //transition=GameObject.Find("/Transition");
        //text=transform.Find("/Transition/LevelTitle").GetComponent<Text>();
        transition=GameObject.Find("/Transition");
        text=transform.Find("/Transition/LevelTitle").GetComponent<Text>();
        sRend=GetComponent<SpriteRenderer>();
        rigid=GetComponent<Rigidbody>();
        anim=GetComponent<Animator>();
        inRm=GetComponent<InRoomDrayFinal>();
        CapsCollider=GetComponent<CapsuleCollider>();
        CapsCollider.enabled=false;
        health=maxHealth;
        Hit=transform.Find("/hit ").gameObject;
        beinghit=transform.Find("/BeingHit").gameObject;
        Hit.SetActive(false);
         beinghit.SetActive(false);
        HealEffect=transform.Find("/HealEffect ").gameObject;
        HealEffect.SetActive(false);
        pickitem=transform.Find("/PickItem").gameObject;
        pickitem.SetActive(false);
        OptionMenu=GameObject.Find("/OptionsMenu");
        OptionMenu.SetActive(false);
        
       
    }
     public int GetFacing(){
            return facing;
        }
        public bool moving {
            get{
                return (mode==EMode.move);
            }
        }
        public float GetSpeed(){
            return speed;
        }
        public float gridMult{
            get{return inRm.gridMult;}

        }
        public Vector2 roomPos{
            get{
                return inRm.roomPos;
            }
            set{
                inRm.roomPos=value;
            }
        }
        public Vector2 roomNum{
            get{
                return inRm.roomNum;
            }
            set{
                inRm.roomNum=value;
            }
        }
        public Vector2 GetRoomPosOnGrid(float mult=-1){
            return inRm.GetRoomPosOnGrid(mult);
        }

        void Start(){
   Scene currentScene = SceneManager.GetActiveScene ();
		Scene = currentScene.name;
        text.text=currentScene.name.ToString();
       StartCoroutine(load());
       if (mainManager.Instance != null && Scene!="Gaol 1"){
        Sword=GameObject.Find("/Dray/SwordController/Sword");
 Sword.GetComponent<DamageEffect>().damage=mainManager.damage;
Sword.GetComponent<SpriteRenderer>().sprite=mainManager.weapon;
GameObject.Find("/Dray").GetComponent<DrayFinal>().health=mainManager.health;
GameObject.Find("/Dray").GetComponent<DrayFinal>().numKeys=mainManager.keys;
NightBornepowerYeld=mainManager.NightBorne;
DragonKnight=mainManager.DragonBorne;


      }
       
       
      
        }
    void Update()
    {
        
     if(NightBorne==1){
            framehp++;
            if(framehp==60){
                health-=1;
                if(health<=0){
                   SceneManager.LoadScene("GameOver"); 
                }
                framehp=0;
            }
        }

        if(dragontransformation==0 && DragonKnight==1){

              dragontransformation=1;
              return ;
         
        }
        
        if(Input.GetKeyDown(KeyCode.X) && NightBorne==0){
            if(NightBornepowerYeld==1){
                CapsCollider.enabled=true;
           StartCoroutine(creation());
            NightBorne=1;}
            return;
            
        }
         if(Input.GetKeyDown(KeyCode.O) ){
         OptionMenu.SetActive(true);
            return;
            
        }
        if(Input.GetKeyDown(KeyCode.X) && NightBorne==1){
              if(NightBornepowerYeld==1){
                CapsCollider.enabled=false;
           StartCoroutine(destruction());
           NightBorne=0;}
          
    return;
            
        }
        if(DragonKnight==1 && dragontransformation==1){
             if(hit && Time.time>hitDone) {hit=false;beinghit.SetActive(false);}
        if(hit){
            if(facing==2){
 anim.CrossFade("DragonKnight_hit_0",0);
        }
        else{
 anim.CrossFade("DragonKnight_hit_1",0);
        }
        return ;
        }
        }
        if(DragonKnight==0){if(NightBorne==1){
        if(hit && Time.time>hitDone) {hit=false;beinghit.SetActive(false);}
        if(hit){
            if(facing==2){
 anim.CrossFade("NightBringer_hit_0",0);
        }
        else{
 anim.CrossFade("NightBringer_hit_1",0);
        }
         
        return ;
        }}
        else{
        if(invincible && Time.time >invincibleDone) {invincible=false;beinghit.SetActive(false);}
        sRend.color=invincible? Color.red : Color.white;
        if(mode==EMode.knockback){
            rigid.velocity=knockbackVel;
            if(Time.time<knockbackDone) return ;
        }
         
        }
    }
        if(mode==EMode.transition){
            rigid.velocity=Vector3.zero;
            anim.speed=0;
            //roomPos=transitionPos;
            if(Time.time<transitionDone)return;
            mode=EMode.idle;
        }
       
    dirHeld=-1;
       
    for(int i=0;i<4;i++){
    if(Input.GetKey(keys[i])) dirHeld=i;
}

if(Input.GetKeyDown(KeyCode.Space) && Time.time>=timeAtkNext){
    mode=EMode.attack;
    timeAtkDone=Time.time+attackDuration;
    timeAtkNext=Time.time+attackDelay;
}
if(Time.time>=timeAtkDone){
    mode=EMode.idle;
}
if(mode!=EMode.attack){
    if(dirHeld==-1){
        mode=EMode.idle;
    }else {
        facing=dirHeld;
        mode=EMode.move;
    }

}
    Vector3 vel =Vector3.zero;
GameObject t=transform.Find("SwordController/Sword").gameObject;
if(dragontransformation==1 && DragonKnight==1){
 switch(mode){
        case EMode.attack:
        if(facing==2){
            if(fireballdelay==0){
anim.CrossFade("DragonKnight_attack_0",0);
GameObject attack=Instantiate(fireball);
Vector3 sop=transform.position;
sop.x-=1;
attack.transform.position=sop;
delay=1;}
        }
        else{
            if(fireballdelay==0){
anim.CrossFade("DragonKnight_attack_1",0);
GameObject attack=Instantiate(fireball1);
Vector3 sop=transform.position;
sop.x+=1;
attack.transform.position=sop;
delay=1;}
        }
        speed=0;
            break;
        case EMode.idle:
        if(facing==2){
anim.CrossFade("DragonKnight_idle_1",0);
        }
        else{
anim.CrossFade("DragonKnight_idle",0);
        }

            break;
        case EMode.move:
         vel=directions[dirHeld];
       if(facing==2){
anim.CrossFade("DragonKnight_move_0",0);
anim.speed=1;
        }
        else{
anim.CrossFade("DragonKnight_move_1",0);
anim.speed=1;
        }
        speed=5;
            break;
       case EMode.transition:
            break;
       
    }
    rigid.velocity=vel*speed;
}


    if(DragonKnight==0){if(NightBorne==1){
        
 switch(mode){
        case EMode.attack:
         GameObject capsula=Instantiate(capsule);
     StartCoroutine(NightBorneattack(capsula));
        t.SetActive(false);
            break;
        case EMode.idle:
       if(facing==2){
anim.CrossFade("NightBringer_move_0",0);
        }
        else{
anim.CrossFade("NightBringer_move_1",0);
        }
            break;
        case EMode.move:
        anim.speed=1;
         vel=directions[dirHeld];
       if(facing==2){
       
anim.CrossFade("NightBringer_move_0",0);
        }
        else{
            
anim.CrossFade("NightBringer_move_1",0);
        }
            break;
       case EMode.transition:
            break;
       
    }
 rigid.velocity=vel*speed;
        return ; 
    }
    else{
    switch(mode){
        case EMode.attack:
        anim.CrossFade("Dray_attack_"+facing,0);
        Vector3 positionofhit=transform.position;
        switch(facing){
case 0:
positionofhit.x+=1.5f;
break;
case 1:
positionofhit.y+=1.5f;
break;
case 2:
positionofhit.x-=1.5f;
break;
case 3:
positionofhit.y-=1.5f;
break;
        }
        Hit.transform.position=positionofhit;
       StartCoroutine(hitEffect());
        anim.speed=0;
            break;
        case EMode.idle:
        anim.CrossFade("Dray_walk_"+facing,0);
        anim.speed=0;
            break;
        case EMode.move:
        vel=directions[dirHeld];
        
        anim.CrossFade("Dray_walk_"+dirHeld,0);
     anim.speed=1;
            break;
       case EMode.transition:
            break;
        
    }
     rigid.velocity=vel*speed;
    
    }
    }
    if(fireballdelay==20){
        fireballdelay=0;
        delay=0;
        return;
    }
    if(delay==1){
    fireballdelay++;}
    }
    
        //if(rm.x>=0 && rm.x<=InRoom.MAX_RM_X){
         //   if(rm.y>=0 && rm.y<=InRoom.MAX_RM_Y){
         //   InRoom.stanzattuale+=1;
         //   roomNum=rm;
            //roomPos=transitionPos;
          //  mode=EMode.transition;
          //  transitionDone=Time.time+transitionDelay;
        //}}
 
    

    void transito(){
            //roomNum=rm;
            //roomPos=transitionPos;
            mode=EMode.transition;
            transitionDone=Time.time+transitionDelay;
    }


    void OnCollisionEnter(Collision coll){
         if(NightBorne==1 || DragonKnight==1){
            if(hit) return ;
        }
        else{
if(invincible) return ;
        }
        
        DamageEffect def=coll.gameObject.GetComponent<DamageEffect>();
        if(def==null) return ;
        if(GameObject.Find("Main Camera").GetComponent<EffectSoundStart>().Effect==1){
         beinghit.SetActive(true);}
        health-=def.damage;
        if(health<=0){
            SceneManager.LoadScene("GameOver");
        }
        if(NightBorne==1 || DragonKnight==1){
           hit=true;
         hitDone=Time.time+hitDuration;
        }
         else{
              invincible=true;
        invincibleDone=Time.time+invincibleDuration;  
        if(def.knockback){
            Vector3 delta =transform.position-coll.transform.position;
            if(Mathf.Abs(delta.x)>=Mathf.Abs(delta.y)){
                delta.x=(delta.x>0) ? 1: -1;
                delta.y=0;
            }
            else {
                delta.x=0;
                delta.y=(delta.y>0) ? 1 : -1;

            }

            knockbackVel=delta*knockbackSpeed;
            rigid.velocity=knockbackVel;
            mode =EMode.knockback;
            knockbackDone=Time.time+knockbackDuration;
            

        } 
            }
       
    }

    void OnTriggerEnter(Collider coll){
        PickUp pup=coll.GetComponent<PickUp>();
   if(pup!=null){
  switch(pup.itemType){
            case PickUp.eType.health:
            if(health==maxHealth){
                break;
            }
            health=Mathf.Min(health+=1,maxHealth);
            StartCoroutine(healEffect());
             Destroy(coll.gameObject);
            break;
            case PickUp.eType.key:
            numKeys++;
             Destroy(coll.gameObject);
            break;
            case PickUp.eType.weapon:
            Sprite a=GameObject.Find("/Dray/SwordController/Sword").GetComponent<SpriteRenderer>().sprite;
            GameObject.Find("/Dray/SwordController/Sword").GetComponent<SpriteRenderer>().sprite=coll.GetComponent<SpriteRenderer>().sprite;
            coll.GetComponent<SpriteRenderer>().sprite=a;
            int b=GameObject.Find("/Dray/SwordController/Sword").GetComponent<DamageEffect>().damage;
            GameObject.Find("/Dray/SwordController/Sword").GetComponent<DamageEffect>().damage=coll.GetComponent<DamageEffect>().damage;
            coll.GetComponent<DamageEffect>().damage=b;

            break;
            
        }
   }
        RetroChest retro=coll.GetComponent<RetroChest>();
        if(retro!=null){
            retro.activate=true;
        }
        MetalChest metal=coll.GetComponent<MetalChest>();
        if(metal!=null){
            metal.activate=true;
        }
         GoldenChest gold=coll.GetComponent<GoldenChest>();
        if(gold!=null){
            gold.activate=true;
        }
        if(retro==null && pup==null && metal==null && gold==null) return;

      
       
    }
IEnumerator load(){
     Animator a=transition.GetComponent<Animator>();
    a.CrossFade("Transition_1",10000);
    yield return new WaitForSeconds(3); 
   
     transition.SetActive(false);
}
IEnumerator creation(){
    if(facing==2){
 anim.CrossFade("NightBringer_creation_0",0);
 anim.speed=1;
    }
    else{
 anim.CrossFade("NightBringer_creation_1",0);
 anim.speed=1;
    }
    yield return new WaitForSeconds(2.2f); 
   
}
IEnumerator destruction(){
    if(facing==2){
 anim.CrossFade("NightBringer_destruction_0",0);
 anim.speed=1;
    }
    else{
 anim.CrossFade("NightBringer_destruction_1",0);
 anim.speed=1;
    }
    yield return new WaitForSeconds(1.8f); 
   
}
IEnumerator dragoncreation(){
   if(facing==2){
anim.CrossFade("DragonKnight_creation_0",0);
            }
            else{
anim.CrossFade("DragonKnight_creation_1",0);
            }

  yield return new WaitForSeconds(0.9f); 
   
}

IEnumerator NightBorneattack(GameObject capsula){
    if(facing==2){
       Vector3 poscaspula=transform.position;
       poscaspula.x-=1;
       capsula.GetComponent<DamageEffect>().damage=dmgsdray*2;
       capsula.transform.position=poscaspula;
       
anim.CrossFade("NightBringer_attack_0",0);
        }
          else{    
       Vector3 poscaspula=transform.position;
       poscaspula.x+=1;
       capsula.GetComponent<DamageEffect>().damage=dmgsdray*2;
       capsula.transform.position=poscaspula; 
anim.CrossFade("NightBringer_attack_1",0);
        }
    
 yield return new WaitForSeconds(0.4f); 

   Destroy(capsula);
}

IEnumerator healEffect(){
     if(GameObject.Find("Main Camera").GetComponent<EffectSoundStart>().Effect==1){
    HealEffect.transform.position=transform.position; 
     HealEffect.SetActive(true);}
    yield return new WaitForSeconds(1); 
     HealEffect.SetActive(false);
}
IEnumerator hitEffect(){
     if(GameObject.Find("Main Camera").GetComponent<EffectSoundStart>().Effect==1){
     Hit.SetActive(true);}
    yield return new WaitForSeconds(0.5f); 
     Hit.SetActive(false);
}
IEnumerator pickITEM(){
    if(GameObject.Find("Main Camera").GetComponent<EffectSoundStart>().Effect==1){
     pickitem.SetActive(true);}
    yield return new WaitForSeconds(0.5f); 
     pickitem.SetActive(false);
}

}
