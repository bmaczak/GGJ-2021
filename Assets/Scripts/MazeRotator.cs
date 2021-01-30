using Pixelplacement;
using UnityEngine;

public class MazeRotator : MonoBehaviour
{
	[SerializeField] private float _rotationDuration;

	private bool _isRotating;
	private Quaternion _startRotation;
	private Quaternion _targetRotation;

	public void RotateBy(Quaternion amount)
	{
		if (_isRotating)
			return;
		_isRotating = true;
		_startRotation = transform.rotation;
		_targetRotation = amount * transform.rotation;
		Tween.Value(0f, 1f, OnTweenProgress, _rotationDuration, 0f, Tween.EaseOutStrong, completeCallback: OnTweenFinished);
	}

	private void OnTweenFinished()
	{
		_isRotating = false;
	}

	private void OnTweenProgress(float progress)
	{
		transform.rotation = Quaternion.Slerp(_startRotation, _targetRotation, progress);
	}
}
