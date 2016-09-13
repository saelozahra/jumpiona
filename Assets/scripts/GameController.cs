using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	public static GameController ins ;

	bool isGameOver;
	float collectedCoins = 0 ;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (playerController.ins.transform.position.y + 2 < CameraController.ins.Down && !isGameOver) {
			GameOver ();
		}
	}


	void Awake ()
	{
		ins = this;
	}
	void GameOver ()
	{
		print ("Game Over");
		isGameOver = true;
		playerController.ins.gameObject.SetActive (false);
		// TODO: Menu 
	}

	public void AddCoin (int value)
	{
		collectedCoins += value;
		print ("Coins: " + collectedCoins);
	}
}
