using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CamFollowDrayFinal : MonoBehaviour
{
    
   void Update(){
    GameObject dray=GameObject.Find("/Dray");
    Vector3 pos=dray.transform.position;
    transform.position=new Vector3(pos.x,pos.y,-10);
   }

}