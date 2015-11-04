using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public KeyCode left;
	public KeyCode right;
	public KeyCode jump;
	bool isInAir = false;
	string faceDir = "";
	float chrSpd = .25f;
	float jumpFrc = 512f;
	Rigidbody2D rb;

	void Awake() {
		rb = GetComponent<Rigidbody2D>();
	}

	void Update() {
		Movement();
	}

	void Movement() {
		// Moving and Aiming
		if (Input.GetKey(left)) {
			faceDir = "left";
			transform.Translate(new Vector2(-chrSpd, 0)); }
		else if (Input.GetKey(right)) {
			faceDir = "right";
			transform.Translate(new Vector2(chrSpd, 0)); }
		if (Input.GetKeyDown(jump) && !isInAir){
			rb.AddForce(new Vector2(0, jumpFrc));
			chrSpd /= 2;
			isInAir = true;	
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Ground") {
			chrSpd = 0.25f;
			isInAir = false; }
		else if (coll.gameObject.tag == "Water") {
			coll.gameObject.SetActive(false); }
	}
}