using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SatanFlame :Enemy
{

    private float degree;
    private int  counter;
    private int death=0;
   
[Header("Set in Inspector:SatanFlame")]
   
    public GameObject bar;
    public GameObject name;
    public GameObject Chest1;
    public GameObject Chest2;
    public GameObject Chest3;

    [Header("Set Dynamically:SatanFlame")]
    private GameObject o1;
private GameObject o2;
private int bossinforcreated=0;
    private static float x;
private static float y;
private static float x1;
private static float y1;
int phase=0;

protected override void Awake(){
    base.Awake();
    anim=GetComponent<Animator>();
}

void CreateInforBoss(){
  o1=Instantiate<GameObject>(bar);
        o1.transform.position=new Vector3(x,y,-10);
         o2=Instantiate<GameObject>(name);
        o2.transform.position=new Vector3(x1,y1,0);
        Transform trans=o2.GetComponent<Transform>().Find("/Name");
       GameObject.Find("BossName(Clone)/Name").GetComponent<Text>().text="SatanFlame";  
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
    if(health<=maxHealth/4 && phase==2){
Destroy(transform.GetChild(1).gameObject);
phase=3;
    }
    if(health<=(maxHealth/4)*2 && phase==1){
        Destroy(transform.GetChild(2).gameObject);
        phase=2;
    }
    if(health<=(maxHealth/4)*3 && phase==0){
        Destroy(transform.GetChild(3).gameObject);
        phase=1;
    }
   
    if(death==0){
   base.Update();
        Transform dray=transform.Find("/Dray");
        if(dray.position.x<DungeonCreator.Boss3x*16 || dray.position.x>DungeonCreator.Boss3x*16+15 || dray.position.y<DungeonCreator.Boss3y*11 || dray.position.y>DungeonCreator.Boss3y*11+10 ){ 
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
      
 }
    }

}
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
        Destroy(o1);
        Destroy(o2);
        Destroy(gameObject,1);
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

