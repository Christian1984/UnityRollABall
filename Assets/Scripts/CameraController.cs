using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;
	public bool rotates;
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		if (!player)
			return;
		
		offset = transform.position - player.transform.position;
		Debug.Log (offset);
	}
	
	// Update is called once per frame
	void LateUpdate () { //runs every frame, but only after everything has been updated in Update()
		if (!player)
			return;

		if (rotates) {
			transform.LookAt (player.transform.position);
			return;
		}

		transform.position = player.transform.position + offset;
	}
}
