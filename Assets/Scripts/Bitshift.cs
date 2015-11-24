using UnityEngine;
using System.Collections;

public class Bitshift : MonoBehaviour {
	int a = 10;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		a = (a >> 1);
		print (a);
	
	}
}
