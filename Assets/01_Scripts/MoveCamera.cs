using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 10f;
    private bool gameOver, active;
    private GameObject player;

    public GameManager manager;
    public AudioSource gameOverSFX;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        active = false;
    }

    void Update()
    {
        if (manager.isPlaying)
        {
            transform.Translate(Vector2.right * (maxSpeed * Time.deltaTime));
            gameOver = player.transform.position.x + 8 < transform.position.x || player.transform.position.y + 5 < transform.position.y;
        }

        if (!active)
        {
            if (gameOver)
            {
                gameOverSFX.Play();
                active = true;
                manager.isPlaying = false;
            }
        }
    }
}
