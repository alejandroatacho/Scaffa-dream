using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour {

    public float destroyTime = 3.0f;

    // Use this for initialization
    void Start ()
    {
        if(gameObject != null)
        {
            Destroy(gameObject, destroyTime);
        }
        
	}
	
}
