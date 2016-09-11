using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

	Rigidbody rigid;

	// vaghti meghdari public tarif beshe az to khode unity Mishe taghiresh dad
	//jump = mizane shedate paresh

	public float jump = 10 ,moveSpeed=50;

	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame = 70 bar dar saniye
	void Update () {


		// Input = hameye voroodi ha dar Inputhastand
		// dar code zir meghdar harkat be chap va rast ra dar dir gharar midahim
		float dir = Input.GetAxisRaw("Horizontal");

		/* vaghti player be chap harkat konad meghdar dir manfi va vaghti be rast beravad mosbat mishavad
		 * dar code zir migooyim be chap va rast harkat kon
		 */
		rigid.AddForce (Vector3.right*dir*moveSpeed);

	}
	
	void OnTriggerEnter(Collider col){
		// OnTriggerEnter yani vaghti be triger zarbe khord...
		// veghti khord zamin mire bala dobare

		// dar sharte zir migooyim vaghti ve zamin barkhord kar ...
		if (col.name == "ground") {
			//meghdare avaliye niroye trigger ra 0 mikone
			// har amali yek aksolamali dare
			//vaghti mikhad bere bala ye feshar be pain ham dare...
			rigid.velocity = Vector3.zero;

			//AddForce barayande niroo ra hesab mikonad
			// nirooyi ke be samte paiin dashtim miad balasho ham hesab mikone
			rigid.AddForce (Vector3.up * jump);
		}
	}
	



}

