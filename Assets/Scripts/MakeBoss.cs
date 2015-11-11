using UnityEngine;
using System.Collections;

public class MakeBoss : MonoBehaviour {

	public bool makeBoss;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if (makeBoss)
			SingletonController.boss = gameObject;
	}
}
