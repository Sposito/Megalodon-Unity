using UnityEngine;
//using System.Collections;
[RequireComponent(typeof(SpriteRenderer))]
public class PlaceBehindParent : MonoBehaviour {
	void Start () {
		if(transform.parent.GetComponent<SpriteRenderer>() != null)
			GetComponent<SpriteRenderer> ().sortingOrder = transform.parent.GetComponent<SpriteRenderer> ().sortingOrder - 1;
	}
}
