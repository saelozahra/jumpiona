using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

	/*
	Transform = safhe ii ke alan mibin meghdar hasho mirize dakhelesh
	va be hame chizhaye safhe dastrasi dare
	 */
	[HideInInspector]
	float
		top, maxY, maxDownMove = 20;

	public static CameraController ins ;
	public Transform target;
	public float distance = 1, speed = 10;
	Rigidbody targetRigid;

	void Start ()
	{
		targetRigid = target.GetComponent<Rigidbody> ();
	}

	
	void Awake ()
	{
		ins = this;
	}


	void FixedUpdate ()
	{
		/*
	  * transform doorbin ast
	  * 
	  * transform.position va transform.localposition tafavoteshan dar local va global boodan ast
	  * position global ast
	  * dar code zir x va z az transform ke hamoon camera hast gerefte mishe va y az target ke dadimesh be player gerefte mishe
	  * 
	  * vector3.lerp baraye harkate yek carecter az jayi be jayi ba sorate khasi ast
	  * 
	 */

		transform.position = Vector3.Lerp (transform.position,
		                                   new Vector3 (transform.position.x,
										   			   // Mathf.Sign = کارش اینه که علامت هر عددی که داخلش هست رو بر میگردونه ، یعنی میگه مثلت یا منفی
                                                      target.position.y + Mathf.Sign (targetRigid.velocity.y) * distance,
                                                      transform.position.z),
                                   			speed * Time.deltaTime);

		//new Vector3(transform.position.x,
		//           target.position.y + distance,
		//           transform.position.z);

		/* Mathf.Clamp () = baraye meghdare mahdoode ast
		 * Mathf.Infinity = bi nahayat
		 */
		
		transform.position = new Vector3 (transform.position.x,
		                                 Mathf.Clamp (transform.position.y, 0, Mathf.Infinity),
		                                 transform.position.z);

		// maxY ? transform.position.y : maxY ; = yek nou shart if hast ke kamtar ja migire
		maxY = transform.position.y > maxY ? transform.position.y : maxY;

		// inja migim ke doorbin az in mahdoode kharej nashe
		transform.position = new Vector3 (transform.position.x,
		                                  Mathf.Clamp (transform.position.y, maxY - maxDownMove, Mathf.Infinity),
		                                  transform.position.z);

	}

	
	
	public float Top ()
	{
		top = GetComponent<Camera> ().ViewportToWorldPoint (Vector3.up).y;
		return top;
	}
	
	public float Down {
		get {
			return GetComponent<Camera> ().ViewportToWorldPoint (Vector3.zero).y;
		}
	}
	
	public float Right ()
	{
		return GetComponent<Camera> ().ViewportToWorldPoint (Vector3.right).x;
	}
	public float Left ()
	{
		return GetComponent<Camera> ().ViewportToWorldPoint (Vector3.zero).x;
	}
}
