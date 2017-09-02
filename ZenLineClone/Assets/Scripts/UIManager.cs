using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	Text scoreTxt, bonusTxt;
	Image bonusProgress;
	GameController gameController;
	void Start(){
		scoreTxt = GameObject.Find("ScoreText").GetComponent<Text>();
		bonusTxt = GameObject.Find("BonusText").GetComponent<Text>();
		bonusProgress = GameObject.Find("BonusProgressBar").GetComponent<Image>();
		gameController = GameObject.Find("GameController").GetComponent<GameController>();
		
	}

	void Update(){
		scoreTxt.text = gameController.score + "";
		bonusTxt.text = "X" + gameController.bonus;
		bonusProgress.fillAmount = gameController.bonusProgressVal;
	}
}
