using UnityEngine;
using System.Collections;

public class Searcher : MonoBehaviour {

  GameObject target;
	// Use this for initialization
	void Start () {
	 target = GameObject.Find("Cube");
	}
	
	// Update is called once per frame
	void Update () {
    transform.LookAt(target.transform);	
	}
}
