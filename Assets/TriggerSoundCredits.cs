using UnityEngine;
using System.Collections;

public class TriggerSoundCredits : MonoBehaviour {

	public GameObject textTex;
	bool tiktak = true;
	void Awake () {
		//textTex = GameObject.Find("SoundCredits_");

	}
	
	public void Trigger(){
		textTex.SetActive(tiktak);
		tiktak = !tiktak;
	}
}
