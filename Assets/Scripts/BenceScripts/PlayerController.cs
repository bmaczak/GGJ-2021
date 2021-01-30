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
    private Vector3 inputVector;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (!_useNewAxes)
        {
            inputVector = new Vector3(Input.GetAxis("Horizontal") * _speed, 0, Input.GetAxis("Vertical") * _speed);
        }

        else if (_useNewAxes)
        {

            Vector3 newX = new Vector3(1, 0, 1) * Input.GetAxis("Horizontal");
            Vector3 newZ = new Vector3(-1, 0, 1) * Input.GetAxis("Vertical");

            inputVector = (newX + newZ).normalized * _speed;

        }

        _rigidbody.AddForce(inputVector, (UnityEngine.ForceMode)_forceMode);
        _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0, _rigidbody.velocity.z);
    }
}
