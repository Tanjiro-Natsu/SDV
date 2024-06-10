using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetroChest : MonoBehaviour
{

    [Header("Set in Inspector")]
    public GameObject item1;
    public GameObject item2;
    public GameObject item3;
    public GameObject weapon1;
    public GameObject weapon2;
    public GameObject weapon3;
    public GameObject weapon4;
    public GameObject weapon5;
    public GameObject weapon6;
    public GameObject weapon7;
    public GameObject weapon8;
    public GameObject weapon9;
    public GameObject weapon10;

   
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
anim.CrossFade("Chest1_open",0);



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
    if(percentage<=60){
        int weaponpercentage=Random.Range(1,200);
        if(weaponpercentage==23){
            GameObject go3=Instantiate<GameObject>(weapon10);
    trans.y-=1; 
        }
         if(weaponpercentage==46 || weaponpercentage==11){
            GameObject go3=Instantiate<GameObject>(weapon9);
    trans.y-=1; 
        }
         if(weaponpercentage==49 || weaponpercentage==13 || weaponpercentage==15){
            GameObject go3=Instantiate<GameObject>(weapon8);
    trans.y-=1; 
        }
         if(weaponpercentage==48 || weaponpercentage==47 || weaponpercentage==45 || weaponpercentage==44){
            GameObject go3=Instantiate<GameObject>(weapon7);
    trans.y-=1; 
        }
          if(weaponpercentage==38 || weaponpercentage==37 || weaponpercentage==36 || weaponpercentage==35 || weaponpercentage==34){
            GameObject go3=Instantiate<GameObject>(weapon6);
    trans.y-=1; 
        }
        if(weaponpercentage>=100 && weaponpercentage<110){
            GameObject go3=Instantiate<GameObject>(weapon5);
    trans.y-=1; 
        }
         if(weaponpercentage>=120 && weaponpercentage<135){
            GameObject go3=Instantiate<GameObject>(weapon4);
    trans.y-=1; 
        }
         if(weaponpercentage>=135 && weaponpercentage<155){
            GameObject go3=Instantiate<GameObject>(weapon3);
    trans.y-=1; 
        }
         if(weaponpercentage>=160 && weaponpercentage<190){
            GameObject go3=Instantiate<GameObject>(weapon1);
    trans.y-=1; 
        }
         if(weaponpercentage>=135 && weaponpercentage<160){
            GameObject go3=Instantiate<GameObject>(weapon2);
    trans.y-=1; 
        }


        }
Destroy(gameObject,0);
}
frame++;}
else{
    anim.CrossFade("ChestIdle1",0);
}

        
    }
}




