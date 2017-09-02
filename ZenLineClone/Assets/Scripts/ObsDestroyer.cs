using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsDestroyer : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		other.gameObject.GetComponentInParent<ObstracleScript>().destroySelf();
	}
}
