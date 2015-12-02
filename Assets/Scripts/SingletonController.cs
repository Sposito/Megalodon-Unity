using UnityEngine;
using System.Collections;

public class SingletonController : MonoBehaviour {

	public static GameObject boss;
	public static GameObject player;

	public static float bossTotalLife = 3;
	public static float bossLife = 3;

	private int playerTotalLife = 3;
	private static int playerLife = 3;
	private static GameObject[] heartnemones = new GameObject[3];

	private static bool isPaused = false;
	static private bool spawnTurtles = false;



	void Awake () {
		LoadEnviroment ();
		player = GameObject.Find ("Player");
		StartCoroutine("TurtleSpawn");
		for (int i = 0; i < playerTotalLife; i++)
			heartnemones[i] = GameObject.Find ("heartnemone" + i);




	}
	
	// Update is called once per frame
	void Update () {
		PauseGame ();

	}


	//LOAD GAME ENVIROMENT OBJECTS
	void LoadEnviroment(){
		Application.LoadLevelAdditive (1);
	}

	//PAUSE CURRENT GAME
	void PauseGame(){
		if (Input.GetKeyUp (KeyCode.P) || Input.GetKeyUp(KeyCode.Joystick1Button9) )
			isPaused = !isPaused;
		
		Time.timeScale = isPaused ? 0f : 1f;
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

		Vector3 pos = new Vector3 (0f, 7f, 0f); // this dont matter as the megalodon set its own position
		
		boss = (GameObject) Instantiate (megalodon, pos, Quaternion.identity);
		bossTotalLife = 70f;
		bossLife = bossTotalLife;
	}
	//Player Receives Damage
	public static void PlayerHited(){
		playerLife--;
		switch (playerLife) {
		case 2:
			heartnemones [0].SetActive (false);
			return;
		case 1:
			heartnemones [1].SetActive (false);
			return;
		case 0:
			heartnemones [2].SetActive (false);
			print ("GAME OVER");
			isPaused = true;
			return;
		default:
			return;


		}
		;

		//SpriteRenderer pColor = player.GetComponent<SpriteRenderer> ();
		//Color color = new Color (pColor.color.r, pColor.color.g, pColor.color.b, .5f);
		//pColor.color = color;

	}
	//Boss Receives Damage
	public static void BossHited(){
		bossLife -= 1f;
		if (bossTotalLife > 5f) { // JUST CHECKING IF THE BOSS ISNT THE START BUTTON
			if( bossLife < bossTotalLife ){
				spawnTurtles = true;
			}


		}
	
	
	}

	private static IEnumerable SetPlayerInvunerable(){
		Color pColor = player.GetComponent<SpriteRenderer> ().color;

		while (pColor.a != 1f) {
			yield return new WaitForEndOfFrame();
		}
	}



	IEnumerator TurtleSpawn(){
		while (!spawnTurtles)
			yield return new WaitForSeconds (1f);


		GameObject turtle = (GameObject)Resources.Load ("Prefabs/Turtle");
		Vector3 turtleSpawnPoint;
		turtleSpawnPoint = GameObject.Find ("Turtle Spawn Point").transform.position;

		for (int i = 0; i < 5; i++){
			GameObject gO = (GameObject)Instantiate(turtle, turtleSpawnPoint, Quaternion.Euler(0f,0f,-90f));
			gO.layer = 8; // this sets the turtles in the Enemy layers. That means that only player "stuff" could hit it.
			float randomSize = Random.Range(0.75f, 1.25f);

			gO.transform.localScale = Vector3.one * randomSize;

			yield return new WaitForSeconds (1f);

		
		}
		spawnTurtles = false;
	}
}
