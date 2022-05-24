﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : MonoBehaviour
{
    private float speed = 30.0f;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false)
        { 
            transform.Translate(Vector3.right * Time.deltaTime * speed); 
        }

        if (transform.position.x < 10 && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}