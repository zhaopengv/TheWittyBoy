using UnityEngine;
using System.Collections;
using CreativeSpore.SuperTilemapEditor;

public class Obstalcle : MonoBehaviour {

	ParticleSystem mParticle;
	Tilemap mTileMap;
	Renderer render;
	BoxCollider2D boxCollider;
	HeroController heroController;
	// Use this for initialization
	void Start () {
		mParticle = GetComponentInChildren<ParticleSystem> ();
		mTileMap = GetComponent<Tilemap> ();
		render = mTileMap.GetComponent<Renderer> ();
		boxCollider = GetComponent<BoxCollider2D> ();
		GameObject hero = GameObject.FindGameObjectWithTag ("Player");

		heroController = hero.GetComponent<HeroController> ();
	}
	
	// Update is called once per frame
	void Update () {
		boxCollider.isTrigger = boxCollider.isTrigger = heroController.isRush();
	}

	void OnCollisionEnter2D(Collision2D c){
		print ("OnCollision2DEnter");

		if(heroController.isRush()){
			mParticle.Play ();
		}
		//mTileMap.IsVisible = false;
		//boxCollider.enabled = false;
	}

	void OnCollisionStay2D(Collision2D c){
		print ("OnCollisiStay2D");
	}


	void OnTriggerEnter2D(Collider2D c){
		print ("OnTrigger2DEnter");

		//if (heroController.isRush ()) {
			mParticle.Play ();
			mTileMap.IsVisible = false;
		//}
	}
}
