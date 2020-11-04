using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ContagionProgressController : MonoBehaviour
{

    public string InfectionFreeMessage;
    public float InfectionFreeMessageTime; // Em segundos
    public float RandomizationInterval; // Em segundos
    
    private RectTransform backgroundProgressRectTransform;
    private int currentPercentage;
    private RectTransform overlayProgressRectTransform;
    private BuffController buffController;
    private GameController gameController;
    private Text percentageContagionProgress;

    private float accDeltaRandomizationInterval;
    private float accDeltaInfectionFreeMessage;
    private bool showingMessage;
    
    void Start()
    {
        backgroundProgressRectTransform = GameObject.FindGameObjectWithTag("BackgroundContagionProgress").GetComponent<RectTransform>();
        overlayProgressRectTransform = GameObject.FindGameObjectWithTag("OverlayContagionProgress").GetComponent<RectTransform>();
        percentageContagionProgress = GameObject.FindGameObjectWithTag("PercentageContagionProgress").GetComponent<Text>();

        gameController = FindObjectOfType<GameController>();
        buffController = FindObjectOfType<BuffController>();
        accDeltaRandomizationInterval = RandomizationInterval;
        accDeltaInfectionFreeMessage = 0f;
        showingMessage = false;
    }

    void Update()
    {
        accDeltaRandomizationInterval += Time.deltaTime;
        if (accDeltaRandomizationInterval >= RandomizationInterval && !gameController.playerDie && !buffController.IsWaitingForPillAction)
        {
            accDeltaRandomizationInterval = 0f;
            currentPercentage = random(0, 100);

            var height = overlayProgressRectTransform.rect.height;
            var width = backgroundProgressRectTransform.rect.width / 100 * currentPercentage;

            overlayProgressRectTransform.sizeDelta = new Vector2(width, height);

            // var x = width / 2 - (backgroundProgressRectTransform.rect.width / 2); // Alinhado a esquerda
            // var x = 0; // Alinhado no centro
            var x = (backgroundProgressRectTransform.rect.width / 2) - width / 2; // Alinhado a direita
            var y = backgroundProgressRectTransform.localPosition[1];
            var z = backgroundProgressRectTransform.localPosition[2];
            
            overlayProgressRectTransform.localPosition = new Vector3(x, y, z);

            if (!showingMessage)
            {
                percentageContagionProgress.text = currentPercentage.ToString();
            }
        }

        if (showingMessage)
        {
            accDeltaInfectionFreeMessage += Time.deltaTime;
            if (accDeltaInfectionFreeMessage >= InfectionFreeMessageTime)
            {
                showingMessage = false;
                accDeltaInfectionFreeMessage = 0f;
                percentageContagionProgress.text = currentPercentage.ToString();
            }
        }
    }

    public bool RandomizedInfection()
    {
        var result = random(0, 100) <= this.currentPercentage;
        if (!result)
        {
            showingMessage = true;
            percentageContagionProgress.text = InfectionFreeMessage;
        }
        return result;
    }

    private int random(int lower, int higher)
    {
        return UnityEngine.Random.Range(lower, higher);
    }
    

}
