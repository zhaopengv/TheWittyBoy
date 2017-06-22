using UnityEngine;
using System.Collections;
using CreativeSpore.SuperTilemapEditor;

public class SimpleTileMap : MonoBehaviour {


	Tilemap map;
	float mWidth;
	//public Transform checkStart;
	// Use this for initialization
	void Start () {
		map = GetComponent<Tilemap> ();
		mWidth = map.MapBounds.size.x;
		print ("map width is "+mWidth);


		StartCoroutine (deleteIfInvisible());
	}
	
	// Update is called once per frame
	void Update () {
		
	
	}

	public float getWidth(){

		return mWidth;
	}

	IEnumerator deleteIfInvisible(){

		while (true) {
			float x = Camera.main.ScreenToWorldPoint (Vector3.zero).x;
			if (x > transform.position.x + mWidth) {

				Destroy (gameObject);

			}

			yield return new WaitForSeconds (1);
		}

	}
}
