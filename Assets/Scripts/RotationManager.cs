using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationManager : MonoBehaviour
{
	[SerializeField] MazeRotator _mazeRotator;
	[SerializeField] private Transform _player;
	[SerializeField] private float _rotationAngleHorizontal;

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
		if (Input.GetKeyDown(KeyCode.Q))
		{
			_mazeRotator.RotateBy(Quaternion.AngleAxis(-120, new Vector3(1, 1, -1)));
		}
		else if (Input.GetKeyDown(KeyCode.E))
		{
			_mazeRotator.RotateBy(Quaternion.AngleAxis(120, new Vector3(1, 1, -1)));
		}
	}
}
