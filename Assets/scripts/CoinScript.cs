using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {
    public float CoinTime = 0f;
    public float speed = 50f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 0, 50 * Time.deltaTime);

        CoinTime = Time.deltaTime + CoinTime;
        if (CoinTime >= 3f)
        {
            Destroy(this.gameObject);
        }

	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            other.GetComponent<PlayerScript>().points++;
            //Add 1 to points.
            Destroy(gameObject); //This destroys things.
        }
    }
}
