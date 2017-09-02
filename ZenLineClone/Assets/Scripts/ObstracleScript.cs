using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstracleScript : MonoBehaviour {

	public void destroySelf(){
		GameObject.Destroy(this.transform.parent.gameObject);
	}
}
