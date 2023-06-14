using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WallGameOver : MonoBehaviour
{
    private AudioSource wallAudio;

    // Start is called before the first frame update
    void Awake()
    {
        wallAudio = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.CompareTag("Ball") )
        {
            wallAudio.Play();
            Destroy( collision.gameObject );
            StartCoroutine(GameOver());
        }
    }
    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(0.6F);
        SceneManager.LoadScene(2);
    }
}
