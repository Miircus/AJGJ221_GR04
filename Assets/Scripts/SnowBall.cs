using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBall : MonoBehaviour
{
    Rigidbody m_rigidbody;
    private float m_XInput;
    private float m_YInput;

    
    public float m_XSpeed;
    private float m_currentSpeed;
    public float m_basicSpeed;
    public float m_maxSpeed;
    public float m_minSpeed;


    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_rigidbody.AddForce(300 * Vector3.up, ForceMode.Impulse);
            Debug.Log("jump");
        }

        m_rigidbody.AddForce(Physics.gravity * m_rigidbody.mass* m_rigidbody.mass);
    
}

    private void Move()
    {
        m_XInput = Input.GetAxis("Horizontal");
        m_YInput = Input.GetAxis("Vertical");

        if (m_YInput > 0)
        {
            m_currentSpeed = Mathf.Lerp(m_currentSpeed, m_maxSpeed, Time.fixedDeltaTime);


        }
        else if (m_YInput < 0)
        {
            m_currentSpeed = Mathf.Lerp(m_currentSpeed, m_minSpeed, Time.fixedDeltaTime);


        }
        else
        {
            m_currentSpeed = Mathf.Lerp(m_currentSpeed, m_basicSpeed, Time.fixedDeltaTime);

        }


        m_rigidbody.AddForce(Vector3.right * m_XInput * m_XSpeed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        m_rigidbody.AddForce(Vector3.forward * m_currentSpeed * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }
}
