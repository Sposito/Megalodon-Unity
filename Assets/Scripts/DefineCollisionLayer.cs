using UnityEngine;
using System.Collections;

public class DefineCollisionLayer : MonoBehaviour {

	public enum collisionLayer{all, player,enemy}

	public collisionLayer kind = collisionLayer.all;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
