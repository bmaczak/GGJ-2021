using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationY : MonoBehaviour
{
    [SerializeField] private GameObject _rotateable;
    [SerializeField] private Transform _labyrinthPivot;
    [SerializeField] private Transform _labyrinthPlaneAxis;
    [SerializeField] private float _speed;
    [SerializeField] private Transform _player;
    [SerializeField] private float _rotationAngleHorizontal;
    [SerializeField] private float _deltaRotationY;
    [SerializeField] private float _rotationAnglePlane;

    private bool _doRotateY;
    private bool _doRotatePlane;
    private Quaternion _desiredYAngle;
    private Quaternion _desiredPlaneAngle;
    private float _angle;

    private void OnEnable()
    {
        //RotationYTrigger.OnEnterTrigger += DoYRotation;
    }

    private void OnDisable()
    {
        //RotationYTrigger.OnEnterTrigger -= DoYRotation;
    }

    /*
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
    }*/

    private void Update()
    {
        CheckHorizontalCoordinates();
        DoYRotation();
        CheckPlaneRotation();
        DoPlaneRotation();

    }

    private void CheckHorizontalCoordinates()
    {
        if(!_doRotateY && !_doRotatePlane)
        {
            if (_player.transform.position.x < 0f)
            {
                SetNewYAngle((_rotationAngleHorizontal * -1));
            }

            else if (_player.transform.position.z > 0f)
            {
                SetNewYAngle(_rotationAngleHorizontal);
            }
        }
    }

    private void SetNewYAngle(float angle)
    {
        _desiredYAngle = _rotateable.transform.rotation * Quaternion.Euler(0, angle, 0);
        _doRotateY = true;
    }

    private void DoYRotation()
    {
        if (_doRotateY && !_doRotatePlane)
        {
            _rotateable.transform.rotation = Quaternion.Lerp(_rotateable.transform.rotation, _desiredYAngle, _speed * Time.deltaTime);

            if (Quaternion.Angle(_desiredYAngle, _rotateable.transform.rotation) < _deltaRotationY)
            {
                _doRotateY = false;
            }
        }
    }

    private void CheckPlaneRotation()
    {
        if (!_doRotateY && !_doRotatePlane)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                SetNewPlaneAngle((_rotationAnglePlane * -1));
            }
        }
       
        
    }

    private void SetNewPlaneAngle(float angle)
    {
        //_desiredPlaneAngle = _rotateable.transform.rotation * Quaternion.AngleAxis(angle, _labyrinthPlaneAxis.forward);
        _desiredPlaneAngle = _rotateable.transform.rotation * Quaternion.Euler(0, -90, 90);
        _doRotatePlane = true;
    }

    private void DoPlaneRotation()
    {
        if (!_doRotateY && _doRotatePlane)
        {
            _rotateable.transform.rotation = Quaternion.Lerp(_rotateable.transform.rotation, _desiredPlaneAngle, _speed * Time.deltaTime);

            if (Quaternion.Angle(_desiredPlaneAngle, _rotateable.transform.rotation) < _deltaRotationY)
            {
                _doRotatePlane = false;
            }
        }
    }
}
