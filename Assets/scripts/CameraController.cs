using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	/*
	Transform = safhe ii ke alan mibin meghdar hasho mirize dakhelesh
	va be hame chizhaye safhe dastrasi dare
	 */

	public Transform target;

	void Start () {
	
	}

	
	void Update () {
	 /*
	 */

	}


	void LateUpdate () {
		/*
	  * transform doorbin ast
	  * 
	  * transform.position va transform.localposition tafavoteshan dar local va global boodan ast
	  * position global ast
	  * dar code zir x va z az transform ke hamoon camera hast gerefte mishe va y az target ke dadimesh be player gerefte mishe
	 */
		transform.position = new Vector3(transform.position.x,
		                                 target.position.y,
		                                 transform.position.z);
		
		/* Mathf.Clamp () = baraye meghdare mahdoode ast
		 * Mathf.Infinity = bi nahayat
		 */
		
		transform.position = new Vector3(transform.position.x,
		                                 Mathf.Clamp (target.position.y,0,Mathf.Infinity),
		                                 transform.position.z);
	}
}
