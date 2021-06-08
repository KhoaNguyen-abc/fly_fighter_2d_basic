using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_enemy : MonoBehaviour {

	public float moveSpeed = 0;
	Vector3 move;

	// Use this for initialization
	void Start () {
		move = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		move.y -= moveSpeed;
		this.transform.position = move;
	}


	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag("ground"))
		{
			Destroy(gameObject);
		}

		if (col.CompareTag("bullet"))
		{
			Destroy(gameObject);
		}

		if (col.CompareTag("Player")){
			moveSpeed = 0;
		}
    }
}
