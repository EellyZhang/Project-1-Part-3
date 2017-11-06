using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cargo : MonoBehaviour {

	Text textComponent;



	// Use this for initialization
	void Start () {
		textComponent = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		textComponent.text = "Cargo:" + GameController.airplaneCargo.ToString();
	}
}
