using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BuffController : MonoBehaviour
{
    class Buff
    {
        private int value = 1;

        public int Increment() 
        {
            return this.value++;
        }

        public int Decrement() 
        {
            return this.value--;
        }
    }
    
    public enum E_BUFF {Pill, Mask};
    private Dictionary<string, Buff> buffDictionary = new Dictionary<string, Buff>();

    private static BuffController _instance;
    public static BuffController Instance { get { return _instance; } }

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
        this.StartValuesBuffs();
    }

    public void Increment(Text ui, E_BUFF type, GameObject buffObject)
    {        
        this.PrintValue(ui, this.buffDictionary[type.ToString()].Increment());
        Destroy(buffObject);
    }

    public void Decrement(Text ui, E_BUFF type)
    {
        this.PrintValue(ui, this.buffDictionary[type.ToString()].Decrement());
    }

    private void PrintValue(Text ui, int value)
    {
        ui.text = value.ToString();
    }

    private void StartValuesBuffs()
    {
        foreach(E_BUFF buff in Enum.GetValues(typeof(E_BUFF)))
        {
            this.buffDictionary.Add(buff.ToString(), new Buff());
        }   
    }
}
