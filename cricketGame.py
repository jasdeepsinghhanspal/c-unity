using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CricketGame : MonoBehaviour
{
    public Transform player;
    public Transform ball;
    public float playerSpeed = 5f;
    public float ballSpeed = 10f;
    public Transform target;

    private bool isBowling = false;
    private Vector3 initialBallPosition;

    private void Start()
    {
        initialBallPosition = ball.position;
    }

    private void Update()
    {
        if (isBowling)
        {
            Vector3 direction = (target.position - ball.position).normalized;
            ball.Translate(direction * ballSpeed * Time.deltaTime);
        }
        else
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0);
            player.Translate(moveDirection * playerSpeed * Time.deltaTime);
            if (Input.GetMouseButtonDown(0))
            {
                Bowl();
            }
        }
    }

    private void Bowl()
    {
        isBowling = true;
        ball.position = initialBallPosition;
        target.position = new Vector3(Random.Range(-5f, 5f), 0, 0);
    }
}
