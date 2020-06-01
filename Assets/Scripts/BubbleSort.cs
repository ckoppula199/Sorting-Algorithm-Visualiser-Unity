using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSort : SortingAlgorithm
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void StartSort()
    {
        RandomInitialisation();
        StartCoroutine(BubbleSortAlgorithm(Cubes));
    }


    IEnumerator BubbleSortAlgorithm(GameObject[] unsortedList)
    {
        GameObject temp;
        Vector3 tempPosition;

        for (int i = 0; i < unsortedList.Length - 1; i++)
        {
            yield return new WaitForSeconds(0.5f * AlgorithmDetails.Speed);
            // Last i elements are already in the correct place.
            for (int j = 0; j < unsortedList.Length - i - 1; j++)
            {
                bool last = j == unsortedList.Length - i - 2;
                // Highlight current cubes being compared as blue.
                LeanTween.color(unsortedList[j], Color.blue, 0);
                LeanTween.color(unsortedList[j + 1], Color.blue, 0);
                yield return new WaitForSeconds(0.5f * AlgorithmDetails.Speed);
                if (unsortedList[j].transform.localScale.y > unsortedList[j + 1].transform.localScale.y)
                {
                    //Colour change to red when swapping.
                    LeanTween.color(unsortedList[j], Color.red, 0);
                    LeanTween.color(unsortedList[j + 1], Color.red, 0);

                    // Swap array elements.
                    temp = unsortedList[j];
                    unsortedList[j] = unsortedList[j + 1];
                    unsortedList[j + 1] = temp;

                    tempPosition = unsortedList[j].transform.localPosition;

                    // Using LeanTween for animations, swaps the cubes
                    LeanTween.moveLocalX(unsortedList[j],
                                         unsortedList[j + 1].transform.localPosition.x,
                                         1);

                    LeanTween.moveLocalZ(unsortedList[j],
                                         -3,
                                         0.5f).setLoopPingPong(1);

                    LeanTween.moveLocalX(unsortedList[j + 1],
                                         tempPosition.x,
                                         1);

                    LeanTween.moveLocalZ(unsortedList[j + 1],
                                         3,
                                         0.5f).setLoopPingPong(1);
                    if (last)
                    {
                        // If last element being sorted, then change colour to green as it's in its correct position.
                        LeanTween.color(unsortedList[j + 1], Color.green, 1f);
                    }
                    else
                    {
                        LeanTween.color(unsortedList[j + 1], Color.white, 1f);
                    }
                    LeanTween.color(unsortedList[j], Color.white, 1f);
                    yield return new WaitForSeconds(1f);
                    continue;
                }
                LeanTween.color(unsortedList[j], Color.white, 0);
                // Deals with case of when the last element is being compared.
                if (last && i == unsortedList.Length - 2)
                {
                    LeanTween.color(unsortedList[j], Color.green, 1f);
                    LeanTween.color(unsortedList[j + 1], Color.green, 1f);
                }

                // If the last element is being sorted then change its colour to green as it's in its correct position.
                else if (last)
                {
                    LeanTween.color(unsortedList[j + 1], Color.green, 1f);
                }
                else
                {
                    LeanTween.color(unsortedList[j + 1], Color.white, 0);
                }
            }
        }
    }
}
