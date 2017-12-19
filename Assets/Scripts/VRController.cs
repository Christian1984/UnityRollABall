using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRController : MonoBehaviour {

    public AudioClip audioFx;
    private AudioSource audioSource;

    public Transform gunBarrelTransform;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioFx;
	}
	
	// Update is called once per frame
	void Update () {
        if (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))
        {
            Debug.Log("trigger");
            audioSource.Play();
            RaycastGun();
        }		
	}

    private void RaycastGun()
    {
        RaycastHit hit;

        if (Physics.Raycast(gunBarrelTransform.position, - gunBarrelTransform.right, out hit))
        {
            if (hit.collider.gameObject.CompareTag("target"))
            {
                Destroy(hit.collider.gameObject);
            }
        }
    }
}
