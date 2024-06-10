using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameOver : MonoBehaviour

{
    private Animator anim;
    void Awake(){
        GameObject go=GameObject.Find("/GameOver");
        anim=go.GetComponent<Animator>();
    }

    void Start(){
       anim.CrossFade("GameOver",0);
     
    }




}
