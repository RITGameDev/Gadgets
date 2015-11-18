using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GM : MonoBehaviour {

	public float levelTime = 15f;
	float waitTime = 2f;
	float spawnTime = 2f;
	public Slider timeMet;
	Pool pool;
	// Positions and bounds for the sprinkler's position
	int xPos, yPos; 
	int lBnd = -11, rBnd = 11, dBnd = 0, uBnd = 4;

	void Awake() {
		diceRoll();
		pool = GetComponent<Pool>();
		InvokeRepeating("Sprinkle", waitTime, spawnTime);
	}

	void Update () {
	/* Keeps the level time ticking down until the player wins
	 * the level. */
		levelTime -= Time.deltaTime;
		timeMet.value = levelTime;
		if (levelTime <= 0f){
			Invoke("NextLvl", 2f); }
	}

	void Sprinkle() {
		// Spawns a sprinkler object on-screen every x seconds.
		foreach (GameObject item in pool.pool) {
			if (!item.activeInHierarchy) {
				diceRoll();
				item.transform.position = new Vector2(xPos, yPos);
				item.transform.rotation = transform.rotation;
				item.SetActive(true);
				break; }
		}
	}

	void diceRoll() {
		// "Rolls the dice' and changes xPos and yPos randomly.
		xPos = Random.Range(lBnd, rBnd);
		yPos = Random.Range(dBnd, uBnd);
	}

	void NextLvl () {
	/* Advances the scene to the next level. */
		Application.LoadLevel("TempWin"); }
}
