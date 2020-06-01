using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingAlgorithm : MonoBehaviour
{

    public int ArraySize = 10;
    public int MaxHeight = 20;
    public GameObject[] Cubes;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void StartSort()
    {

    }

    /*
     * Method is resonsible for the creation of set number of cubes of random sizes.
     */
    public void RandomInitialisation()
    {
        Cubes = new GameObject[ArraySize];

        for (int i = 0; i < ArraySize; i++)
        {

            int randomHeight = Random.Range(1, MaxHeight + 1);

            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            // Cube given a random Y value to simulate random height, 0.9f used for x value so cubes don't touch each other.
            cube.transform.localScale = new Vector3(0.9f, randomHeight, 1);
            // Ensures all cubes are alligned at the bottom.
            cube.transform.position = new Vector3(i, randomHeight / 2.0f, 0);

            cube.transform.parent = this.transform;
            Cubes[i] = cube;
        }

        // Places cube in specific position so that they don't overlap.
        float z = 10f;

        // Chooses appropriate z value given number of items being sorted so that all cubes can be seen on the screen.
        if (ArraySize > 30) z = ArraySize / 3.0f;
        transform.position = new Vector3(-ArraySize / 2.0f, -MaxHeight / 2.0f, z);
    }
}
