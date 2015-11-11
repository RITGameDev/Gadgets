using UnityEngine;
using System.Collections;

public class Gadget : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Water") {
			gameObject.SetActive(false);
		}
	}
}
