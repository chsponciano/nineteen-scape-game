using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaskCollider : MonoBehaviour
{
    private Text maskText;
    private BuffController buffController;

    void Start()
    {
        this.maskText = GameObject.FindGameObjectWithTag("MaskText").GetComponent<Text>();
        this.buffController = FindObjectOfType<BuffController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        this.buffController.Increment(maskText, BuffController.E_BUFF.Mask, gameObject);     
    }
}
