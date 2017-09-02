using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public int score;
	public int bonus;
	public float bonusProgressVal;
	public bool isPlayerAlive;
	EventManager eventManager;
	void Start(){
		this.score = 0;
		this.bonus = 1;
		this.bonusProgressVal = 0f;
		isPlayerAlive = true;

		eventManager = GameObject.Find("EventManager").GetComponent<EventManager>();
		eventManager.playerDeathEvent += stopScore;
		
		InvokeRepeating("updateScore", 0f, 0.5f);
	}

	void OnDisable(){
		eventManager.playerDeathEvent -= stopScore;
	}

	void updateScore(){
		this.score++;
	}
	void stopScore(){
		CancelInvoke("updateScore");
		this.isPlayerAlive = false;
	}

	void Update(){
		if(this.bonusProgressVal >= 1){
			this.bonus++;
			this.bonusProgressVal = 0f;
		}
	}
}
