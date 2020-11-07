using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public Animator anime;
    private GameController gameController;
    private Player player;
    private bool isMoving;

    void Start()
    {
        this.normalize();
        this.transform.Rotate(0f, 180f, 0f);
        this.gameController = FindObjectOfType<GameController>();
        this.player = FindObjectOfType<Player>();
    }

    void Update()
    {
        if (!this.gameController.playerDie && !this.gameController.isStopped)
        {
            this.anime.ResetTrigger("Stop_b");
            this.transform.position += new Vector3(0f, 0f, -0.2f);
            
            if (Mathf.Round(this.transform.position.z - this.player.transform.position.z) % 50 == 0)
            {
                this.getRandomX(Random.Range(0, 2));
            }
        }
        else
        {
            this.anime.SetTrigger("Stop_b");
        }
    }

    private void normalize()
    {
        float x = this.transform.position.x;
        float currentX;

        if (x < -3f)
        {
            currentX = -5f;
        }
        else if (x > 3f)
        {
            currentX = 5f;
        }
        else
        {
            currentX = 0f;
        }

        this.transform.position = new Vector3(currentX, this.transform.position.y, this.transform.position.z);
    }

    private void getRandomX(int position)
    {
        UnityEngine.Debug.Log(position);

        if (!isMoving)
        {
            if (position == 0)
            {
                StartCoroutine(LeftMove());
            }
            else if (position == 1)
            {
                StartCoroutine(RightMove());
            }
        }

    }

    IEnumerator LeftMove()
    {
        isMoving = true;
        float x = this.transform.position.x;

        if (x > -5)
        {
            while (this.transform.position.x >= x - 5f)
            {
                this.transform.position += new Vector3(-0.1f, 0f, 0f);
                yield return null;
            }
        }
        isMoving = false;
        this.normalize();
    }

    IEnumerator RightMove()
    {
        isMoving = true;
        float x = this.transform.position.x;

        if (x < 5)
        {
            while (this.transform.position.x <= x + 5f)
            {
                this.transform.position += new Vector3(0.1f, 0f, 0f);
                yield return null;
            }
        }
        isMoving = false;
        this.normalize();
    }
}
