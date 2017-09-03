using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	public void btnStartGame(){
		SceneManager.LoadScene(1);
	}
}
