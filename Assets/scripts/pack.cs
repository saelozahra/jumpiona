using UnityEngine;
using System.Collections;

public class pack : MonoBehaviour
{

	public float length = 10, disFromCamera = 10;

	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Camera.main.GetComponent<CameraController>().Down()  downe camera ro migire ke alan be single tune tabdilesh mikonim ke dastrasish rahat tar beshe
		//transform.position.y + length      vaghti az akharesh rad shod remove she
		if (CameraController.ins.Down > transform.position.y + length + disFromCamera)
			DeletePack ();
	}

	public void DeletePack ()
	{
		// hazfe box
		Destroy (gameObject);
	}
}
