using System.Collections;
using System.Collections.Generic;
using UnityEngine;
	
namespace ICode.Actions{
	
	[Tooltip("巡逻")]
	[System.Serializable]
	public class PatrolAction : BaseAction {

        // Use this for initialization

        public GameObject gameObject;
        public Vector3 point1;
        public Vector3 point2;

		public override void OnEnter () {
            base.OnEnter();
            Debug.Log("move!!!! gameObject is "  + gameObject);
		}
		
		// Update is called once per frame
		public override void OnUpdate () {
            //如果巡逻过程中遇到障碍物应该会自动绕过
			
		}
	}
}
