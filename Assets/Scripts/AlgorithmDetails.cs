using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlgorithmDetails : MonoBehaviour
{

    private static float speed = 1.0f;
    private static int algorithm = 1;
    private static int arraySize = 10;

    public static int Algorithm
    {
        get
        {
            return algorithm;
        }

        set
        {
            algorithm = value;
        }
    }
    public static float Speed
    {
        get
        {
            return speed;
        }

        set
        {
            speed = value;
        }
    }
    public static int ArraySize
    {
        get
        {
            return arraySize;
        }

        set
        {
            arraySize = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
