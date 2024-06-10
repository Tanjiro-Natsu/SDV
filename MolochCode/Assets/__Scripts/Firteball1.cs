using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fireball1 : MonoBehaviour
{
    int k=0;
     void Update(){
            Vector3 pos=transform.position;
            k++;
            pos.x+=1;
            transform.position=pos;
if(SceneManager.GetActiveScene().buildIndex!=9){
if(DungeonCreator.dungeon[(int)Mathf.Round(pos.x),(int)Mathf.Round(pos.y)]!=1 || k==5) Destroy(gameObject);}
else{
     if(k>6){
         Destroy(gameObject);
     }
}
          }
}