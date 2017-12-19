using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

	public Text pickupCountText;
	public Text winText;

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
		UpdatepickupCountText ();
		winText.text = "";
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
