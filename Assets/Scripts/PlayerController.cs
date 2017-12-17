using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public float speed = 3;
	public Text pickupCountText;
	public Text winText;

	private Rigidbody rb;
	private int pickupCount = 0;

	private void UpdatepickupCountText() 
	{
		pickupCountText.text = "Score: " + pickupCount.ToString();

		if (pickupCount >= 12) 
		{
			winText.text = "YOU WIN!";
		}
	}

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		UpdatepickupCountText ();
		winText.text = "";
	}

	void Update ()
	{ //will be called when a new frame is rendered
		
	}

	void FixedUpdate ()
	{ //will be called on physics update (=> physics code goes here
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		rb.AddForce (speed * new Vector3 (moveHorizontal, 0f, moveVertical));
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag ("pickup")) 
		{
			other.gameObject.SetActive (false);
			pickupCount++;
			UpdatepickupCountText ();
		}
	}
}
