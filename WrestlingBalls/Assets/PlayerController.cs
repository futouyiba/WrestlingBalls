using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

	public float speed=20;

	private Rigidbody rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		if (isLocalPlayer)
			gameObject.GetComponent<MeshRenderer> ().material.color = Color.red;
	}

	void FixedUpdate ()
	{
		if (!isLocalPlayer)
			return;

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}
}