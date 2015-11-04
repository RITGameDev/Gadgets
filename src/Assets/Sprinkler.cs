//using UnityEngine;
//using System.Collections;
//using Pool;
//
//public class Sprinkler : MonoBehaviour {
//
//	float shotTime = 2f;
//
//	void Shoot() {
//	// Shoots a bullet from the object pool
//		for (int i = 0; i <= pool.Count; i++) {
//			if (!pool[i].activeInHierarchy) {
//				pool[i].transform.position = transform.position;
//				pool[i].transform.rotation = transform.rotation;
//				pool[i].SetActive(true);
//				break; }
//		}
//	}
//
//	void Update() {
//		InvokeRepeating("Shoot", shotTime, shotTime); }
//}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sprinkler : MonoBehaviour {

	public float offSet = 5f;
	float shotTime = 5f;
	public GameObject item;
	int poolAmt = 3;
	List<GameObject> pool;
	
	void Awake(){
		// Makes and fills a pool of objects.
		pool = new List<GameObject>();
		for (int i = 0; i < poolAmt; i++){
			GameObject obj = Instantiate(item);
			obj.SetActive(false);
			pool.Add(obj);
		}
		InvokeRepeating("Shoot", offSet, shotTime);
	}

	void Shoot() {
		// Shoots a bullet from the object pool
		for (int i = 0; i < pool.Count; i++) {
			if (!pool[i].activeInHierarchy) {
				pool[i].transform.position = transform.position;
				pool[i].transform.rotation = transform.rotation;
				pool[i].SetActive(true);
				break; }
			break;
		}
	}

	void Update() {
	}
}
