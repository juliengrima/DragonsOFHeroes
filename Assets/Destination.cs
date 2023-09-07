using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour
{
    string _destination;
    private string destination;

    public string NextDestination { get => destination; set => _destination = value; }

    void Start()
    {
        DontDestroyOnLoad(this);
    }
}
