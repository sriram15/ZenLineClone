using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {
	private Touch currentTouch;
	private CharacterMovement characterMovement;
	private GameController gameController;
	void Start(){
		this.characterMovement = this.gameObject.GetComponent<CharacterMovement>();
		this.gameController = GameObject.Find("GameController").GetComponent<GameController>();
	}
	void Update () {
		if(gameController.isPlayerAlive){
			if ( Input.touchCount > 0 ){
				for (int i = 0; i<Input.touchCount; i++){
					this.currentTouch = Input.GetTouch(i);
					if (this.currentTouch.phase == TouchPhase.Moved){
						this.characterMovement.moveSide(this.currentTouch.deltaPosition.x);
					}
				}
			}else{
				this.gameController.bonusProgressVal += Time.deltaTime * 0.1f;
			}
		}
	}
}
