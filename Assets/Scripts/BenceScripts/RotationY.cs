using Pixelplacement;
using UnityEngine;

public class RotationY : MonoBehaviour
{
	[SerializeField] private GameObject _rotateable;
	[SerializeField] private Transform _player;
	[SerializeField] private float _rotationAngleHorizontal;
	[SerializeField] private float _rotationDuration;

	private bool _isRotating;
	private Quaternion _startRotation;
	private Quaternion _targetRotation;

	private void Update()
	{
		CheckHorizontalCoordinates();
		CheckPlaneRotation();
	}

	private void CheckHorizontalCoordinates()
	{
		if (!_isRotating)
		{
			if (_player.transform.position.x < 0f)
			{
				RotateBy(Quaternion.Euler(0, -1 * _rotationAngleHorizontal, 0));
			}
			else if (_player.transform.position.z > 0f)
			{
				RotateBy(Quaternion.Euler(0, _rotationAngleHorizontal, 0));
			}
		}
	}

	private void CheckPlaneRotation()
	{
		if (!_isRotating)
		{
			if (Input.GetKeyDown(KeyCode.Q))
			{
				RotateBy(Quaternion.AngleAxis(-120, new Vector3(1, 1, -1)));
			}
			else if (Input.GetKeyDown(KeyCode.E))
			{
				RotateBy(Quaternion.AngleAxis(120, new Vector3(1, 1, -1)));
			}
		}
	}

	void RotateBy(Quaternion amount)
	{
		_isRotating = true;
		_startRotation = _rotateable.transform.rotation;
		_targetRotation = amount * _rotateable.transform.rotation;
		Tween.Value(0f, 1f, OnTweenProgress, _rotationDuration, 0f, Tween.EaseOutStrong, completeCallback: OnTweenFinished);
	}

	private void OnTweenFinished()
	{
		_isRotating = false;
	}

	private void OnTweenProgress(float progress)
	{
		_rotateable.transform.rotation = Quaternion.Slerp(_startRotation, _targetRotation, progress);
	}

	
}
