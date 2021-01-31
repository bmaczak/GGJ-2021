using UnityEngine;
using System.Collections;

public class RotateObject : MonoBehaviour {
	public float speed = 1;

	public bool down = true;
	public bool up = false;
	public bool forward = false;
	public bool Backward = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(down == true){
		this.gameObject.transform.Rotate (Vector3.down * speed);
		
		}

		if(up == true){
			this.gameObject.transform.Rotate (Vector3.forward *-1 * speed);
			
		}

		if(forward == true){
			this.gameObject.transform.Rotate (Vector3.left * speed);
			
		}

		if(Backward == true){
			this.gameObject.transform.Rotate (Vector3.left * -1 * speed);
			
		}
	}
}
