using System.Collections;
using System.Collections.Generic;
using UnityEngine;
	
namespace ICode.Actions{
	[Category( "Custom")]
	[Tooltip("Add some tooltip.")]
	[System.Serializable]
	public abstract class BaseAction : StateAction {
	
		// Use this for initialization
		public override void OnEnter () {
            Debug.Log("onEnter in Super");
		}
		
		// Update is called once per frame
		public override void OnUpdate () {
			
		}
	}
}
