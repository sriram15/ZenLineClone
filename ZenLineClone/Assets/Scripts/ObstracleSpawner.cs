using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstracleSpawner : MonoBehaviour {

	// Use this for initialization
	public Transform generationPoint;
	public GameObject[] obs;
	public GameObject obsHolder;
	private float obsWidth;
	private int lastSpanwed;
	void Start () {
		obsWidth = 25f;
		lastSpanwed = 0;
	}
	void Update(){
		if (transform.position.z < generationPoint.position.z) {
			int randIndex;
			if(transform.position.z < 15){
				randIndex = 0;
			}else{
				randIndex = Random.Range(1,obs.Length);
				if(randIndex == lastSpanwed){
					randIndex = Random.Range(1,obs.Length);
				}
			}
			lastSpanwed = randIndex;
			
			GameObject newPlatform  = (GameObject)Instantiate(obs[randIndex], transform.position, obs[randIndex].transform.rotation);
			newPlatform.transform.parent = obsHolder.transform;
			
			transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + obsWidth);
		}
	}
}
