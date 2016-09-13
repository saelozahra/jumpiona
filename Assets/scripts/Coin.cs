using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour
{

	public int value = 100;
	public GameObject deathParticle;
	
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	
	public void DeleteCoins ()
	{
		GameObject g = Instantiate (deathParticle, transform.position, transform.rotation) as GameObject;
		Destroy (g, g.GetComponent<ParticleSystem> ().duration);
		Destroy (gameObject);
	}
}
