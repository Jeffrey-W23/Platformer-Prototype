
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{

    private float m_fSpeed = 0.0f;


    public float m_fJumpHeight;


    private float m_fDirectionDampTime = 0.25f;


    private Rigidbody m_rbRigidBody;


    private Vector2 m_v2Position;


    private Animator m_aAnimator;


    void Awake()
    {

        m_rbRigidBody = GetComponent<Rigidbody>();
        m_rbRigidBody.constraints = RigidbodyConstraints.FreezePositionY;
        m_rbRigidBody.freezeRotation = true;


        m_aAnimator = GetComponent<Animator>();


        if (m_aAnimator.layerCount >= 2)
        {

            m_aAnimator.SetLayerWeight(1,1);
        }
    }
	

	void Update()
    {

        Movement();
    }


    void Movement()
    {

        if (m_aAnimator)
        {

            m_v2Position.x = Input.GetAxis("Horizontal");
            m_v2Position.y = Input.GetAxis("Vertical");

            m_fSpeed = new Vector2(m_v2Position.x, m_v2Position.y).sqrMagnitude;

            // Set animation values.
            m_aAnimator.SetFloat("Speed", m_fSpeed);
            m_aAnimator.SetFloat("Direction", m_v2Position.x, m_fDirectionDampTime, Time.deltaTime);
        }
    }
}
