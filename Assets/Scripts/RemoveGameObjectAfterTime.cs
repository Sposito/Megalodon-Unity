using UnityEngine;
using System.Collections;
/// <summary>
/// The Game Object this component is attached to is removed after a given time in seconds;
/// </summary>
public class RemoveGameObjectAfterTime : MonoBehaviour {

	public float seconds = 3f;
	void Start () {
		StartCoroutine ("Remove");
	}
	
	IEnumerator Remove(){
		yield return new WaitForSeconds (seconds);
		Destroy (gameObject);
	}
}
