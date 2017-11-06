using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour {
	public GameObject cubePrefab;
	Vector3 cubePosition;
	public static GameObject selectedCube;
	static int airplaneX, airplaneY, originX = 0, originY = 8;
	public static int depotX = 15, depotY = 0;
	public GameObject[,] allCube;
	float eachTurnTime, turnTimer;
	public static int airplaneCargo, airplaneCargoMax;
	static int cargoPerGain;
	public static int score;

	// Use this for initialization
	void Start () {
		eachTurnTime = 1.5f;
		turnTimer = eachTurnTime;

		airplaneCargo = 0;
		airplaneCargoMax = 90;
		cargoPerGain = 10;

		score = 0;

		allCube = new GameObject[16,9];

		//starting position for airplane

		airplaneX = originX;
		airplaneY = originY;

		for (int x = 0; x < 16; x++) {
			for (int y = 0; y < 9; y++) {
				cubePosition = new Vector3 (x*2, y*2, 0);
				allCube[x,y] = Instantiate(cubePrefab, cubePosition, Quaternion.identity);

				allCube[x,y].GetComponent<CubeBehavior>().x = x;
				allCube[x,y].GetComponent<CubeBehavior>().y = y;
				allCube[x,y].GetComponent<CubeBehavior>().isPlane = false;

				if (x == originX && y == originY) {
					allCube[x,y].GetComponent<Renderer>().material.color = Color.red;
					allCube[x,y].GetComponent<CubeBehavior>().isPlane = true;
				}

				if (x == depotX && y == depotY) { 
					allCube[x,y].GetComponent<Renderer>().material.color = Color.black;
					allCube[x, y].GetComponent<CubeBehavior>().isPlane = false;
				}
			}
		}
	}



	public static void PlaneActivation(GameObject planeCube) {
		planeCube.GetComponent<Renderer>().material.color = Color.green;
		selectedCube = planeCube;
		CubeBehavior.planeSelection = true;
	}

	public static void PlaneDeactivation(GameObject planeCube) { 
		planeCube.GetComponent<Renderer>().material.color = Color.red;
		CubeBehavior.planeSelection = false;
	}

	public static void Teleport(GameObject Cloud) { 
		selectedCube.GetComponent<Renderer>().material.color = Color.white;
		selectedCube.GetComponent<CubeBehavior>().isPlane = false;
		if (selectedCube.GetComponent<CubeBehavior>().x == depotX && selectedCube.GetComponent<CubeBehavior>().y == depotY) { 
		selectedCube.GetComponent<Renderer>().material.color = Color.black;
		}
		selectedCube = Cloud;
		selectedCube.GetComponent<Renderer>().material.color = Color.red;
		selectedCube.GetComponent<CubeBehavior>().isPlane = true;
		CubeBehavior.planeSelection = false;
		airplaneX = selectedCube.GetComponent<CubeBehavior>().x;
		airplaneY = selectedCube.GetComponent<CubeBehavior>().y;
		}


	void LoadCargo()
	{
		if (airplaneX == originX && airplaneY == originY)
		{
			airplaneCargo += cargoPerGain;

			if (airplaneCargo > airplaneCargoMax)
			{
				airplaneCargo = airplaneCargoMax;
			}
		}
	}

	void DeliverCargo() {
		if (airplaneX == depotX && airplaneY == depotY) {
			score += airplaneCargo;
			airplaneCargo = 0;
		}
	}

	// Update is called once per frame
	void Update () {
		if (Time.time > turnTimer) {
			LoadCargo();
			DeliverCargo();

			//debug
			print("Cargo: " + airplaneCargo + "Score: " + score);

			turnTimer += eachTurnTime;
			}
		}
	}





