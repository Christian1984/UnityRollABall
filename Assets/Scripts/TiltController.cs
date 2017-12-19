using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltController : MonoBehaviour {
	public float maxTilt = 100;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float tiltZ = - Input.GetAxis ("Horizontal");
		float tiltX = Input.GetAxis ("Vertical");

		if (Input.GetMouseButton (0)) {
			Debug.Log (Input.mousePosition);

			tiltZ = -Input.GetAxis ("Mouse X");
			tiltX = Input.GetAxis ("Mouse Y");

			//transform.Rotate (10 * new Vector3 (tiltX, 0f, tiltZ), Space.World);
			transform.RotateAround (Vector3.zero, Vector3.forward, 10 * tiltZ);
			transform.RotateAround (Vector3.zero, transform.right, 10 * tiltX);
		} else {
			Vector3 tilt = new Vector3 (maxTilt * tiltX, 0f, maxTilt * tiltZ);
			Quaternion tiltQuaternion = Quaternion.Euler (tilt);

			transform.rotation = tiltQuaternion;			
		}
	}
}
