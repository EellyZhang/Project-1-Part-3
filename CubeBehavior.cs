using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;

public class CubeBehavior : MonoBehaviour {
	public int x, y;
	public bool isPlane;
	public static bool planeSelection;

	// Use this for initialization
	void Start () {
		planeSelection = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


		
	void OnMouseDown() {
		//print("isPlane: "+isPlane);

		if (planeSelection) {
			if (isPlane) {
				GameController.PlaneDeactivation (gameObject);
			}
			
			else {
				GameController.Teleport (gameObject);
			}
		}

		else if (isPlane) {
			GameController.PlaneActivation (gameObject);
			print("x: " + x + "....y: " + y);
		}
	}
}