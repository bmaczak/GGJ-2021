using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
	public enum ForceMode
	{
		Acceleration,
		Force,
		Impulse,
		VelocityChange
	}

	[SerializeField] private ForceMode _forceMode;

	private Rigidbody _rigidbody;
	[SerializeField] private float _speed;

	[SerializeField] private bool _useNewAxes;
	[SerializeField] private float _height;
	private Vector3 _inputVector;

	void Start()
	{
		_rigidbody = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		_inputVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		if (_useNewAxes)
		{
			Vector3 newX = new Vector3(1, 0, 1) * Input.GetAxis("Horizontal");
			Vector3 newZ = new Vector3(-1, 0, 1) * Input.GetAxis("Vertical");
			_inputVector = (newX + newZ).normalized;
		}
	}

	void FixedUpdate()
	{
		_rigidbody.AddForce(_inputVector * _speed, (UnityEngine.ForceMode)_forceMode);
		_rigidbody.position = new Vector3(_rigidbody.position.x, _height, _rigidbody.position.z);
		_rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0, _rigidbody.velocity.z);
	}

	public Vector3 InputVector => _inputVector;
}
