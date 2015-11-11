using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class PlayerController : MonoBehaviour {

	// Input variables
	public KeyCode left;
	public KeyCode right;
	public KeyCode jump;
	public KeyCode use;

	// Movement variables
	bool isInAir = false;
	string faceDir = "";
	float chrSpd = .25f;
	float jumpFrc = 512f;
	Rigidbody2D rb;

	// Item variables
	public bool hasBuck = true;
	int buck = 0;
	int buckCap = 5;

	bool hasPlat = false;
	public GameObject tempPlat;

	// UI objects
	public Slider buckMet;

	void Awake() {
		/* Gets the rigidbody component */
		rb = GetComponent<Rigidbody2D>(); }

	void Update() {
		Movement();
	}

	void Movement() {
		/* Moving and jumping with the keys. */
		if (Input.GetKey(left)) {
			faceDir = "left";
			transform.Translate(new Vector2(-chrSpd, 0)); }
		else if (Input.GetKey(right)) {
			faceDir = "right";
			transform.Translate(new Vector2(chrSpd, 0)); }
		if (Input.GetKeyDown(jump) && !isInAir){
			rb.AddForce(new Vector2(0, jumpFrc));
			chrSpd /= 2;
			isInAir = true; }
		// Using items
		if (Input.GetKeyDown(use) && hasPlat) {
			tempPlat.transform.position = new Vector2(transform.position.x + 1.1f, transform.position.y);
			tempPlat.transform.rotation = transform.rotation; 
			hasPlat = false;
			tempPlat.SetActive(true); }
	}

	void CheckBuck() {
		/* Checks if the bucket has filled.
		 * If so, then hasBuck becomes false. */
		buckMet.value = buck;
		if (buck >= buckCap) {
			hasBuck = false; }
	}

	void OnCollisionEnter2D(Collision2D coll) {
		/* Checks collisions of both the ground and the water
		 droplets. */
		if (coll.gameObject.tag == "Ground") {
			chrSpd = 0.25f;
			isInAir = false; }
		else if (coll.gameObject.tag == "Water" && hasBuck) {
			coll.gameObject.SetActive(false); 
			buck++; 
			CheckBuck(); }
		else if (coll.gameObject.tag == "TempPlat" && !hasPlat) {
			hasPlat = true; 
			coll.gameObject.SetActive(false);}
	}
}