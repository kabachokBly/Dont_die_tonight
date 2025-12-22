using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private int maxHitPoints = 100;
    private int currentHitPoints;


    private Rigidbody2D rb;


    private float minMovingSpeed = 0.1f;
    private bool isRunning = false;
    private void Awake()
    {
        currentHitPoints = maxHitPoints;
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage)
    {
        currentHitPoints -= damage;
    }
    public void TakeHeal(int heal)
    {
        if(currentHitPoints + heal > maxHitPoints)
        {
            currentHitPoints = maxHitPoints;
        }
        else
        {
            currentHitPoints += heal;
        }
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }
    private void HandleMovement()
    {
        Vector2 inputVector = GameInput.Instance.GetMovementVector();
        inputVector = inputVector.normalized;
        rb.MovePosition(rb.position + inputVector * (movementSpeed * Time.fixedDeltaTime));

        if (Mathf.Abs(inputVector.x) > minMovingSpeed || Mathf.Abs(inputVector.y) > minMovingSpeed)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
    }
    public bool IsRunning()
    {
        return isRunning;
    }
    public Vector2 GetPlayerScreenPosition()
    {
        Vector2 playerScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
        return playerScreenPosition;
    }
}