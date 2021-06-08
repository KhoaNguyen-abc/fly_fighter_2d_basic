using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

	public float moveSpeed = 0;
	public float timeDelay = 0;
	public float timeInterval = 0;

	public player player;

	public GameObject bulletEnemy;
	public GameObject shootP;

	private Rigidbody2D r2d;

	// Use this for initialization
	void Start () {
		r2d = gameObject.GetComponent<Rigidbody2D>();
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		r2d.AddForce(Vector2.down * moveSpeed * Time.deltaTime);

		detectedPlayer();
	}

	void detectedPlayer()
    {
		timeDelay += Time.deltaTime;

		if(this.transform.position.y > player.transform.position.y)
        {
			if (timeDelay > timeInterval)
			{
				Instantiate(bulletEnemy, shootP.transform.position, shootP.transform.localRotation);
				timeDelay = 0;
			}
		}	
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

        if (col.CompareTag("Player"))
        {
			moveSpeed = 0;
			Time.timeScale = 0;
        }
    }
}
