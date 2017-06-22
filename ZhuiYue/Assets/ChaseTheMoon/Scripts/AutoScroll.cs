using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScroll : MonoBehaviour {

    public Vector3 translate;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Camera.main.transform.Translate(translate);


    }

    private void LateUpdate()
    {   

     
    }

    private void FixedUpdate()
    {
       
    }
}
