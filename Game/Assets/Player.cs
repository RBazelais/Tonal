using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 1000.0F;

	Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {

		rb2d = gameObject.GetComponent<Rigidbody2D> ();
	
	
	}

	// Update is called once per frame
	void Update () {

			Vector2 dir = Vector3.zero;
			dir.y = Input.acceleration.y;
			dir.x = Input.acceleration.x;
			if (dir.sqrMagnitude > 1)
				dir.Normalize();
			
			
			rb2d.velocity = speed * dir;

}
}
