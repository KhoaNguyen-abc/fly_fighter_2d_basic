using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour {

	public enemy enemy;


	// Use this for initialization
	void Start () {
		enemy = GameObject.FindGameObjectWithTag("enemy").GetComponent<enemy>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		MeshRenderer mr = gameObject.GetComponent<MeshRenderer>();
		Vector2 offset = mr.material.mainTextureOffset;
		offset = enemy.transform.position;
		gameObject.GetComponent<MeshRenderer>().material.mainTextureOffset = offset * Time.deltaTime /0.3f;

	}
}
