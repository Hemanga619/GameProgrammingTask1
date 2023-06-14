using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Transform ballPosition;
    private Rigidbody2D ballBody;
    private AudioSource ballAudio;

    // Ball Motion
    [SerializeField] private float ballSpeedY = 10F;
    [SerializeField] private float ballAccelerator = 1.1F;
    [SerializeField] private float ballAccelerationTime = 5F;

    // Score System
    public static float score = 0F;
    
    // Start is called before the first frame update
    private void Awake()
    {
        ballPosition = GetComponent<Transform>();
        ballBody = GetComponent<Rigidbody2D>();
        ballAudio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        ballBody.velocity = new Vector2(0F, -ballSpeedY);

        StartCoroutine(BallAcceleration());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.CompareTag("Brick") )
        {
            ballAudio.Play();
            Destroy( collision.gameObject );
            score += 10F;
            // Debug.Log(score);
        }
    }

    IEnumerator BallAcceleration()
    {
        yield return new WaitForSeconds(ballAccelerationTime);
        ballBody.velocity *= ballAccelerator;
        // Debug.Log(ballBody.velocity);
        StartCoroutine(BallAcceleration());
    }
}
