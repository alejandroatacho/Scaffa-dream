using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPicture : MonoBehaviour {

    public Texture2D pic0;
    public Texture2D pic1;
    public Texture2D pic2;
    public Texture2D pic3;
    public Texture2D pic4;
    public int pick;
    AudioSource audioData;

    Texture2D[] pics;
    int old_pic;
    float timer;


    void Start()
    {

        //pack images into an array to make things easy
        pics = new Texture2D[5];

        pics[0] = pic0;
        pics[1] = pic1;
        pics[2] = pic2;
        pics[3] = pic3;
        pics[4] = pic4;

    }

    void Update()
    {

        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer = 2.5f;//<--this happens about every second;

            //get a random number not equal to current
            old_pic = pick; // Update the old pic with the last pic.

                if (pick == 5)
                {
                    audioData = GetComponent<AudioSource>();
                    audioData.Play(0);
                    Debug.Log("Makes sound");
                }
                pick = Random.Range(0, 5);
        }
    }

    void OnGUI()
    {
        //display our image
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), pics[pick]);
    }
}
