using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupAndBall : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Ball,Cup1;

    void Start()
    {
        Cup1.transform.position = Ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Cup1.transform.position = Ball.transform.position;
        //Debug.Log(Cup1.transform.position);
    }

      
}
