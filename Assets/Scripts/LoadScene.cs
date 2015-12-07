using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour {
	public int scene;
	public void EndGameIntro(){
		Application.LoadLevel (scene);
	}
}
