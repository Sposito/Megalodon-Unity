using UnityEngine;
using System.Collections;

public class PlayerScallopsController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		for (int i = 0; i <= transform.childCount; i++) {
			transform.GetChild(i).SetParent(null);
		}

		Destroy (gameObject);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
