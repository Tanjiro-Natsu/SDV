using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    protected static Vector3[] directions=new Vector3[]{
        Vector3.right,Vector3.up,Vector3.left,Vector3.down
    };
    [Header("Set in Inspector:Enemy")]
    public float maxHealth;
    public GameObject item1;
    public GameObject item2;
    public GameObject Sound;
 
    

    public float knockbackSpeed=10;
    public float knockbackDuration =0.25f;
    public float invincibleDuration=0.5f;


    [Header("Set Dynamically")]
    public float health;
    public bool invincible=false;
    public bool knockback=false;

    protected Animator anim;
    protected Rigidbody rigid;
    protected SpriteRenderer sRend;

protected float invincibleDone=0;
protected float knockbackDone=0;
protected Vector3 knockbackVel;
    protected virtual void Awake(){
        health=maxHealth;
        anim=GetComponent<Animator>();
        rigid=GetComponent<Rigidbody>();
        sRend=GetComponent<SpriteRenderer>();
        }// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if(invincible && Time.time>invincibleDone) invincible=false;
        sRend.color=invincible ? Color.red : Color.white;
        if(knockback){
            rigid.velocity=knockbackVel;
            if(Time.time<knockbackDone) return ;
        }
        anim.speed=1;
        knockback=false;
        
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
        GameObject go;
        Destroy(Instantiate(Sound),1);
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
