using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

	public float moveSpeed = 0;
	public float timeDelay = 0;
	public float timeInterval = 0;

	public player player;

	Vector3 move;

	// Use this for initialization
	void Start () {
		move = this.transform.position;
		this.transform.rotation = Quaternion.Euler(0, 0, 180);
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
	}
	
	// Update is called once per frame
	void Update () {
		move.y += moveSpeed;
		transform.position = move;

		delayBullet();
	}

	void delayBullet()
    {
		timeDelay += Time.deltaTime;
		if(timeDelay > timeInterval)
        {
			Destroy(gameObject);
			timeDelay = 0;
        }
    }

	void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("enemy"))
        {
			player.score++;
		}

        if (col.CompareTag("groundtop"))
        {
			Destroy(gameObject);
        }
    }
		
}
