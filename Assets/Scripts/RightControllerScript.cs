using UnityEngine;
using System.Collections;

public class RightControllerScript : MonoBehaviour {

	public float maxSpeed = 10f;
	bool facingRight = true;
	bool facingDown = true;

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		float moveH = Input.GetAxis ("RightHorizontal");
		float moveV = Input.GetAxis ("RightVertical");

		anim.SetFloat ("Speed", Mathf.Abs (moveH));
		anim.SetFloat ("vSpeed", Mathf.Abs (moveV));

		GetComponent<Rigidbody2D>().velocity = new Vector2 (moveH * maxSpeed, moveV * maxSpeed);

		if (moveH > 0 && !facingRight) {
			flip ();
		} else if (moveH < 0 && facingRight) {
			flip ();
		}

		GetComponent<SpriteRenderer> ().sortingOrder = Mathf.RoundToInt (transform.position.y * 100f) * -1;
	}

	void flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
