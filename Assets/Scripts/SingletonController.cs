using UnityEngine;
using System.Collections;

public class SingletonController : MonoBehaviour {

	public static GameObject boss;
	public static GameObject player;

	public static float bossTotalLife = 3;
	public static float bossLife = 3;



	void Start () {
		StartCoroutine("TurtleSpawn");
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	//METHOD WHICH CALLS THE GIANT CRAB
	public static void ReleaseTheCrab(){
		GameObject crab = (GameObject) Resources.Load("Prefabs/Crab");
		boss.SetActive (false);
		Vector3 pos = new Vector3 (0f, 7f, 0f);

		boss = (GameObject) Instantiate (crab, pos, Quaternion.identity);
		bossTotalLife = 50f;
		bossLife = bossTotalLife;
	}

	//METHOD WHICH CALLS THE MEGALODON
	public static void HereComesTheMegalodon(){
		GameObject megalodon = (GameObject) Resources.Load("Prefabs/Megalodon");
		boss.SetActive (false);

		Vector3 pos = new Vector3 (0f, 7f, 0f); // this dont matter the megalodon set its own position
		
		boss = (GameObject) Instantiate (megalodon, pos, Quaternion.identity);
		bossTotalLife = 70f;
		bossLife = bossTotalLife;
	}


	IEnumerator TurtleSpawn(){
		GameObject turtle = (GameObject)Resources.Load ("Prefabs/Turtle");
		Vector3 turtleSpawnPoint;
		turtleSpawnPoint = GameObject.Find ("Turtle Spawn Point").transform.position;

		for (int i = 0; i < 5; i++){
			GameObject gO = (GameObject)Instantiate(turtle, turtleSpawnPoint, Quaternion.Euler(0f,0f,-90f));
			float randomSize = Random.Range(0.75f, 1.25f);

			gO.transform.localScale = Vector3.one * randomSize;

			yield return new WaitForSeconds (1f);

		
		}

		
	}
}
