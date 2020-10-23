﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PillMedicineCollider : MonoBehaviour
{
    private CharacterController controller;
    private Text pillText;

    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
        pillText = GameObject.FindGameObjectWithTag("PillText").GetComponent<Text>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        incrementPill();         
    }

    private void incrementPill() {
        int value = int.Parse(pillText.text.ToString()) + 1;
        pillText.text = value.ToString();
    }
}
