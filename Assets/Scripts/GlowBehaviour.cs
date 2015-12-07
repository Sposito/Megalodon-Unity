using UnityEngine;
using System.Collections;

public class GlowBehaviour : MonoBehaviour {

	SpriteRenderer sR;
	Color colorIni;
	public float amplitude = 0.5f;
	bool movingToRight = true;
	float speed = 0.01f;
	bool move = true;
	bool up = true;

	Color target;

	void Start () {
		sR = GetComponent<SpriteRenderer> ();
		colorIni = sR.color;
	}
	
	// Update is called once per frame
	void Update () {
		RunRange ();
	}

	void RunRange(){
		sR.color = Color.Lerp (sR.color, target, 0.01f);

		if (sR.color.a > 0.5 && up) {
			target = new Color (colorIni.r, colorIni.g, colorIni.b, 0f);
			up = false;
		}
		if (sR.color.a <= 0.1f && !up) {
			target = new Color (colorIni.r, colorIni.g, colorIni.b, .5f);
			up = true;
		}

	}
}
