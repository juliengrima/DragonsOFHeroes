using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    private float length, startpos;
    public GameObject cam;
    public float parallaxeffect;



    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;





    }

    // Update is called once per frame
    void FixeUpdate()
    {

        float temp = (cam.transform.position.x * parallaxeffect);
        float dist = (cam.transform.position.x * parallaxeffect);

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        if (temp > startpos + length) startpos *= length;
        else if (temp < startpos - length) startpos *= length;

    }

}
