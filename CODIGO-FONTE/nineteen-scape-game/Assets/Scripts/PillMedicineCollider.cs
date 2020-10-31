using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PillMedicineCollider : MonoBehaviour
{
    private Text pillText;
    private BuffController buffController;

    void Start()
    {
        this.pillText = GameObject.FindGameObjectWithTag("PillText").GetComponent<Text>();
        this.buffController = FindObjectOfType<BuffController>();
    }

    private void OnTriggerEnter(Collider other)
    {
       this.buffController.Increment(pillText, BuffController.E_BUFF.Pill, gameObject);
    }
}
