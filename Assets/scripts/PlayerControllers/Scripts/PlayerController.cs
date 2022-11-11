using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed = 18;

    private Rigidbody rig;

    // Use this for initialization
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);

            rig.AddForce(movement);

            rig.AddForce(movement * speed);
        }
    }
}