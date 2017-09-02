using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {
	public float movementSpeed;
	private EventManager eventManager;

	public void Start(){
		this.eventManager = GameObject.Find("EventManager").GetComponent<EventManager>();
		this.eventManager.playerDeathEvent += stopMovement;
	}

	public void OnDisable(){
		this.eventManager.playerDeathEvent -= stopMovement;
	}

	public void stopMovement(){
		this.movementSpeed = 0;
	}
	
	public void moveSide(float x){
		this.transform.position += Vector3.right * x * Time.deltaTime;
	}

	// Update is called once per frame
	void FixedUpdate () {
		this.transform.position += Vector3.forward * movementSpeed * Time.fixedDeltaTime;
	}

	void OnTriggerEnter(Collider other){
		if(other.tag.Equals("Obstracle")){
			if(eventManager.playerDeathEvent!=null){
				eventManager.playerDeathEvent();
			}
		}
	}

	
}
