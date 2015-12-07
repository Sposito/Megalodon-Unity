using UnityEngine;
using System.Collections;
[RequireComponent(typeof(SpriteRenderer))]

public class StartButtonBehaviour : MonoBehaviour {
	public float speed = 8f;
	public float amplitude = 4.5f;
	public bool movingToRight = true;
	private bool move = true;
	public GameObject particles;
	public SpriteRenderer sR;

	public GameObject sound;

	private bool fadeBool = false;
	// Use this for initialization
	void Start () {
		sR = GetComponent<SpriteRenderer>();

		FixAmplitudebySpriteWidth ();
		SingletonController.boss = gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeScale != 0f)
		MoveAround ();
		FadeOut ();
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Projectile")) {
			//print ("Started!");
			sound.GetComponent<AudioSource>().Play();
			Instantiate (particles, other.transform.position, Quaternion.identity);
			Destroy (other.gameObject);

			SingletonController.bossLife -= 1f;
			if (SingletonController.bossLife <= 0){
				fadeBool = true;
				move = false;
				SingletonController.HereComesTheMegalodon();
			}



		}


	
	}

	void MoveAround(){
		if (transform.position.x >= -amplitude && movingToRight && move) {
			transform.Translate (Vector3.right * speed / 100);
			if (transform.position.x > amplitude){
				transform.position = new Vector3(amplitude, transform.position.y);
				movingToRight = false;
			}
		}
		else if (transform.position.x <= amplitude && !movingToRight && move) {
			transform.Translate (Vector3.left * speed / 100);
			if (transform.position.x < -amplitude){
				transform.position = new Vector3(-amplitude, transform.position.y);
				movingToRight = true;
			}
		}
	}

	void FixAmplitudebySpriteWidth(){
		float w = sR.sprite.bounds.size.x;
		amplitude = amplitude - (w / 2);

	}

	void FadeOut(){
		if (fadeBool) {
			Color32 color = sR.color;
			sR.color = Color32.Lerp (color, new Color32 (color.r, color.g, color.b, 0), 0.05f);
		}
	}
}
