using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float maxHitPoints = 100f;
    [SerializeField] private int dashSpeed = 10;
    [SerializeField] private float dashTime = 0.1f;
    [SerializeField] private float dashCooldown = 2f;
    public Image Bar;
    
    private float currentHitPoints;
    private float _initialMovementSpeed;


    private Rigidbody2D rb;


    private float minMovingSpeed = 0.1f;
    private bool isRunning = false;
    private bool canDash = true;
    private void Awake()
    {
        currentHitPoints = maxHitPoints;
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
        _initialMovementSpeed = movementSpeed;
        GameInput.Instance.OnPlayerDash += GameInput_OnPlayerDash;
    }
    private void GameInput_OnPlayerDash(object sender, System.EventArgs e)
    {
        if (canDash)
        {
            Dash();
        }
    }

    private void Dash()
    {
        StartCoroutine(DashRoutine());
    }


    private IEnumerator DashRoutine()
    {
        canDash = false;
        movementSpeed *= dashSpeed;
        yield return new WaitForSeconds(dashTime);
        movementSpeed = _initialMovementSpeed;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
    public void TakeDamage(float damage)
    {
        currentHitPoints -= damage;
    }
    public void TakeHeal(float heal)
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