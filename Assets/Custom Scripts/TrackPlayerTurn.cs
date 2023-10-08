using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using System.Linq;

public class TrackPlayerTurn : MonoBehaviour
{
    bool firstPlayerTurn;
    List<GameObject> childGameObjectList;
    // Start is called before the first frame update
    void Start()
    {
        firstPlayerTurn = false;
        childGameObjectList = new List<GameObject>();
        initilaizeChildGameObjects();
    }

    public bool CheckPlayerTurn(){
        if(firstPlayerTurn){
            firstPlayerTurn = false;
            return firstPlayerTurn;
        }
        else{
            firstPlayerTurn = true;
            return firstPlayerTurn;
        }
    }

    private void initilaizeChildGameObjects(){
        for(int i=0;i<this.gameObject.transform.childCount;i++){
            childGameObjectList.Add(this.gameObject.transform.GetChild(i).gameObject);
        }
    }

    public string checkWinningSeq(){
       WinningSequence winningSequence = new WinningSequence();
       List<string[]> winningSeqList = winningSequence.WinningSeqList;

       string spawnObjectName = " ";
       List<string> spawnObjectNameSeq = new List<string>();

       foreach(string[] winningSeq in winningSeqList){
            foreach(string sequence in winningSeq){
                foreach(GameObject gameObj in childGameObjectList){
                    if(sequence.Equals(gameObj.name) && gameObj.transform.childCount>0){
                        spawnObjectName = gameObj.transform.GetChild(0).gameObject.name;
                        break;
                    }
                }
                spawnObjectNameSeq.Add(spawnObjectName);
                spawnObjectName = " ";
            }
            if(checkSpawnObjectNameSeq(spawnObjectNameSeq))
                return spawnObjectNameSeq[0];
            else
                spawnObjectNameSeq.Clear();
            
       }
        return null;
    }

    private bool checkSpawnObjectNameSeq(List<string> spawnObjectNameSeq)
    {
        return spawnObjectNameSeq.All(str => str == spawnObjectNameSeq[0]);
    }
}
