using UnityEngine;
using System.Collections;

public class LookAtPlayer : LookAtGameObject {

	public bool isTangent = false;

	void Start(){
		target = SingletonController.player;
		angleCompensation = -90;
		if (isTangent)
			angleCompensation = 0;
	}
}
