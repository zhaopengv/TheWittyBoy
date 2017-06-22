using UnityEngine;
using System.Collections;

public class InfiniteRoad : MonoBehaviour {

	public Camera camera;
	public int RoadTypeCount;
	public Transform mPointCheckEnd;
	public Transform mPointCheckStart;
	public GameObject[] tiles;
	public GameObject obstacle;

	float layoutedRoadLength = 61;

	float layoutedObstacle = 0;

	float OBSTACLE_STEP = 34;
	//float tempLayoutObstacle = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
			
		if(mPointCheckEnd.position.x > layoutedRoadLength){
			print ("create Road!!!!");
			StartCoroutine (createRoad(new Vector3(layoutedRoadLength,0,0)));
			layoutedRoadLength += 61;
		}

		//++tempLayoutObstacle;
		if (mPointCheckEnd.position.x - layoutedObstacle > OBSTACLE_STEP) {
			layoutedObstacle += OBSTACLE_STEP;
			GameObject o =(GameObject) GameObject.Instantiate (obstacle, new Vector3 (layoutedObstacle, Random.Range(-2.4f,-2.7f), 0), Quaternion.Euler (Vector3.zero));;
			DestroyObject (o.gameObject,10);
			//o.transform.parent = transform;
			//o.transform.position.Set (layoutedObstacle, 0, 0);
		}


		//print ("c p is " + mPointCheckEnd.position.x + " layoutedRoadLength is " + layoutedRoadLength);

	}

	IEnumerator createRoad(Vector3 position){
		GameObject g = GameObject.Instantiate(tiles[Random.Range(0,tiles.Length -1)]);
		g.transform.parent = transform;

		g.transform.position = position;

		SimpleTileMap simpleTileMap = g.GetComponent<SimpleTileMap> ();

		yield return 0;

	}
}
