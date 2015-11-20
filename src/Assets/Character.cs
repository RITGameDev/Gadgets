using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Character : MonoBehaviour
{
    enum Dir { Left, Right };

	// Movement variables
	public int jumpsRem = 2;
    Dir faceDir = Dir.Left;
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
		rb = GetComponent<Rigidbody2D>(); 
    }

    void Start()
    {
        if (GetComponent<ACharacterController>() == null)
        {
            Debug.LogWarning("Character has no character controller");
        }
    }

    public void MoveLeft()
    {
        faceDir = Dir.Left;
        transform.Translate(new Vector2(-chrSpd, 0)); 
    }

    public void MoveRight()
    {
        faceDir = Dir.Right;
        transform.Translate(new Vector2(chrSpd, 0)); 
    }

    public void Jump()
    {
        if (jumpsRem > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(0, jumpFrc));
            chrSpd /= 2;
            jumpsRem -= 1;
        }
    }

    public void Use()
    {
        if (hasPlat)
        {
            tempPlat.transform.position = new Vector2(transform.position.x, transform.position.y + 1.1f);
            tempPlat.transform.rotation = transform.rotation;
            hasPlat = false;
            tempPlat.SetActive(true);
        }
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
			jumpsRem = 2; }
		else if (coll.gameObject.tag == "Water" && hasBuck) {
			coll.gameObject.SetActive(false); 
			buck++; 
			CheckBuck(); }
		else if (coll.gameObject.tag == "TempPlat" && !hasPlat) {
			hasPlat = true; 
			coll.gameObject.SetActive(false);}
	}
}