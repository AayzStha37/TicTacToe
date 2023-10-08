using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnCharacter : MonoBehaviour
{
    public GameObject firstPlayerCharacter;
    public GameObject secondPlayerCharacter;
    public TMP_Text playerTurnIndicator;
    public GameObject popupCanvas;
    // Start is called before the first frame update

    private void OnMouseDown()
    {
        bool firstPlayerturn = this.gameObject.GetComponentInParent<TrackPlayerTurn>().CheckPlayerTurn();
        GameObject spawnObject = new GameObject();
        if (firstPlayerturn){   
            spawnObject = Instantiate(firstPlayerCharacter, transform.position, Quaternion.identity);
            playerTurnIndicator.text = "Player 2 turn"; 
        }
        else{            
            playerTurnIndicator.text = "Player 1 turn"; 
            spawnObject = Instantiate(secondPlayerCharacter, transform.position, Quaternion.identity);
        }

        spawnObject.transform.SetParent(this.gameObject.transform);
        string winningPlayerName = this.gameObject.GetComponentInParent<TrackPlayerTurn>().checkWinningSeq();
        if (winningPlayerName!=null){
            if(winningPlayerName.Contains("P1")){
                Debug.Log("**P1 won**");
                popupCanvas.GetComponentInChildren<TMP_Text>().SetText("Player 1 wins");
                popupCanvas.SetActive(true);
                playerTurnIndicator.text = ""; 
                DestroyScene();
            }   
            else if(winningPlayerName.Contains("P2")){
                Debug.Log("##P2 won##"); 
                popupCanvas.GetComponentInChildren<TMP_Text>().SetText("Player 2 wins");
                popupCanvas.SetActive(true);
                playerTurnIndicator.text = ""; 
                DestroyScene();
            }
        }
    }

    void Start()
    {
        popupCanvas.SetActive(false);
        playerTurnIndicator.text = "Player 1 turn";
    }
    
    void DestroyScene(){
        GameObject[] gameObjectsToDestroy = GameObject.FindGameObjectsWithTag("Destruct");
        foreach(GameObject obj in gameObjectsToDestroy){
            Destroy(obj);
        }
    }
}
