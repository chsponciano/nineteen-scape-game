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
        StartCoroutine(DieRotate());
        anime.SetTrigger("Death_b");
    }
    
    IEnumerator DieRotate()
    {
        for (int i = 0; i < 45; i++)
        {
          transform.position += new Vector3(-0.025f, 0f, 0f);
          transform.Rotate(0f, -1f, 0f);   
          yield return null;  
        }
    }
}
