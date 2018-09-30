using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	public float speed;
	private Vector3 dir;
	public GameObject PS;
	public GameObject ResetButton;


	private bool isDead;


	// Use this for initialization
	void Start () {
		isDead = false;
		dir = Vector3.forward;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0) && !isDead ) {
			if (dir == Vector3.forward) {	
				dir = Vector3.left;

			}
			else {
				dir = Vector3.forward;
			}

		}

		float amountMove = speed * Time.deltaTime;
		transform.Translate (dir * amountMove);

	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Pickup") {
			other.gameObject.SetActive (false);
			Instantiate (PS, transform.position, Quaternion.identity);
		}

	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Tile") {
			RaycastHit hit;
			Ray downRay = new Ray (transform.position, -Vector3.up);
			if(! Physics.Raycast(downRay, out hit)){
				//kill player
				isDead=true;
				ResetButton.SetActive (true);

				if(transform.childCount>0){
					transform.GetChild (0).transform.parent = null;

				}


			}
		}
	}
		
}
