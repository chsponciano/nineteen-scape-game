﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasMainMenuControl : MonoBehaviour
{
    public GameObject CanvasMainMenu;
    public GameObject CanvasInformation;
    public GameObject CanvasUsername;
    public GameObject CanvasRanking;
    public CloudScore cloudScore;
    public InputField UsernameInput;
    public List<Text> RankList;
    public Animator animator;

    void Start()
    {
        if (string.IsNullOrWhiteSpace(CloudScore.Username))
        {
            CanvasUsername.SetActive(true);
            CanvasMainMenu.SetActive(false);
        }
        else
        {
            CanvasUsername.SetActive(false);
            CanvasMainMenu.SetActive(true);
        }
        CanvasInformation.SetActive(false);
        CanvasRanking.SetActive(false);
        
        UsernameInput.text = CloudScore.Username;

        populateRankList();

    }

    public void PlayButton()
    {
        animator.SetTrigger("game");
        // SceneManager.LoadScene("GameScene");
    }

    public void InformationButton()
    {
        CanvasMainMenu.SetActive(false);
        CanvasUsername.SetActive(false);
        CanvasInformation.SetActive(true);
        CanvasRanking.SetActive(false);
    }

    public void RankingButton()
    {
        CanvasMainMenu.SetActive(false);
        CanvasUsername.SetActive(false);
        CanvasInformation.SetActive(false);
        CanvasRanking.SetActive(true);
    }

    public void BackButton()
    {
        CanvasMainMenu.SetActive(true);
        CanvasUsername.SetActive(false);
        CanvasInformation.SetActive(false);
        CanvasRanking.SetActive(false);
    }

    public void SaveButton()
    {
        CloudScore.Username = UsernameInput.text;
        CanvasMainMenu.SetActive(true);
        CanvasUsername.SetActive(false);
        CanvasInformation.SetActive(false);
        CanvasRanking.SetActive(false);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    private void populateRankList()
    {
        cloudScore.GetRanking(ranking => {
            for (var i = 0; i < ranking.Count; i++)
            {
                var score = ranking[i];
                var text = RankList[i];

                text.text = "0" + (i + 1) + " - " + score.username + " - " + score.score;
            }
            for (var i = ranking.Count; i < RankList.Count; i++)
            {
                RankList[i].text = "";
            }
        });
    }

}
