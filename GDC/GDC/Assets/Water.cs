using UnityEngine;
using System.Collections;

public class Water : MonoBehaviour {
	float speed = .25f;
	void OnEnable() {
		Invoke("Destroy", 2f); }

	void Update() {
	// Makes the drop fall.
		transform.Translate(new Vector2(0f, -speed)); }

	void Destroy() {
		gameObject.SetActive(false); }

	void OnDisable() {
		CancelInvoke();
	}
}
