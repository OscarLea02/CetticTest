using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDestroy : MonoBehaviour {
	public float timeDead; //Tiempo de vida del objeto
	// Use this for initialization
	void Start () {
		//Destruye este objeto luego del tiempo de vida establecido en "timeDead"
		Destroy (gameObject, timeDead);
	}
}
