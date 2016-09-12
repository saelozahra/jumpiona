using UnityEngine;
using System.Collections;

public class pack : MonoBehaviour
{

	public float length = 10;

	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Camera.main.GetComponent<CameraController>().Down()  downe camera ro migire
		//transform.position.y + length      vaghti az akharesh rad shod remove she
		if (Camera.main.GetComponent<CameraController> ().Down () > transform.position.y + length)
			DeletePack ();
	}

	public void DeletePack ()
	{
		// hazfe box
		Destroy (gameObject);
	}
}
