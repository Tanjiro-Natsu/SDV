using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SingleSkullAttack : MonoBehaviour
{ 

void Update(){
    Vector3 pos=transform.position;
    if(transform.position.x>=DungeonCreator.Boss1x*16+7){
      pos.x+=0.3f;
    }
    else{
        pos.x-=0.3f;
    }
    transform.position=pos;
}



}
