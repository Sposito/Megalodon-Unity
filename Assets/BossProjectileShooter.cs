using UnityEngine;
using System.Collections;

public class BossProjectileShooter : MonoBehaviour {

	bool tikTok;
	public GameObject projectilePrefab;
	public float shootInterval = 1f;
	float shootCounter;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		shootCounter += Time.deltaTime;
		if (shootCounter >= shootInterval) {
			Fire ();
			shootCounter = 0f;
		}
	}

	void Fire(){
		Vector3 position = tikTok ? transform.FindChild ("LeftFin").position : transform.FindChild ("RightFin").position;
		GameObject remora = (GameObject)Instantiate(projectilePrefab, position, transform.rotation);
		remora.layer = 8; // This sets the remora in the Enemy's layer of collision, meaning it only hits player´s "stuff"
		tikTok = !tikTok;
		
	}
}
