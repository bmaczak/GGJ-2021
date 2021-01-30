using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMaze : MonoBehaviour
{
	public float rotationSpeed;

	Rigidbody _rigidbody;

	Vector3 rotateAxis;
	int direction;

	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
	}

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		direction = 0;
		if (Input.GetKey(KeyCode.A))
			SaveRotation(Vector3.forward, 1);
		if (Input.GetKey(KeyCode.D))
			SaveRotation(Vector3.forward, -1);
		if (Input.GetKey(KeyCode.W))
			SaveRotation(Vector3.right, 1);
		if (Input.GetKey(KeyCode.S))
			SaveRotation(Vector3.right, -1);
		if (Input.GetKey(KeyCode.Q))
			SaveRotation(Vector3.up, 1);
		if (Input.GetKey(KeyCode.E))
			SaveRotation(Vector3.up, -1);;
	}

	void SaveRotation(Vector3 axis, int direction)
	{
		rotateAxis = axis;
		this.direction = direction;
	}

	private void FixedUpdate()
	{
		_rigidbody.MoveRotation(_rigidbody.rotation * Quaternion.AngleAxis(direction * rotationSpeed * Time.fixedDeltaTime, rotateAxis));
	}
}
