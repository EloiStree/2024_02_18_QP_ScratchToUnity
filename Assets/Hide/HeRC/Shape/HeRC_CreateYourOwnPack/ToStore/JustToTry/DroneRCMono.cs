using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneRCMono : MonoBehaviour
{

    public Transform m_whatToMove;
    public float m_timepast;
    public float m_droneSpeedPerSecond = 0.3f;
    public float m_rotationPerSecondAsAngle = 180f;


    public bool m_makeDroneRotateRight;
    public bool m_makeDroneRotateLeft;
    public bool m_makeDroneMoveRight;
    public bool m_makeDroneMoveLeft;
    public bool m_makeDroneMoveUp;
    public bool m_makeDroneMoveDown;
    public bool m_makeDroneMoveForward;
    public bool m_makeDroneMoveBackward;

    void Start()
    {
        Debug.Log("Bonjour");
    }

    void Update()
    {
        float timePast = Time.deltaTime;
        m_timepast = timePast;
        Vector3 whereIsTheCar = m_whatToMove.position;
        Vector3 carForward = m_whatToMove.forward;
        Vector3 carUp = m_whatToMove.up;
        Vector3 carRight = m_whatToMove.right;

        if (m_makeDroneMoveBackward)
        {
            whereIsTheCar = whereIsTheCar - (carForward * timePast * m_droneSpeedPerSecond);
        }
        if (m_makeDroneMoveForward)
        {
            whereIsTheCar = whereIsTheCar + (carForward * timePast * m_droneSpeedPerSecond);
        }
       
        if (m_makeDroneMoveLeft)
        {
            whereIsTheCar = whereIsTheCar - (carRight * timePast * m_droneSpeedPerSecond);
        }
        if (m_makeDroneMoveRight)
        {
            whereIsTheCar = whereIsTheCar + (carRight * timePast * m_droneSpeedPerSecond);
        }
        if (m_makeDroneMoveDown)
        {
            whereIsTheCar = whereIsTheCar - (carUp * timePast * m_droneSpeedPerSecond);
        }
        if (m_makeDroneMoveUp)
        {
            whereIsTheCar = whereIsTheCar + (carUp * timePast * m_droneSpeedPerSecond);
        }
        m_whatToMove.position = whereIsTheCar;

      
        Vector3 angleToRotate = new Vector3(0 ,  -m_rotationPerSecondAsAngle * timePast, 0);
        if (m_makeDroneRotateLeft)
        {
            m_whatToMove.Rotate(angleToRotate, Space.Self);
        }
        if (m_makeDroneRotateRight)
        {
            m_whatToMove.Rotate(-angleToRotate, Space.Self);
        }

    }

    public void ResetToNotMoving()
    {
        m_makeDroneRotateRight = false;
        m_makeDroneRotateLeft = false;
        m_makeDroneMoveBackward = false;
        m_makeDroneMoveForward = false;
        m_makeDroneMoveUp = false;
        m_makeDroneMoveDown= false;
        m_makeDroneMoveLeft = false;
        m_makeDroneMoveRight= false;
    }

    public void SetDroneMoveForward(bool stateOfTheButtonIsOn)
    {

        m_makeDroneMoveForward = stateOfTheButtonIsOn;
    }
    public void SetDroneMoveBackward(bool stateOfTheButtonIsOn)
    {
        m_makeDroneMoveBackward = stateOfTheButtonIsOn;
    }

    public void SetDroneMoveLeft(bool stateOfTheButtonIsOn)
    {

        m_makeDroneMoveLeft = stateOfTheButtonIsOn;
    }
    public void SetDroneMoveRight(bool stateOfTheButtonIsOn)
    {
        m_makeDroneMoveRight = stateOfTheButtonIsOn;
    }

    public void SetDroneMoveUp(bool stateOfTheButtonIsOn)
    {

        m_makeDroneMoveUp = stateOfTheButtonIsOn;
    }
    public void SetDroneMoveDown(bool stateOfTheButtonIsOn)
    {
        m_makeDroneMoveDown = stateOfTheButtonIsOn;
    }
    public void SetDroneRotationLeft(bool stateOfTheButtonIsOn) { 
        m_makeDroneRotateLeft= stateOfTheButtonIsOn;
    }
    public void SetDroneRotationRight(bool stateOfTheButtonIsOn) {
        m_makeDroneRotateRight= stateOfTheButtonIsOn; 
    }






}
