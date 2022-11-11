using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Comparers;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public bool onGround;
    public Text scoreText;

    private Rigidbody rb;
    private int score;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        onGround = true;
        score = 0;
        SetScoreText();
    }

    void FixedUpdate ()
    {
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);

            rb.AddForce(movement);

            rb.AddForce(movement * speed);
        }

        if (onGround)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = new Vector3(0f, 5f, 0f);
                onGround = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            score = score + 1;
            SetScoreText();
        }
        if (other.gameObject.CompareTag("Obstacle"))
        {
            other.gameObject.SetActive(true);
            score = score - 1;
            SetScoreText();
        }
    }


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }

    void SetScoreText ()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}

