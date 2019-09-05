/*Created by CaelumLaron ~ 05/09/19*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Collider2D))]
public class Hazard : MonoBehaviour{

	public static event Action onDeath;
    
    private void OnTriggerEnter2D(Collider2D other){
    	Debug.Log("You Lose! - Hazard");
    	onDeath();
    }
}
