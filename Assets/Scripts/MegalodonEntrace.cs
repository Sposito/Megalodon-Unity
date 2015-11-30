using UnityEngine;
using System.Collections;
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(WalkHorizontally))]
[RequireComponent(typeof(ReceiveDamage))]

public class MegalodonEntrace : MonoBehaviour {

	public Color shadowIni;

	public float maxYMovementPosition = 10.5f;
	static public float yDefinitivePosition = 3.5f;

	private Color colorBackup;



	private SpriteRenderer sR;
	void Start () {
		sR = GetComponent<SpriteRenderer> ();

		DisableComponents ();

		transform.position = new Vector3(0f, -7f);
		colorBackup = sR.color;
		sR.color = shadowIni;

		StartCoroutine ("MoveUp");

	}
	void DisableComponents(){
		GetComponent<WalkHorizontally> ().enabled = false;
		GetComponent<ReceiveDamage> ().enabled = false;
		GetComponent<LookAtPlayer> ().enabled = false;
		GetComponent<BossProjectileShooter> ().enabled = false;
		Collider2D[] cols = GetComponents<Collider2D> ();
		foreach (Collider2D col in cols) {
			col.enabled = false;
		}

	}

	void EnableComponents(){
		GetComponent<WalkHorizontally> ().enabled = true;
		GetComponent<ReceiveDamage> ().enabled = true;
		GetComponent<LookAtPlayer> ().enabled = true;
		GetComponent<BossProjectileShooter> ().enabled = true;
		Collider2D[] cols = GetComponents<Collider2D> ();
		foreach (Collider2D col in cols) {
			col.enabled = true;
		}
		
	}

	IEnumerator MoveUp(){
		transform.rotation = Quaternion.identity;
		while (transform.position.y < maxYMovementPosition) {
			transform.Translate (Vector3.up * 5 / 100);

			//used for pause the coroutine in the event of a pause
			if(Time.timeScale == 0f){
				yield return new WaitForSeconds(0.1f);
			}
			yield return new WaitForEndOfFrame();
		}
		StartCoroutine ("GetInPlace");
		StopCoroutine ("MoveUp");
	}

	IEnumerator GetInPlace(){
		print ("Called IE");
		sR.color = colorBackup;
		while (transform.position.y >= yDefinitivePosition){
			print ("Inside While");

			transform.rotation = Quaternion.Euler(0f,0f,180f);
			transform.Translate (Vector3.up * 5 / 100);

			//used for pause the coroutine in the event of a pause
			if(Time.timeScale == 0f){
				yield return new WaitForSeconds(0.1f);
			}
			yield return new WaitForEndOfFrame();
		}
		EnableComponents ();
		Destroy (this);
	}
}
