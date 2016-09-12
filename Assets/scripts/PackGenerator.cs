using UnityEngine;
using System.Collections;

public class PackGenerator : MonoBehaviour {

	public float packLength = 11; // toole prefabs ha ra moshakhas mikonim: 11 metr.

	public GameObject[] coinPacks;// Yek araye be esme coinpacks misazim va prefabs ha ro behesh midim

	public CameraController target;

	float lastPackPos ;
	
	void Start () {
		lastPackPos = 0;
		generate ();
	}
	
	// Update is called once per frame
	void Update () {
		if(target.Top() > lastPackPos/2){
			generate();
		}
	}


	void generate(){
		Instantiate (coinPacks [Random.Range(0,coinPacks.Length)],
		             new Vector3(0,lastPackPos,0),
		             Quaternion.identity);

		lastPackPos += packLength;
	}
}

