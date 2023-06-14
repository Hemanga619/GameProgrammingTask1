using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PaddleMovement : MonoBehaviour
{
    private Transform paddlePosition;
    private Rigidbody2D paddleBody;
    private AudioSource paddleAudio;

    // Paddle Slide
    private float paddleMovementX;
    [SerializeField] private float paddleSpeedX = 15F;

    // Start is called before the first frame update
    void Awake()
    {
        paddlePosition = GetComponent<Transform>();
        paddleBody = GetComponent<Rigidbody2D>();
        paddleAudio = GetComponent<AudioSource>();

        paddleAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        paddleBody.velocity = Vector2.zero;
        PaddleSlide();
        GameComplete();
    }

    private void PaddleSlide()
    {
        paddleMovementX = Input.GetAxisRaw("Horizontal");
        paddlePosition.position += new Vector3(paddleMovementX, 0F, 0F) * paddleSpeedX * Time.deltaTime ;
    }
    private void GameComplete()
    {
        if (BallMovement.score == 490F)
        {
            StartCoroutine(GAMECOMPLETE());
        }
    }
    IEnumerator GAMECOMPLETE()
    {
        yield return new WaitForSeconds(0.5F);
        SceneManager.LoadScene(2);
    }
}
