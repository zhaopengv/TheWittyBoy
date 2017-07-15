using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ICode;
using System;

public class MonsterJumpAI : MonoBehaviour {


    ICodeBehaviour cb;
    // Use this for initialization
    void Start () {
        cb = gameObject.GetBehaviour(0);

        Debug.Log("cb is " + cb);
        // cb.stateMachine.
       
        FsmVariable move = cb.stateMachine.GetVariable("move");
        move.onVariableChange.AddListener(onVariableChange);

       //FsmVariable nap =  cb.stateMachine.GetVariable("nap");
        //nap.onVariableChange.AddListener(onVariableChange);
	}

    private void onVariableChange(object arg0)
    {
        Debug.Log("onVarChange value is " + arg0);

       // cb.stateMachine.SetVariable("move", false);
    }

    // Update is called once per frame
    void Update () {

       // Debug.Log("state is " + cb.stateMachine.GetState("move").IsEntered);
        

		
	}

    

    
}
