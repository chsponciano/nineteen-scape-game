using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameController : MonoBehaviour
{
    public float score;
    public float speedIncreaseRate;
    public float horizontalSpeedIncreaseRate;

    public List<GameObject> randomObjects = new List<GameObject>();
    public List<int> randomObjectsProbabilities = new List<int>();
    public GameObject gameOver;
    public Text scoreText;
    public Text gameOverScoreText;
    public bool playerDie = false;
    public bool isStopped = false;

    private Player player;
    private float time;

    private static GameController _instance;
    public static GameController Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } 
        else 
        {
            _instance = this;
        }
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        validateRandomObjectsProbabilities();
    }

    void Update()
    {
        if(!playerDie)
        {
            score += Time.deltaTime * 5f;
            scoreText.text = Mathf.Round(score).ToString() + "m";
            player.speed += speedIncreaseRate;
            player.horizontalSpeed += horizontalSpeedIncreaseRate;
            createRandomObjectInScene();
        } 
        else 
        {
            isStopped = true;
        }
    }

    public void CallGameOver()
    {
        gameOverScoreText.text = string.Format("Atingido {0}m", Mathf.Round(score));
        gameOver.SetActive(true);
    }

    private void createRandomObjectInScene()
    {
        if(time > 10)
        {
            GameObject newObject = getRandomObject();
            Instantiate(newObject, getRandomVector3(Random.Range(1, 4), newObject.transform.position.y), newObject.transform.rotation);
            time = 0f;
        }
        else
        {
            time += Time.deltaTime * 3f + (player.speed / 100);
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

    private GameObject getRandomObject()
    {
        int random = Random.Range(0, 100);
        int accumulator = 0;
        for (int i = 0; i < this.randomObjects.Count; i++)
        {
            int probability = this.randomObjectsProbabilities[i];
            GameObject gameObject = this.randomObjects[i];
            
            accumulator += probability;
            if (random < accumulator)
            {
                return gameObject;
            }
        }
        throw new System.ArgumentException("Cannot pick random object");
    }

    private void validateRandomObjectsProbabilities()
    {
        if (this.randomObjectsProbabilities.Count != this.randomObjects.Count) 
        {
            throw new System.ArgumentException("Random Objects Probabilities should have the same number of elements as Random Object");
        }
        if (this.randomObjectsProbabilities.Sum() != 100)
        {
            throw new System.ArgumentException("Random Objects Probabilities should have sum equal to 100");
        }
    }
}
