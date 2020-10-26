using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adversaries : MonoBehaviour
{
    public Animator anime;
    private GameController gameController;

    void Start()
    {
        transform.Rotate(0f, 180f, 0f);
        transform.position += new Vector3(0f, 0.3f, 0f);
        gameController = FindObjectOfType<GameController>();
    }

    void Update()
    {
        if (!gameController.playerDie) 
        {
            transform.position += new Vector3(0f, 0f, -0.2f);
        }
    }

    public void die()
    {
        anime.SetTrigger("Death_b");
    }
}
