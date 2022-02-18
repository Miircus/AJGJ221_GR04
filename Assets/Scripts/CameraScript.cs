using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform m_CameraAnchor;
    public Transform m_TargetAim;
    public Transform m_SnowBall;
    public float m_CamSpeed = 10.0f;
    



    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;

    }

    private void LateUpdate()
    {

 
            m_CameraAnchor.LookAt(m_TargetAim);
            transform.position = Vector3.Lerp(transform.position, m_CameraAnchor.position, Time.deltaTime * m_CamSpeed);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, m_CameraAnchor.rotation, m_CamSpeed);
        

    }

}

