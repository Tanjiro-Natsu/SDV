using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwordController : MonoBehaviour
{
     
    public  GameObject sword;
    private Dray dray;
    private DrayFinal dray1;

    // Start is called before the first frame update
    void Start()
    {
    if(SceneManager.GetActiveScene().buildIndex==9){
dray1=transform.parent.GetComponent<DrayFinal>();
    }
    else{
    dray=transform.parent.GetComponent<Dray>();}
    sword.SetActive(false);    
    }

    // Update is called once per frame
    void Update()
    {
sword=transform.Find("Sword").gameObject;
               
        
         if(SceneManager.GetActiveScene().buildIndex==9 && (dray1.DragonKnight==0 && dray1.NightBorne==0)) {
            if( dray1.mode==DrayFinal.EMode.attack){
                 dray1.dmgsdray=sword.GetComponent<DamageEffect>().damage;
 transform.rotation=Quaternion.Euler(0,0,90*dray1.facing);
 sword.SetActive(true);}
 else{
sword.SetActive(false);
 }
    }
    else if(SceneManager.GetActiveScene().buildIndex!=9 && (dray.DragonKnight==0 && dray.NightBorne==0)){
        if(dray.mode==Dray.EMode.attack){
             dray.dmgsdray=sword.GetComponent<DamageEffect>().damage;
    transform.rotation=Quaternion.Euler(0,0,90*dray.facing);
    sword.SetActive(true);
   }
    else if(SceneManager.GetActiveScene().buildIndex==9 && (dray1.DragonKnight==1 || dray1.NightBorne==1)){
       sword.SetActive(false); 
    }
    else{sword.SetActive(false);}}

   
    
}}
