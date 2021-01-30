using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationY : MonoBehaviour
{
    [SerializeField] private GameObject _rotateable;
    [SerializeField] private Transform _labyrinthPivot;
    [SerializeField] private float _speed;

    private bool _doRotate;
    private Quaternion _desiredAngle;
    private float _angle;

    private void OnEnable()
    {
        RotationYTrigger.OnEnterTrigger += DoYRotation;
    }

    private void OnDisable()
    {
        RotationYTrigger.OnEnterTrigger -= DoYRotation;
    }

    private void DoYRotation(string direction)
    {
        if (!_doRotate)
        {
            _angle = 0f;

            switch (direction)
            {
                case "Right":
                    Debug.Log("Rigth case");
                    _angle = 90f;
                    break;
                case "Left":
                    Debug.Log("Left case");
                    _angle = -90f;
                    break;
            }

            _desiredAngle = _rotateable.transform.rotation * Quaternion.Euler(0, _angle, 0);
            _doRotate = true;
            Debug.Log(_doRotate);
            Debug.Log("Active y: " + _rotateable.transform.eulerAngles.y);
            Debug.Log("Desired y: " + _desiredAngle.y);

        }
    }

    private void Update()
    {
        if(_doRotate)
        {
            _rotateable.transform.rotation = Quaternion.Lerp(_rotateable.transform.rotation, _desiredAngle, _speed * Time.deltaTime);

            if (Quaternion.Angle(_desiredAngle, _rotateable.transform.rotation) < 0.1)
            {
                _doRotate = false;
                Debug.Log(_doRotate);
            }
        }
    }
}
