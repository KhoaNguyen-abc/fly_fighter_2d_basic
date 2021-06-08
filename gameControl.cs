using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameControl : MonoBehaviour {

	public float timeDelay = 0;
	public float timeInterval = 0;

	public GameObject enemy1;
	public GameObject enemy2;
	public GameObject overPanel;

	public int score = 0;

	public Text scoreText;
	public Text beginGame;

	public player player;

	// Use this for initialization
	void Start () {
		scoreText.text = "Score: " + 0;
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
	}
	
	// Update is called once per frame
	void Update () {
		float posX = Random.Range(-5, 6);
		float posY = Random.Range(6, 9);

		if(enemy1.transform.position.x != enemy2.transform.position.x)
        {
			spawnEnemy(enemy1, posX, posY);
			spawnEnemy(enemy2, posX, posY);
        }
        else
        {
			return;
        }

        if (scoreText)
        {
			scoreText.text = "Score: " + player.getScore();
		}
		
	}

	void spawnEnemy(GameObject obj, float x, float y)
    {
		timeDelay += Time.deltaTime;
		if(timeDelay > timeInterval)
        {
			beginGame.text = "";
			Instantiate(obj, new Vector2(x, y), Quaternion.identity);
			timeDelay = 0;
        }
    }

	public void showOverPanel(bool isActive)
    {
		overPanel.SetActive(isActive);
    }

	public void rePlay()
    {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		showOverPanel(false);
		Time.timeScale = 1;
    }

}
