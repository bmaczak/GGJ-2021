using UnityEngine;

public class RaycastController : MonoBehaviour
{
	[SerializeField] float _speed;
	[SerializeField] float _radius;

	Vector3 velocity;
	float skinWidth = 0.01f;

	private void Update()
	{
		velocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * _speed;
		Move();
	}

	void Move()
	{
		MoveX(velocity.x * Time.deltaTime);
		MoveZ(velocity.z * Time.deltaTime);
	}

	void MoveX(float amount)
	{
		RaycastHit hit;
		Vector3 direction = amount < 0 ? Vector3.left : Vector3.right;
		Vector3 p1 = transform.position - direction * skinWidth;
		if (Physics.SphereCast(p1, _radius, direction, out hit, skinWidth + Mathf.Abs(amount)))
			transform.position += direction * (hit.distance - skinWidth);
		else
			transform.position += direction * Mathf.Abs(amount);
	}

	void MoveZ(float amount)
	{
		RaycastHit hit;
		Vector3 direction = amount < 0 ? Vector3.back : Vector3.forward;
		Vector3 p1 = transform.position - direction * skinWidth;
		if (Physics.SphereCast(p1, _radius, direction, out hit, skinWidth + Mathf.Abs(amount)))
			transform.position += direction * (hit.distance - skinWidth);
		else
			transform.position += direction * Mathf.Abs(amount);
	}
}
