using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float jumpHeight = 10f;
    [SerializeField] float gravityScale = 5f;
    [SerializeField] int groundCheckRay; 
    [SerializeField] float maxSpeed = 10f;
    
    public AudioSource audioSrc;
    public bool isGronded;
    private Rigidbody2D playerRb;

    private GameManager manager;
    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        manager = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        if (manager.isPlaying)
        {
            //Mueve de forma permanente al jugador hacia la derecha
            transform.Translate(Vector2.right * (maxSpeed * Time.deltaTime));
            isGronded = Physics2D.CircleCast(playerRb.position, 2 ,Vector2.down, groundCheckRay, layerMask: 1 << 3);
        
            //Salto del jugador
            if (Input.GetKeyDown(KeyCode.Space) && isGronded || Input.GetKeyDown(KeyCode.W) && isGronded)
            {
                playerRb.gravityScale = gravityScale;
                audioSrc.Play();
            
                //Se determina que el salto siempre tendra la misma altura sacando la raiz cuadrada de la multiplicacion de la fuerza de salto 
                //por la gravedad del en Y del jugador, luego multiplicar por -2 y finalmente multiplicarlo por la masa
                float jumpForce = MathF.Sqrt(jumpHeight * (Physics2D.gravity.y * gravityScale) * -2) * playerRb.mass;
                playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }
}
