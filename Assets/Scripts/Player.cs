/*Created by CaelumLaron ~ 04/09/2019*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{
	
	[Header("Movement Settings")]
	[SerializeField] float walkSpeed = .3f;
	[SerializeField] float groundRunSpeed = 8f;
	[SerializeField] float airRunSpeed = 3f;
	[SerializeField] float jumpHeight = 2f;
	[SerializeField] float gravity = 9.8f; 

	//Cached Variable
	BoxCollider2D bx2d;
	Vector3 velocity;
	bool standing = false, jumpInput, runInput;
	float inputX, inputY, speed;
	bool stopPlayer = false;

	void Start(){
		velocity = Vector3.zero;
		bx2d = GetComponent<BoxCollider2D>();
		Hazard.onDeath += EndGame;
	}

    void Update(){
    	standing = bx2d.IsTouchingLayers(LayerMask.GetMask("Ground"));
    	runInput = Input.GetKey(KeyCode.LeftShift);
    	inputX = Input.GetAxisRaw("Horizontal");
    	speed = !standing? airRunSpeed : (runInput? groundRunSpeed : walkSpeed);
    	if(standing){
    		inputY = .0f;
    		jumpInput = Input.GetButton("Jump");
    		if(jumpInput && !stopPlayer)
    			inputY = Mathf.Sqrt(2 * gravity * jumpHeight);
    	}
    	else
    		inputY -= (gravity * Time.deltaTime);
    	if(stopPlayer)
    		inputX = .0f;
    	velocity = new Vector3(speed * inputX , inputY, .0f);   	
    	transform.position += Time.deltaTime * velocity;
    }

    void EndGame(){
    	Debug.Log("Player Died!");
    	stopPlayer = true;
    	Hazard.onDeath -= EndGame;
    }
}
