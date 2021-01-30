using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationManager : MonoBehaviour
{
	[SerializeField] MazeRotator _mazeRotator;
	[SerializeField] private PlayerController _player;
	[SerializeField] private float _rotationAngleHorizontal;

	float _playerRadius;

	private void Awake()
	{
		_playerRadius = _player.GetComponent<SphereCollider>().radius;
	}

	private void Update()
	{
		CheckHorizontalCoordinates();
		CheckPlaneRotation();
	}

	private void CheckHorizontalCoordinates()
	{
		if (_player.transform.position.x < 0f)
		{
			_mazeRotator.RotateBy(Quaternion.Euler(0, -1 * _rotationAngleHorizontal, 0));
		}
		else if (_player.transform.position.z > 0f)
		{
			_mazeRotator.RotateBy(Quaternion.Euler(0, _rotationAngleHorizontal, 0));
		}

	}

	private void CheckPlaneRotation()
	{
		if (Mathf.Abs(_player.transform.position.x - 0.776f) < 0.01f && _player.InputVector.x == -1)
		{
			_mazeRotator.RotateBy(Quaternion.AngleAxis(-120, new Vector3(1, 1, -1)));
		}
		else if (Mathf.Abs(_player.transform.position.z + 0.776f) < 0.01f && _player.InputVector.z == 1)
		{
			_mazeRotator.RotateBy(Quaternion.AngleAxis(120, new Vector3(1, 1, -1)));
		}
	}
}
