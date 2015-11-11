using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pool : MonoBehaviour {
	public GameObject item;
	int poolAmt = 3;
	public List<GameObject> pool;

	void Awake(){
	// Makes and fills a pool of objects.
		pool = new List<GameObject>();
		for (int i = 0; i < poolAmt; i++){
			GameObject obj = Instantiate(item);
			obj.SetActive(false);
			pool.Add(obj);
		}
	}
}