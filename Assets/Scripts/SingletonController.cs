using UnityEngine;
using System.Collections;

public class SingletonController : MonoBehaviour {
	
	public static GameObject boss;
	public static GameObject player;

	public static float bossTotalLife = 3;
	public static float bossLife = 3;

	private int playerTotalLife = 3;
	public static int playerLife = 3;
	public static GameObject[] heartnemones = new GameObject[3];

	private static bool isPaused = false;
	static private bool spawnTurtles = false;
	static bool firstTime = true;
	GameObject pauseMenu;

	private static AudioSource aS;

	public static bool playerTurtlePUP = false;
	public static bool playerScalopPUP = false;


	void Awake () {
		//This is just to load the intro scene withou messing with the scene indexes
		//TODO: change the indexes from load Scanes for their names.
		if (firstTime) {
			firstTime = false;
			Application.LoadLevel (4);
		} else {

			LoadEnviroment ();
			player = GameObject.Find ("Player");
			StartCoroutine ("TurtleSpawn");
			for (int i = 0; i < playerTotalLife; i++)
				heartnemones [i] = GameObject.Find ("heartnemone" + i);

			aS = GameObject.Find("Song").GetComponent<AudioSource>();
			pauseMenu = GameObject.Find("PauseMenu");
			pauseMenu.SetActive(false);

		}


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
		pauseMenu.SetActive(isPaused);
		Time.timeScale = isPaused ? 0f : 1f;


	}

	void PauseGame(bool menu){
		if (Input.GetKeyUp (KeyCode.P) || Input.GetKeyUp(KeyCode.Joystick1Button9) )
			isPaused = !isPaused;
		
		Time.timeScale = isPaused ? 0f : 1f;
		if (isPaused)
			aS.Pause ();
		else
			aS.UnPause ();




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
		bossTotalLife = 18f;
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
			GameObject.Destroy(boss);
			spawnTurtles = false;

			Application.LoadLevelAdditive(2);
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
			if (bossLife < 0f){
				GameObject.Destroy(boss);
				Application.LoadLevelAdditive(3);
			}
			if( bossLife < bossTotalLife ){
				spawnTurtles = true;
			}

			if( bossLife < bossTotalLife * 0.1f ){
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
