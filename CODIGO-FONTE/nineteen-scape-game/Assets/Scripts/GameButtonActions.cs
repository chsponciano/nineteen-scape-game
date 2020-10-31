using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameButtonActions : MonoBehaviour
{
    private static GameButtonActions _instance;
    public static GameButtonActions Instance { get { return _instance; } }
    
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
        
    }

    public void returnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void acceptChloroquine()
    {
        Debug.Log("accept chloroquine");
    }

    public void refuseChloroquine()
    {
        Debug.Log("refuse chloroquine");
    }
}
