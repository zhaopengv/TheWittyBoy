using UnityEngine;
using System.Collections;
using System;

public class FollowCamera : MonoBehaviour {

	// Use this for initialization
	public Transform target;
	public float smooth = 1;
	public Vector3 offset;

	Camera mCamera;

	void Start () {
		mCamera = GetComponent<Camera> ();
	}


    public static explicit operator FollowCamera(GameObject v)
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update () {
		//print ("smooth lefp is "+Time.deltaTime * smooth);

		Vector3 targetPosition = target.position + offset;
		targetPosition.y = transform.position.y;
        targetPosition.z = transform.position.z;




		transform.position = Vector3.Lerp (transform.position,targetPosition, Time.deltaTime * smooth);

        //print("");
	}

	void LateUpdate(){



	}
}
