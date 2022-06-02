using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private AudioSource playerAudio;
    public float horizontalInput;
    public float speed = 10.0f;
    public float xRange = 5.0f;
    public ParticleSystem exsplosionParicle;
    public ParticleSystem dirtParticle;
    public AudioClip crashSound;

    public bool gameOver;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
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


            exsplosionParicle.Play();
            dirtParticle.Stop();
            //playerAudio.PlayOneShot(crashSound, 1.0f);
        }
        else if (!collision.gameObject.CompareTag("Obstacle")) ;
        {
            dirtParticle.Play();
        }
    }
}