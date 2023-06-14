using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour
{
    private Text scoreText;

    // Start is called before the first frame update
    void Awake()
    {
        scoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = BallMovement.score.ToString();
        // Debug.Log(scoreText.text);
    }
}
