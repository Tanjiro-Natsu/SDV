using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;


public class OptionMenu : MonoBehaviour
{
   TMP_Text text;
   [Header("Set in Inspector ")]
  
   public GameObject confirm;
   public Sprite ON;
   public Sprite OFF;
   GameObject BackGround;
   


    void Awake(){
 BackGround=GameObject.Find("BackGroundMusic");
    }

    
    public void Press(){
        if(gameObject.name=="ON"){
        if(GetComponent<Image>().sprite==OFF){
           GetComponent<Image>().sprite=ON;
           BackGround.SetActive(true);
           GameObject.Find("OptionsMenu/DelverPanel/MusicaSettings/OFF").GetComponent<Image>().sprite=OFF;
          }
        }
        else if(gameObject.name=="OFF"){
          if(GetComponent<Image>().sprite==OFF){
           GetComponent<Image>().sprite=ON;
           BackGround.SetActive(false);
           GameObject.Find("OptionsMenu/DelverPanel/MusicaSettings/ON").GetComponent<Image>().sprite=OFF;} 
        }
        else if(gameObject.name=="ON1"){
       if(GetComponent<Image>().sprite==OFF){
           GetComponent<Image>().sprite=ON;
          GameObject.Find("Main Camera").GetComponent<EffectSoundStart>().Effect=1;
           GameObject.Find("OptionsMenu/DelverPanel/EffectSettings (1)/OFF1").GetComponent<Image>().sprite=OFF;}
       }
         else if(gameObject.name=="OFF1"){
       if(GetComponent<Image>().sprite==OFF){
           GetComponent<Image>().sprite=ON;
           GameObject.Find("Main Camera").GetComponent<EffectSoundStart>().Effect=0;
           GameObject.Find("OptionsMenu/DelverPanel/EffectSettings (1)/ON1").GetComponent<Image>().sprite=OFF;}
       }

if(GameObject.Find("Main Camera").GetComponent<EffectSoundStart>().Effect==1){
        Destroy(Instantiate(confirm),1);}

    }

    public void close(){
        GameObject.Find("OptionsMenu").SetActive(false);
    }
    }
