using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private AudioSource playerAudio;
    public float horizontalInput;
    public float speed = 10.0f;
    public float xRange = 5.0f;
    public ParticleSystem explosionParticle;
    public ParticleSystem exhuastParticle;
    public AudioClip crashSound;

    public TextMeshProUGUI titleText;
    public TextMeshProUGUI gameOverText;


    public bool gameOver;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
        gameOverText.gameObject.SetActive(false);
        titleText.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //Sets player boundary 
        if (gameOver)
            return;

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

  
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");


            explosionParticle.Play();
        
            gameOverText.gameObject.SetActive(true);
            //playerAudio.PlayOneShot(crashSound, 1.0f);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Start"))
        {
            Debug.Log("Go!");
            titleText.gameObject.SetActive(false);
        }
    }

}