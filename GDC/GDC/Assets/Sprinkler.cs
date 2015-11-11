using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sprinkler : MonoBehaviour {

	public float offSet = 5f;
	float shotTime = 5f;
	Pool pool;

	void Start(){
		pool = GetComponent<Pool>();
		InvokeRepeating("Shoot", offSet, shotTime);
	}

	void Shoot() {
		// Shoots a bullet from the object pool
		foreach (GameObject item in pool.pool) {
			if (!item.activeInHierarchy) {
				item.transform.position = transform.position;
				item.transform.rotation = transform.rotation;
				item.SetActive(true);
				break; }
		}
	}
}