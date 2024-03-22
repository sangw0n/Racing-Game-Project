using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public struct Wheel
{
    public GameObject wheelModel;
    public WheelCollider wheelCollider;
    public Axel axel;
}

public enum Axel
{
    Front,
    Rear
}

public class CarController : MonoBehaviour
{
    public Wheel[] wheels;

    [Header("# Car Drive Var")]
    [SerializeField] private int maxAcceleration;
    [SerializeField] private int brakeAcceleration;

    [SerializeField] private int maxSteerAngle;
    [SerializeField] private float steerSensitivity;

    private Vector3 inputVec = Vector3.zero;
    private Rigidbody rigid;

    private void Awake() 
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        rigid.centerOfMass = Vector3.zero;
    }

    private void Update()
    {
        InputKey();
        AnimationWheel();

    }

    private void FixedUpdate()
    {
        CarMove();
    }

    #region # Car Move Functions
    private void InputKey()
    {
        inputVec.z = Input.GetAxis("Vertical");
        inputVec.x = Input.GetAxis("Horizontal");
    }

    private void CarMove()
    {
        MoveX();
        MoveZ();
        Brake();
    }

    private void Brake()
    {
        foreach(var wheel in wheels)
        {
            if(Input.GetKey(KeyCode.LeftShift))
                wheel.wheelCollider.brakeTorque = brakeAcceleration;
            else
                wheel.wheelCollider.brakeTorque = 0;
        }
        
    }

    private void MoveZ()
    {
        foreach (var wheel in wheels)
        {
            wheel.wheelCollider.motorTorque = inputVec.z * maxAcceleration;
        }    
    }

    private void MoveX()
    {
        foreach (var wheel in wheels)
        {
            if (wheel.axel == Axel.Front)
                wheel.wheelCollider.steerAngle = inputVec.x * maxSteerAngle * steerSensitivity;
        }
    }

    private void AnimationWheel()
    {
        foreach(var wheel in wheels)
        {
            Vector3 pos;
            Quaternion rot;

            wheel.wheelCollider.GetWorldPose(out pos, out rot);

            wheel.wheelModel.transform.position = pos;
            wheel.wheelModel.transform.rotation = rot;
        }
    }
    #endregion
}