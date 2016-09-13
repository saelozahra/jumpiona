using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour
{
	// dar inja yek singleTune az class baraye dastrasi rahat tar behesh tarif kardim 
	// va dar bakhshe awake meghdar dadim
	public static playerController ins ;

	//inja migim mogheye shoroo bazi harkat nakon khodkar
	bool isStarted = false;

	float dir;

	Rigidbody rigid;

	// vaghti meghdari public tarif beshe az to khode unity Mishe taghiresh dad
	//jump = mizane shedate paresh

	public float jump = 10, moveSpeed = 50, maxSpeed = 100;

	// Use this for initialization
	void Start ()
	{
		rigid = GetComponent<Rigidbody> ();
//		charecter f Ke baad az adad oomade code ro tabdil mikone be float
		// maxDepenetrationVelocity baraye velocity max moshakhas mikone
		rigid.maxDepenetrationVelocity = jump * 1.1f;
	}

	
	void Awake ()
	{
		// inja ins ro barabare in class gharar dadim
		ins = this;
	}

	// Update is called once per frame = 70 bar dar saniye
	void Update ()
	{
		// dar in code migim vaghti dokmeye bala ro feshar dad code haye zir ejra shan.
		if (Input.GetKeyDown (KeyCode.UpArrow) && !isStarted) {
			isStarted = true;
			DoJump (jump);
		} else if (Input.GetKeyDown (KeyCode.LeftShift) && Input.GetKeyDown (KeyCode.LeftControl) && Input.GetKeyDown (KeyCode.UpArrow)) {
			// code taghallob : Cheat
			DoJump (jump * 2);
		}


		if (transform.position.x > CameraController.ins.Right ()
			|| transform.position.x < CameraController.ins.Left ())
			transform.position = new Vector3 (-transform.position.x + Mathf.Sign (transform.position.x),
			                                  transform.position.y,
			                                  transform.position.z);





		// Input = hameye voroodi ha dar Inputhastand
		// dar code zir meghdar harkat be chap va rast ra dar dir gharar midahim
		dir = Input.GetAxisRaw ("Horizontal");


		/* vaghti player be chap harkat konad meghdar dir manfi va vaghti be rast beravad mosbat mishavad
		 * dar code zir migooyim be chap va rast harkat kon
		 */
		rigid.AddForce (Vector3.right * dir * moveSpeed);
		//velocity barayande nirooye jesm ast va dar inja nirooye jahate jesm ra bar migardanad
		rigid.velocity = new Vector3 (Mathf.Clamp (rigid.velocity.x, -maxSpeed, maxSpeed), rigid.velocity.y, 0);

	}
	
	void OnTriggerEnter (Collider col)
	{
		
		// OnTriggerEnter yani vaghti be triger zarbe khord...
		// veghti khord zamin mire bala dobare

		if (!isStarted)
			return;

		// dar sharte zir migooyim vaghti ve zamin barkhord kar ...
		if (col.name == "ground") {
			DoJump (jump);
		} else if (col.tag == "coin") {
			// yek laye va tage jadid be name coin ijad kardim va be coin ha nesbat dadim va inja be jaye rooydade name farakhani kardim

			Destroy (col.gameObject);
			DoJump (jump / 1.05f);

			GameController.ins.AddCoin (col.GetComponent<Coin> ().value);
			col.GetComponent<Coin> ().DeleteCoins ();

		}
	}
	
	void DoJump (float power)
	{
/*		//power moshakhas mikonad ke ghodrate paresh cheghadr mibashad
		//meghdare avaliye niroye trigger ra 0 mikone
		// har amali yek aksolamali dare
		//vaghti mikhad bere bala ye feshar be pain ham dare...
		rigid.velocity = Vector3.zero;
		
		//AddForce barayande niroo ra hesab mikonad
		// nirooyi ke be samte paiin dashtim miad balasho ham hesab mikone
		rigid.AddForce (Vector3.up * power);
*/
		//rigid.velocity = Vector3.up * power;  //code ghadimi

		rigid.velocity = new Vector3 (rigid.velocity.x, power, 0);
	}
}