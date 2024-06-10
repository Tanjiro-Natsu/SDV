using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mainManager : MonoBehaviour
{
     public static mainManager Instance;

     public static int damage;
     public static Sprite weapon;
     public static int health;
     public static int keys;
     public static int NightBorne=0;
     public static int DragonBorne=0;


   private void Awake()
{
    if (Instance != null)
    {
        Destroy(gameObject);
        return;
    }
    if(SceneManager.GetActiveScene().buildIndex!=0){
    Instance = this;
    DontDestroyOnLoad(gameObject);}
}


void Update(){
 
    if(SceneManager.GetActiveScene().buildIndex>0 && SceneManager.GetActiveScene().buildIndex!=10)
    {damage=GameObject.Find("/Dray/SwordController/Sword").GetComponent<DamageEffect>().damage;
    weapon=GameObject.Find("/Dray/SwordController/Sword").GetComponent<SpriteRenderer>().sprite;
    health=GameObject.Find("/Dray").GetComponent<Dray>().health;
    keys=GameObject.Find("/Dray").GetComponent<Dray>().numKeys;
    NightBorne=GameObject.Find("/Dray").GetComponent<Dray>().NightBornepowerYeld;
    DragonBorne=GameObject.Find("/Dray").GetComponent<Dray>().DragonKnight;}
}
}
