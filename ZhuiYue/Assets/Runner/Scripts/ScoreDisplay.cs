using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

	public GameObject hero;
	Text text;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		text.text = string.Format("{0:D5}",(int)Mathf.Max (0, Mathf.Round (hero.transform.position.x)));;
	}

	void onGUI(){
		
	}
}
