using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjects : MonoBehaviour
{
    private Player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        float distance = player.transform.position.z - transform.position.z;
        if (distance >= 100f) 
        {
            Destroy(gameObject);
        } 
    }
}
