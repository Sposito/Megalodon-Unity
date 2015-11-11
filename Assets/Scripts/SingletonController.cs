using UnityEngine;
using System.Collections;

public class SingletonController : MonoBehaviour {

	public static GameObject boss;
	public static GameObject player;


	void Start () {
		StartCoroutine("TurtleSpawn");
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public static void ReleaseTheCrab(){
		GameObject crab = (GameObject) Resources.Load("Prefabs/Crab");
		boss.SetActive (false);
		Vector3 pos = new Vector3 (0f, 7f, 0f);
		boss = (GameObject) Instantiate (crab, pos, Quaternion.identity);
	}

	IEnumerator TurtleSpawn(){
		GameObject turtle = (GameObject)Resources.Load ("Prefabs/Turtle");
		Vector3 turtleSpawnPoint;
		turtleSpawnPoint = GameObject.Find ("Turtle Spawn Point").transform.position;

		for (int i = 0; i < 5; i++){
			Instantiate(turtle, turtleSpawnPoint, Quaternion.Euler(0f,0f,-90f));
			yield return new WaitForSeconds (1f);

		
		}

		
	}
}
