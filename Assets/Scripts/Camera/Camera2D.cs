using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2D : MonoBehaviour
{
    [Header("Horizontal")]  //the heading displayed in your editor
    [SerializeField] private PlayerMotor m_PlayerToFollow;
    [SerializeField] private bool m_HorizontalFollow = true;
    [SerializeField] private bool m_VerticalFollow = true;

    [Header("Horizontal")]
    [SerializeField][Range(0f, 1f)] private float m_HorizontalInfluence = 1f;   
    [SerializeField] private float m_HorizontalOffset = 0f; //offset is the camera focus boundary (the square boundary of camera one)
    [SerializeField] private float m_HorizontalSmoothness = 3f; //smootheness means how fast camera moves (or can say follow target)

    [Header("Vertical")]
    [SerializeField][Range(0, 1)] private float m_VerticalInfluence = 1f;
    [SerializeField] private float m_VerticalOffset = 0f;
    [SerializeField] private float m_VerticalSmoothness = 3f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            CenterOnTarget(m_PlayerToFollow);
        }
    }

    private Vector3 GetTargetPosition(PlayerMotor player)
    {
        float xPos = 0f;
        float yPos = 0f;

        xPos += (player.transform.position.x + m_HorizontalOffset) * m_HorizontalInfluence;
        yPos += (player.transform.position.y + m_VerticalOffset) * m_VerticalInfluence;
        
        Vector3 positionTarget = new Vector3(xPos, yPos, transform.position.z);
        return positionTarget;
    }

    private void CenterOnTarget(PlayerMotor player)
    {
        Vector3 targetPosition = GetTargetPosition(player);
        transform.localPosition = targetPosition;
    }
}
