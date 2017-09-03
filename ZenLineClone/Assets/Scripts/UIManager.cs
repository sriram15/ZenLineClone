using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	Text scoreTxt, bonusTxt, gameOverScoreTxt;
	Image bonusProgress;
	GameController gameController;
	GameObject pauseMenu, gameOverMenu, tutorialMenu, tutFirstPanel, tutSecondPanel;
	EventManager eventManager;

	void Start(){
		scoreTxt = GameObject.Find("ScoreText").GetComponent<Text>();
		bonusTxt = GameObject.Find("BonusText").GetComponent<Text>();
		bonusProgress = GameObject.Find("BonusProgressBar").GetComponent<Image>();
		gameController = GameObject.Find("GameController").GetComponent<GameController>();
		pauseMenu = GameObject.Find("PauseMenu");
		gameOverMenu = GameObject.Find("GameOverMenu");
		tutorialMenu = GameObject.Find("TutorialMenu");
		tutFirstPanel = GameObject.Find("TutorialFirstPanel");
		tutSecondPanel = GameObject.Find("TutorialSecondPanel");
		gameOverScoreTxt = GameObject.Find("GO_TxtScore").GetComponent<Text>();

		gameOverMenu.SetActive(false);
		pauseMenu.SetActive(false);

		if(!PlayerPrefs.HasKey("TutorialShowed")){
			gameController.pauseGame();
			tutorialMenu.SetActive(true);
			tutFirstPanel.SetActive(true);
			tutSecondPanel.SetActive(false);
		}else{
			tutorialMenu.SetActive(false);
		}

		eventManager = GameObject.Find("EventManager").GetComponent<EventManager>();
		eventManager.playerDeathEvent += showGameOverMenu;
	}

	void OnDisable(){
		eventManager.playerDeathEvent -= showGameOverMenu;
	}

	void Update(){
		scoreTxt.text = gameController.score + "";
		bonusTxt.text = "X" + (int)gameController.bonusProgressVal;
		var fillAmount = gameController.bonusProgressVal - (int)gameController.bonusProgressVal;
		bonusProgress.fillAmount = fillAmount;
	}

	public void btnPause(){
		gameController.pauseGame();
		pauseMenu.SetActive(true);
	}

	public void btnResume(){
		gameController.resumeGame();
		pauseMenu.SetActive(false);
	}


	public void btnRestart(){
		gameController.restartGame();
	}
	public void btnOkFirst(){
		tutFirstPanel.SetActive(false);
		tutSecondPanel.SetActive(true);
	}

	public void btnOkSecond(){
		tutSecondPanel.SetActive(false);
		tutorialMenu.SetActive(false);
		gameController.resumeGame();
		PlayerPrefs.SetInt("TutorialShowed", 1);
	}

	public void showGameOverMenu(){
		StartCoroutine(IEnumShowGameOverMenu());
	}
	public IEnumerator IEnumShowGameOverMenu(){
		yield return new WaitForSeconds(1);
		gameOverScoreTxt.text = gameController.score + "";
		gameOverMenu.SetActive(true);
	}
}
