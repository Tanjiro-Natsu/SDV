
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class DungeonCreator : MonoBehaviour{
    

public static  int [,]  dungeon=new int[112,77];
private static int hstanza=11;
private static int wstanza=16;
public static int  startX;
public static int startY;
public static int startx;
public static int starty;
public static int Boss1x;
public static int Boss1y;
public static int Boss2x;
public static int Boss2y;
public static int Boss3x;
public static int Boss3y;
public static int nextLevelx;
public static int nextLevely;
 
public static List<Vector3> closeDoor;
 
    static public Transform TILE_ANCHOR;
    public static Tile1[,] TILES;

public  static int [,] nstanze=new int[7,7];

public static int[,] route(int [,] map){
  
   int start=Random.Range(0,4);
   
   switch(start){
    case 0:
     starty=0;
     startx=Random.Range(0,7);
    
    break;
    case 1:
     startx=6;
     starty=Random.Range(0,7);
    break;
    case 2:
     starty=6;
     startx=Random.Range(0,7);
    break;
    case 3:
    starty=Random.Range(0,7);
    startx=0;
    break;
   }
   int roomnumeber=100;
    startY=starty*10+5;
     startX=startx*15+8;
   map[starty,startx]=1;
   
   for (int i=0;i<roomnumeber;i++){
int directions=Random.Range(0,4);
switch (directions){
    case 0:
    if(starty>0){
        starty-=1;
    }
    break;
    case 1:
 if(startx<6){
        startx+=1;
    }
    break;
    case 2:
 if(starty<6){
        starty+=1;
    }
    break;
    case 3:
 if(startx>0){
        startx-=1;
    }
    break;
}
map[starty,startx]=1;
   }

return map;
    
}

public static void setmap(){
    int [,] momentaneo=new int[7,7];
    for (int i=0;i<7;i++){
        for (int k=0;k<7;k++){
            momentaneo[i,k]=0;
        }
    }
    nstanze=route(momentaneo);
    fillmap();}
     


public static  void fillmap(){
    for(int mm=0;mm<112;mm++){
        for(int u=0;u<77;u++){
         dungeon[mm,u]=0;
        }
    }
    for(int i=0;i<7;i++){
        for(int k=0;k<7;k++){
             if(nstanze[i,k]==1){
            for (int j=0;j<wstanza;j++){
                for (int g=0;g<hstanza;g++){
                   work(j,i,g,k);

                    }
                }
            }
        }
    
    }
    
    setDoor();
    setBossRoom();
 setNextLevel();
    
}
 static public int GET_MAP(int x,int y){
        if(x<0 || x>=112 || y<0 || y>=77){
            return -1;
        } 
        return dungeon[x,y];
    }
    

    static void work(int j,int i,int g,int k){

if(j==0 || j==1 || j==14 || j==15){
    if((j==14 || j==1) && Random.Range(0,10)==2 && (g>2 || g<8)){
dungeon[j+i*16,g+k*11]=24;
    }
    else{
                    dungeon[j+i*16,g+k*11]=3;}
                   }
                   if(g==0 || g==1 || g==9 || g==10 ){
if(g==9 && Random.Range(0,10)==2 && (j>3 || j<10)){
dungeon[j+i*16,g+k*11]=23;
}
                    
                   else{dungeon[j+i*16,g+k*11]=3;}
                   }
                   if(g>1 && g<9 && j>1 && j<14){
                   dungeon[j+i*16,g+k*11]=1;}
                  
    
    }
    
    static void setDoor(){
 for(int i=0;i<7;i++){
        for(int k=0;k<7;k++){
          if(nstanze[k,i]==1){
            if(k+1<7){
if(nstanze[k+1,i]==1){
                dungeon[k*16+14,i*11+5]=70;
                }
            }
            if(i+1<7){
                 if(nstanze[k,i+1]==1){
                dungeon[k*16+7,i*11+9]=52;
                dungeon[k*16+8,i*11+9]=53;}
            }
            if(k-1>=0){
                if(nstanze[k-1,i]==1){
                dungeon[k*16+1,i*11+5]=67;
               }
            }
            if(i-1>=0){
                if(nstanze[k,i-1]==1){
                dungeon[k*16+7,i*11+1]=84;
                dungeon[k*16+8,i*11+1]=85;}
                
            }
          }
        }
    }
    }

    static void setBossRoom(){

 
while(true){

    Boss1x=Random.Range(0,7);
    Boss2x=Random.Range(0,7);
    Boss3x=Random.Range(0,7);
    Boss1y=Random.Range(0,7);
    Boss2y=Random.Range(0,7);
    Boss3y=Random.Range(0,7);
    if(nstanze[Boss1x,Boss1y]==1 && nstanze[Boss3x,Boss3y]==1 && nstanze[Boss2x,Boss2y]==1 && Boss1x!=Boss2x && Boss1x!=Boss3x && Boss2x!=Boss3x && Boss1y!=Boss2y && Boss1y!=Boss3y && Boss2y!=Boss3y ){
       break;
    }
    
}
//Debug.Log("Boss1x="+(Boss1x*16+7)+"  Boss1y="+(Boss1y*11+4.5f)+"\nBoss2x="+(Boss2x*16+7)+"  Boss2y="+(Boss2y*11+4.5f)+"\nBoss3x="+(Boss3x*16+7)+"    Bossy="+(Boss3y*11+4.5f));
closeDoor=new List<Vector3>();
List<int> locateBoss=new List<int>(){Boss1x,Boss1y,Boss2x,Boss2y,Boss3x,Boss3y};
for(int s=0;s<6;s+=2){
for (int i=0;i<16;i++){
    for (int k=0;k<11;k++){
        switch(dungeon[16*locateBoss[s]+i,locateBoss[s+1]*11+k]){
            case 52:
            dungeon[16*locateBoss[s]+i,locateBoss[s+1]*11+k+3]=88;
            closeDoor.Add(new Vector3(16*locateBoss[s]+i,locateBoss[s+1]*11+k+3,0));
            break;
            case 53:
            dungeon[16*locateBoss[s]+i,locateBoss[s+1]*11+k+3]=89;
            closeDoor.Add(new Vector3(16*locateBoss[s]+i,locateBoss[s+1]*11+k+3,0));
            break;
            case 84:
            dungeon[16*locateBoss[s]+i,locateBoss[s+1]*11+k-3]=56;
            closeDoor.Add(new Vector3(16*locateBoss[s]+i,locateBoss[s+1]*11+k-3,0));
            break;
            case 85:
            dungeon[16*locateBoss[s]+i,locateBoss[s+1]*11+k-3]=57;
            closeDoor.Add(new Vector3(16*locateBoss[s]+i,locateBoss[s+1]*11+k-3,0));
            break;
            case 67:
            dungeon[16*locateBoss[s]+i-3,locateBoss[s+1]*11+k]=73;
            closeDoor.Add(new Vector3(16*locateBoss[s]+i-3,locateBoss[s+1]*11+k,0));
            break;
            case 70:
            dungeon[16*locateBoss[s]+i+3,locateBoss[s+1]*11+k]=72;
            closeDoor.Add(new Vector3(16*locateBoss[s]+i+3,locateBoss[s+1]*11+k,0));
           break;
    }
}
    }}

    

}
   
     static void setNextLevel(){
       
  for (int k=0;k<7;k++){
            for (int i=0;i<7;i++){
if(DungeonCreator.nstanze[k,i]==1 && k!=Boss1x && k!=Boss2x && k!=Boss3x && i!=Boss1y && i!=Boss2y && i!=Boss3y){
 nextLevelx=k;
nextLevely=i;
DungeonCreator.dungeon[nextLevelx*16+7,nextLevely*11+5]=2;
return;
}
            }
            }
    
}
    
    }