using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGEnviroment : MonoBehaviour {

    //水平方向跟随相机移动

    float lastCameraX;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

       
		
	}

    void LateUpdate()
    {
        float movedX = Camera.main.transform.position.x - lastCameraX;

        lastCameraX = Camera.main.transform.position.x;

       

        if (movedX != 0)
        {
            print("movedX is " + movedX);
            transform.Translate(Vector3.right * movedX);
        }


    }
}
