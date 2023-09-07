using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{

    float _startLife;

    private void Start()
    {
        _startLife = Time.time;
    }

    private void Update()
    {

        if (Time.time > _startLife + 2)
        {
            Destroy(gameObject);
        }



    }

}