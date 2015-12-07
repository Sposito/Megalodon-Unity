
using UnityEngine;
using System.Collections;

public class ReceiveDamage : MonoBehaviour {

	public enum DamageableKind {PowerUp, Boss, Player, Other};

	public DamageableKind kind = DamageableKind.PowerUp;
	public GameObject particles;
	private AudioSource sound;

	public int maxHits = 1;
	public int hits;


	private bool boss;
	private bool player;
	private bool powerUp;
	private bool other;

	void Start () {
		sound = GameObject.Find ("BubblesSound").GetComponent<AudioSource>();
		particles = (GameObject)Resources.Load ("Prefabs/BubbleExplosion");
		SetKind ();
	}
	

	void Update () {


	
	}

	void SetKind(){
		boss = false;
		player = false;
		powerUp = false;
		other =  false;

		switch (kind) {
			case DamageableKind.Boss:
				boss = true;
				return;
			case DamageableKind.Player:
				player = true;
				return;
			case DamageableKind.PowerUp:
				powerUp = true;
				return;
			default:
				other = true;
				return;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Projectile")){
			Instantiate (particles, other.transform.position, Quaternion.identity);
			sound.Play();
			hits++;
			Destroy (other.gameObject);

			if (boss){
				SingletonController.BossHited();
			}
			if(player)
				SingletonController.PlayerHited();

			//if(hits >= maxHits)
			//	Destroy (gameObject);
		}

	}
}
