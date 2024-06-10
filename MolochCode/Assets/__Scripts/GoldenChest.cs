using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenChest : MonoBehaviour
{

    [Header("Set in Inspector:MetalChest")]
    public GameObject item1;
    public GameObject item2;
    public GameObject item3;
    public GameObject item4;
    public GameObject item5;
    public GameObject weapon6;
    public GameObject weapon7;
    public GameObject weapon8;
    public GameObject weapon9;
    public GameObject weapon10;
     public GameObject NightPowerUp;
    public GameObject DragonPowerUp;

   
    [Header("Set Dinamically")]
    public bool activate=false;
     private int frame;
    public static float COLLIDER_DELAY=0.5f;
    private bool ok=false;
    Animator anim;
      void Awake(){
       
        anim=GetComponent<Animator>();
    }

    void Activate(){
        GetComponent<Collider>().enabled=true;
    }

    void Update(){
        
        if(activate==true){
if(frame==0){
anim.CrossFade("Chest3_open",0);



}
else if(frame==20){
    int percentage=Random.Range(1,100);
    Vector3 trans=GetComponent<Transform>().position;

    GameObject go =go=Instantiate<GameObject>(item1);
    trans.x+=1;
            go.transform.position=trans;
          



    GameObject go1=Instantiate<GameObject>(item2);
    trans.x-=2;
            go1.transform.position=trans;


    GameObject go2=Instantiate<GameObject>(item3);
    trans.x+=1;
    trans.y+=1;
go2.transform.position=trans;
    GameObject go4=Instantiate<GameObject>(item4);
    trans.x+=1;
    go4.transform.position=trans;
    GameObject go5=Instantiate<GameObject>(item5);
    trans.y-=2;
    go5.transform.position=trans;
    trans.x-=1;
    trans.y+=1;
           
    if(percentage<=80){
        int o=0;
        while(o==0){
        int choice=Random.Range(1,5);
        int weaponpercentage=Random.Range(1,100);
    if(weaponpercentage==23 ){
            GameObject go3;
            if(Random.Range(1,10)<5){
            go3=Instantiate<GameObject>(NightPowerUp);}
            else{
                go3=Instantiate<GameObject>(DragonPowerUp);
            }
    
    go3.transform.position=trans;
    o=1;
    break;
        } 
        if(weaponpercentage>=23 && weaponpercentage<43 && choice==1){
            GameObject go3=Instantiate<GameObject>(weapon10);
    
    go3.transform.position=trans;
    o=1;
    break;
        }
         if(weaponpercentage>=0 && weaponpercentage<40 && choice==2){
            GameObject go3=Instantiate<GameObject>(weapon9);
    
    go3.transform.position=trans;
    o=1;
        }
         if(weaponpercentage>=0 && weaponpercentage<50 && choice==3){
            GameObject go3=Instantiate<GameObject>(weapon8);
   
    go3.transform.position=trans;
    o=1;
        }
         if(weaponpercentage>=0 && weaponpercentage<70 && choice==4){
            GameObject go3=Instantiate<GameObject>(weapon7);
   
    go3.transform.position=trans;
    o=1;
        }
          if(weaponpercentage>=0 && weaponpercentage<90 && choice==5){
            GameObject go3=Instantiate<GameObject>(weapon6);
    
    go3.transform.position=trans;
    o=1;
        }
     
    }
        }
 Destroy(gameObject,0);
}
frame++;}
else{
    anim.CrossFade("Chest3_idle",0);
}

        
    }
}




