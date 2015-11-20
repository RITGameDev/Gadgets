using UnityEngine;
using System.Collections;

//require there is a character component to control
[RequireComponent(typeof(Character))]
public class ACharacterController : MonoBehaviour {

    protected Character character;//character this controller is controlling

	// Use this for initialization
	void Start () {
        character = GetComponent<Character>();
	}
}
