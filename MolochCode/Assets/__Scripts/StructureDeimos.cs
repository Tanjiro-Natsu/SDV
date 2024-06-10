using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StructureDeimos : MonoBehaviour
{
    protected static Vector3[] directions=new Vector3[]{
        Vector3.right,Vector3.up,Vector3.left,Vector3.down
    };
    [Header("Set in Inspector:StructureDeimos")]
    public float maxHealth;
    public GameObject item1;
    public GameObject Sound;
 
    

   
    public float invincibleDuration=0.5f;


    [Header("Set Dynamically")]
    public float health;
    public bool invincible=false;
    public bool knockback=false;

    
    protected Rigidbody rigid;
    protected SpriteRenderer sRend;

protected float invincibleDone=0;
    protected virtual void Awake(){
        health=maxHealth;
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
        GameObject go;
        GameObject go1;
        GameObject go2;
        GameObject go3;
        GameObject go4;
        GameObject go5;
        Destroy(Instantiate(Sound),1);
                 go=Instantiate<GameObject>(item1);
                 go1=Instantiate<GameObject>(item1);
                 go2=Instantiate<GameObject>(item1);
                 go3=Instantiate<GameObject>(item1);
                 go4=Instantiate<GameObject>(item1);
                 go5=Instantiate<GameObject>(item1);
                 Vector3 pos=transform.position;
                 Vector3 pos1=transform.position;
                 Vector3 pos2=transform.position;
                 Vector3 pos3=transform.position;
                 pos.x+=1;
                 pos1.x-=1;
                 pos2.y+=1;
                 pos3.y-=1;
                 go1.transform.position=pos;
                 go2.transform.position=pos1;
                 go3.transform.position=pos2;
                 go4.transform.position=pos3;
            go.transform.position=transform.position;
            
      GameObject Deimos=GameObject.Find("Deimos(Clone)");
      Deimos.GetComponent<Deimos>().health-=24;
       
        Destroy(gameObject);
         }

    
}
