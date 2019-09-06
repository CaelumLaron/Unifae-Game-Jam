/*Created by CaelumLaron ~ 05/09/19*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class MovePlataform : MonoBehaviour{

    [Header("Movement Settings")]
	[SerializeField] Transform[] moveTo = null;
	[SerializeField] float plataformSpeed = 3f;

	[Header("Plataform Settings")] 
	[SerializeField] bool move = false;
	[SerializeField] bool oneTime = false;
	[SerializeField] float timeToDestroy = .5f;

	//Cached Variables
	int currentDestination = 0;
	int currentDir = 1;

    void Update(){
        if(move){
        	if(Vector3.Distance(transform.position, moveTo[currentDestination].position) < Mathf.Epsilon)
        		NextPosition();
        	transform.position = Vector3.MoveTowards(transform.position, moveTo[currentDestination].position, plataformSpeed * Time.deltaTime);
        }
    }

    private void NextPosition(){
    	if((currentDestination == moveTo.Length-1 && currentDir == 1) || (currentDestination == 0 && currentDir == -1))
    		currentDir *= -1;
    	currentDestination += currentDir;
    }

    private IEnumerator DestroyOnTouch(){
    	yield return new WaitForSeconds(timeToDestroy);
    	Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other){
    	if(oneTime)
    		StartCoroutine(DestroyOnTouch());
    }
}
