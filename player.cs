using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

	public float move, maxspeed = 20f;

	public GameObject bullet;
	public GameObject shootPoint;

	public float timeDelay = 0;
	public float timeInterval = 2f;
	public int score = 0;

	gameControl gc;

	private Rigidbody2D r2d;
	private Animation anim;

	// Use this for initialization
	void Start()
	{
		r2d = gameObject.GetComponent<Rigidbody2D>();
		anim = gameObject.GetComponent<Animation>();
		gc = FindObjectOfType<gameControl>();
	}

	// Update is called once per frame
	void FixedUpdate()
	{

		if (Input.GetKey(KeyCode.A))
		{
			transform.position += Vector3.left * move * Time.deltaTime;
			r2d.AddForce(Vector2.left * 0.7f);
		}
		else
		{
			if (Input.GetKey(KeyCode.D))
			{
				transform.position += Vector3.right * move * Time.deltaTime;
				r2d.AddForce(Vector2.right * 0.7f);
			}
		}

        if (Input.GetKey(KeyCode.W))
        {
			transform.position += Vector3.up * move * Time.deltaTime;
        }
        else
        {
            if (Input.GetKey(KeyCode.S))
            {
				transform.position += Vector3.down * move * Time.deltaTime;
            }
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
			Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.localRotation);
        }

	}

	void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("enemy"))
        {
			gc.showOverPanel(true);
			Time.timeScale = 0;
        }

        if (col.CompareTag("bulletenemy"))
        {
			gc.showOverPanel(true);
			Time.timeScale = 0;
		}
    }

	public int getScore()
    {
		return score;
    }
}