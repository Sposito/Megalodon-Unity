using UnityEngine;
using System.Collections;

public class LookAtPlayer : LookAtGameObject {
	void Start(){
		target = SingletonController.player;
		angleCompensation = -90;
	}
}
