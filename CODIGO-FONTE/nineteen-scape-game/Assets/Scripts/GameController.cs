using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public float score;
    public float speedIncreaseRate;
    public float horizontalSpeedIncreaseRate;

    public List<GameObject> randomObjects = new List<GameObject>();
    public GameObject gameOver;
    public Text scoreText;
    public Text gameOverScoreText;

    private Player player;
    private float time;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        if(!player.isDead)
        {
            score += Time.deltaTime * 5f;
            scoreText.text = Mathf.Round(score).ToString() + "m";
            player.speed += speedIncreaseRate;
            player.horizontalSpeed += horizontalSpeedIncreaseRate;
            createRandomObjectInScene();
        }
    }

    public void CallGameOver()
    {
        gameOverScoreText.text = string.Format("Atingido {0}m", Mathf.Round(score));
        gameOver.SetActive(true);
    }

    private void createRandomObjectInScene()
    {
        if(time > (50f - (player.speed / 100)))
        {
            GameObject newObject = randomObjects[Random.Range(0, randomObjects.Count)];
            Instantiate(newObject, getRandomVector3(Random.Range(1, 4), newObject.transform.position.y), newObject.transform.rotation);
            time = 0f;
        }
        else
        {
            time += 1f;
        }
    }

    private Vector3 getRandomVector3(int position, float y)
    {
        float x = -5;
        float z = player.transform.position.z + 120f;

        if (position == 2) 
        {
            x = 0;
        }
        else if (position == 3) 
        {
            x = 5;
        }

        return new Vector3(x, y, z);
    }
}
