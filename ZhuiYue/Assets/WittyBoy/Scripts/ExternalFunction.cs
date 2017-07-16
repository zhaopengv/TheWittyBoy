using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ExternalFunction  {

	//public PlayerController playerController; 

	void apply (PlayerController playerController,Collision2D other);

}
