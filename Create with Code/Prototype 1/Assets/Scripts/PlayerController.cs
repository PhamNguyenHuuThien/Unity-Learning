using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float rpm;
    [SerializeField] private float horsePower = 0;
    [SerializeField] float turnSpeed = 30.0f;
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody playerRb;

    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI rpmText;

    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Get player input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        if (IsOnGround())
        {
            // Move the vehicle forward
            //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
            playerRb.AddRelativeForce(Vector3.forward * horsePower * forwardInput);

            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

            speed = playerRb.velocity.magnitude * 3.6f;
            speedometerText.text = "Speed: " + Mathf.Round(speed) + " km/h";

            //print RPM
            rpm = Mathf.Round((speed % 30) * 40);
            rpmText.SetText("RPM: " + rpm);
        }
    }

    bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }

        if(wheelsOnGround == 4)
        {
            return true;
        }
        return false;
    }
}