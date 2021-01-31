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

	[SerializeField] private MazeRotator mazeRotator;

	[SerializeField] private ForceMode _forceMode;

	private Rigidbody _rigidbody;
	[SerializeField] private float _acceleration;
	[SerializeField] private float _maxSpeed;

	[SerializeField] private bool _useNewAxes;
	private float _height;
	private Vector3 _inputVector;
	private Vector3 _relativeVelocityBeforeRotation;

	void Start()
	{
		_rigidbody = GetComponent<Rigidbody>();
		SetGroundHeight();
	}

	private void OnEnable()
	{
		mazeRotator.RotationStarted += OnRotationStarted;
		mazeRotator.RotationFinished += OnRotationFinished;
	}

	private void OnDisable()
	{
		mazeRotator.RotationStarted -= OnRotationStarted;
		mazeRotator.RotationFinished -= OnRotationFinished;
	}


	private void OnRotationStarted()
	{
		_relativeVelocityBeforeRotation = mazeRotator.transform.InverseTransformVector(_rigidbody.velocity);
	}

	private void OnRotationFinished()
	{
		_rigidbody.velocity = mazeRotator.transform.TransformVector(_relativeVelocityBeforeRotation);
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
		if (mazeRotator.IsRotating)
			_rigidbody.velocity = mazeRotator.transform.TransformVector(_relativeVelocityBeforeRotation);
		else
		{
			_rigidbody.AddForce(_inputVector * _acceleration, (UnityEngine.ForceMode)_forceMode);
			_rigidbody.position = new Vector3(_rigidbody.position.x, _height, _rigidbody.position.z);
			_rigidbody.velocity = Vector3.ClampMagnitude(new Vector3(_rigidbody.velocity.x, 0, _rigidbody.velocity.z), _maxSpeed);
		}
	}

	void SetGroundHeight()
	{
        RaycastHit hit;
		if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
        {
            _height = hit.point.y + GetComponent<SphereCollider>().radius;
        }
	}

	public Vector3 InputVector => _inputVector;
}
