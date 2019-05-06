using UnityEngine;
using System.Collections;

public class RotateCube : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    transform.Rotate(1,0.5f,0.1f);
	}
}
