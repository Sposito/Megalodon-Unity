using UnityEngine;
using System.Collections;
[RequireComponent(typeof(ReceiveDamage))]
public class RemoveTurtle : MonoBehaviour {

	ReceiveDamage rD;
	void Start () {
		rD = GetComponent<ReceiveDamage> ();
	}
	
	// Update is called once per frame
	void Update () {
	if (rD.hits > 0)
			GameObject.Destroy (gameObject);
	}
}
