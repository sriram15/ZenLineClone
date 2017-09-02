using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerFollow : MonoBehaviour {
	public GameObject player;
	private float offset;
	public Transform camTransform;
	public float shakeDuration = 0f;
	public float shakeAmount = 0.7f;
	public float decreaseFactor = 1.0f;
	
	private EventManager eventManager;
	Vector3 originalPos;
	
	void Awake()
	{
		if (camTransform == null)
		{
			camTransform = GetComponent(typeof(Transform)) as Transform;
		}
		
	}
	
	void OnEnable()
	{
		originalPos = camTransform.localPosition;

		this.offset = this.transform.position.z - player.transform.position.z;

		this.eventManager = GameObject.Find("EventManager").GetComponent<EventManager>();
		this.eventManager.playerDeathEvent += shakeCam;
	}

    private void shakeCam()
    {
        shakeDuration = 0.5f;
    }

    void Update()
	{
		if (shakeDuration > 0)
		{
			camTransform.localPosition = originalPos + UnityEngine.Random.insideUnitSphere * shakeAmount;
			
			shakeDuration -= Time.deltaTime * decreaseFactor;
		}
		else
		{
			shakeDuration = 0f;
			camTransform.localPosition = originalPos;
		}

		this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.player.transform.position.z + offset);
	}
}
