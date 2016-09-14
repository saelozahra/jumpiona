using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour
{

	public int value = 100;
	public GameObject deathParticle, coinSound;
	public AudioClip[] sounds;
	static int soundIndex = 0;
	
	void Start ()
	{
		soundIndex = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	
	public void DeleteCoins ()
	{
		// namayeshe effect baad az sekke khordan
		GameObject g = Instantiate (deathParticle, transform.position, transform.rotation) as GameObject;
		Destroy (g, g.GetComponent<ParticleSystem> ().duration);

		// pakhshe sout baad az seke khordan
		GameObject s = Instantiate (coinSound, transform.position, transform.rotation) as GameObject;
		s.GetComponent<AudioSource> ().clip = sounds [soundIndex];
		s.GetComponent<AudioSource> ().Play ();
		soundIndex = (soundIndex + 1) % sounds.Length;
		Destroy (s, s.GetComponent<AudioSource> ().clip.length);
		//s.GetComponent<AudioSource> ().clip.length = modat zamane clip ra bar migardanad

		// gameObj ra hazf mikonad
		Destroy (gameObject);
	}
}
