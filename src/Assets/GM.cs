using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GM : MonoBehaviour {

	public float levelTime = 15f;

	public Slider timeMet;

	void Update () {
	/* Keeps the level time ticking down until the player wins
	 * the level. */
		levelTime -= Time.deltaTime;
		timeMet.value = levelTime;
		if (levelTime <= 0f){
			Invoke("NextLvl", 2f); }
	}

	void NextLvl () {
	/* Advances the scene to the next level. */
		Application.LoadLevel("TempWin"); }
}
