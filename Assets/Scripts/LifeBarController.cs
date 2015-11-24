using UnityEngine;
using System.Collections;
[RequireComponent(typeof(SpriteRenderer))]
public class LifeBarController : MonoBehaviour {

	private SpriteRenderer sR;

	public Color colorFull;
	public Color colorMid;
	public Color colorLow;
	private float y;
	void Start () {
		sR = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		float y = SingletonController.bossLife / SingletonController.bossTotalLife ;
		transform.localScale = new Vector3 (1f, y * 15f, 1f) ;
	
		if (y <= 0.5f) {
			sR.color = Color.Lerp(colorLow, colorMid,y * 2); 
		}
		else{
			sR.color = Color.Lerp(colorMid, colorFull, y / 2);
		}
	}
}
