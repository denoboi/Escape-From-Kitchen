using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private NavMeshAgent agent;
    public NavMeshAgent Agent { get { return agent == null ? agent = GetComponent<NavMeshAgent>() : agent; } }

    private SwerveInputSystem swerveInputSystem;
    public SwerveInputSystem SwerveInputSystem { get { return swerveInputSystem == null ? swerveInputSystem = GetComponent<SwerveInputSystem>() : swerveInputSystem; } }

    public Transform t => transform;

    private bool isDead;
    public bool IsDead { get { return isDead; } set { isDead = value; } }
    public float TurnDuration { get; set; }

    
    public bool IsControlable = true;
    public float SwerveSpeed = 0.5f;
    public float MaxSwerveAmount = 1f;
    public float MovementSpeed = 10f;
    
    public float swerveAmount;

 
    private void Awake()
    {
        TurnDuration = 0.5f;
    }

    private void Start()
    {
        IsControlable = true;
    }

    private void Update()
    {
        Move(CalculateMovementDirection());
    }

    private Vector3 CalculateMovementDirection()
    {
        Vector3 velocity = Vector3.zero;
        velocity += transform.right * swerveAmount;
        velocity += transform.forward * 1;

        return velocity;
    }

    private void Move(Vector3 destination)
    {
        if (!IsControlable)
            return;

        swerveAmount = SwerveInputSystem.MoveFactorX * SwerveSpeed * Time.fixedDeltaTime;
        swerveAmount = Mathf.Clamp(swerveAmount, -MaxSwerveAmount, MaxSwerveAmount);

        //Agent.Move(destination * Time.deltaTime * MovementSpeed);
        transform.Translate(destination * Time.deltaTime * MovementSpeed);
    }

    public void TurningStarted()
    {

    }

    public void TurningStopped()
    {

    }
}