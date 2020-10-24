using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaskCollider : MonoBehaviour
{
    private Text maskText;

    void Start()
    {
        maskText = GameObject.FindGameObjectWithTag("MaskText").GetComponent<Text>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        incrementMask();         
    }

    private void incrementMask() {
        int value = int.Parse(maskText.text.ToString()) + 1;
        maskText.text = value.ToString();
    }
}
