/*Created by CaelumLaron ~ 05/09/19*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health:MonoBehaviour{

	[Header("Health Settings")]
	[SerializeField] int numberLives = 1;

	public void GetDamge(int damage){
		numberLives -= damage;
		if(numberLives == 0)
			EndGame();
	}

	public void EndGame(){
		Debug.Log("Fim de Jogo!");
	}

}
