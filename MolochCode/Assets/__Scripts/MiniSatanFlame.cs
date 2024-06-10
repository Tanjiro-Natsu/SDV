using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MiniSatanFlame :MonoBehaviour
{ public int speed=2;


 
  
    private GameObject go;
   private int degree=0;
   public int frame;
   private GameObject go1;

Animator anim;

private Transform positionStart;
    void Start()
    {
       
         go=GameObject.Find("/SatanFlame");
         
         
switch(gameObject.name){
    case "Blue1":
degree=180;
    break;
    case "Blue2":
degree=270;
    break;
    case "Blue3":
degree=0;
    break;
    case "Blue4":
degree=90;
    break;

}
    }

    // Update is called once per frame
    void Update()
    {   
            Transform pos=transform.parent.transform; 
             float angle=Mathf.PI * degree / 180;
             Vector3 equa=transform.position;
            
             switch(gameObject.name){
    case "Blue1":
transform.position=new Vector3(equa.x-Mathf.Cos(angle)*0.03f,equa.y+Mathf.Sin(angle)*0.03f,0);
    break;
    case "Blue2":
transform.position=new Vector3(equa.x-Mathf.Cos(angle)*0.03f,equa.y-Mathf.Sin(angle)*0.03f,0);
 
    break;
    case "Blue3":
transform.position=new Vector3(equa.x-Mathf.Cos(angle)*0.03f,equa.y+Mathf.Sin(angle)*0.03f,0);

    break;
    case "Blue4":
transform.position=new Vector3(equa.x+Mathf.Cos(angle)*0.03f,equa.y-Mathf.Sin(angle)*0.03f,0);
 
    break;

}

 degree+=1;
}

      void OnTriggerEnter(Collider collid){
         }
}
