/*Created by CaelumLaron ~ 05/09/19*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour{

	//Cached variables
	bool gameOver = false;

    void Start(){
        Hazard.onDeath += ShowLoseLabel;
    }

    void Update(){
        if(gameOver && Input.GetKey(KeyCode.Space))
        	SceneManager.LoadScene(1);
    }

    void ShowWinLabel(){
    	Debug.Log("You win!");
    }

    void ShowLoseLabel(){
    	Debug.Log("You Lose!");
    	gameOver = true;
    	Hazard.onDeath -= ShowLoseLabel;
    }


}
