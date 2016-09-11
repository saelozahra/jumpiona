using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

	Rigidbody rigid;

	// vaghti meghdari public tarif beshe az to khode unity Mishe taghiresh dad
	//jump = mizane shedate paresh

	public float jump = 10 ;

	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider col){

		//meghdare avaliye niroye trigger ra 0 mikone
		// har amali yek aksolamali dare
		//vaghti mikhad bere bala ye feshar be pain ham dare...
		rigid.velocity = Vector3.zero;

		//AddForce barayande niroo ra hesab mikonad
		// nirooyi ke be samte paiin dashtim miad balasho ham hesab mikone
		rigid.AddForce (Vector3.up * jump);
	}
	



}
