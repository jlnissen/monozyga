﻿using UnityEngine;
using System.Collections;

public class LinkedCameraScript : MonoBehaviour {

	private Vector2 velocity;

	public float smoothTimeX;
	public float smoothTimeY;

	GameObject leftCharacter;
	GameObject rightCharacter;

	// Use this for initialization
	void Start () {
		leftCharacter = GameObject.FindGameObjectWithTag ("LeftCharacter");
		rightCharacter = GameObject.FindGameObjectWithTag ("RightCharacter");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 m = midpoint (leftCharacter.transform.position, rightCharacter.transform.position);

		float posX = Mathf.SmoothDamp (transform.position.x, m.x, ref velocity.x, smoothTimeX);
		float posY = Mathf.SmoothDamp (transform.position.y, m.y, ref velocity.y, smoothTimeY);

		transform.position = new Vector3 (posX, posY, transform.position.z);

		if (Mathf.Abs(Vector3.Distance (leftCharacter.transform.position, rightCharacter.transform.position)) > 10f) {
			GetComponent<Camera> ().enabled = false;
		} else {
			GetComponent<Camera> ().enabled = true;
		}
	}

	private Vector3 midpoint(Vector3 v1, Vector3 v2) {
		Vector3 midpoint = new Vector3 ();
		midpoint.x = v1.x + (v2.x - v1.x) / 2;
		midpoint.y = v1.y + (v2.y - v1.y) / 2;
		midpoint.z = v1.z;
		return midpoint;
	}
}
