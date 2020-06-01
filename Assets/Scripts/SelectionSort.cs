using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionSort : SortingAlgorithm
{
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void StartSort()
    {
        RandomInitialisation();

        // Coroutine used to allow for waiting between steps of the algorithm for better visualisation.
        StartCoroutine(SelectionSortAlgorithm(Cubes));
    }

    
    

    /*
     * Method that carries out the selection sort algorithm. Also responsible for changes in colours and animations.
     */
    IEnumerator SelectionSortAlgorithm(GameObject[] unsortedList)
    {
        int min;
        GameObject temp;
        Vector3 tempPosition;

        for (int i = 0; i < unsortedList.Length; i++)
        {
            // Current position being evaluated set to blue colour.
            LeanTween.color(unsortedList[i], Color.blue, 0);
            min = i;
            yield return new WaitForSeconds(0.5f * AlgorithmDetails.Speed);

            for (int j = i + 1; j < unsortedList.Length; j++)
            {
                // Highlight the value thats currently being compared as cyan
                LeanTween.color(unsortedList[j], Color.cyan, 0);
                yield return new WaitForSeconds(0.1f * AlgorithmDetails.Speed);

                // New lowest value found
                if (unsortedList[j].transform.localScale.y < unsortedList[min].transform.localScale.y)
                {
                    // If value isn't the initial value that was made blue, reset it to white.
                    if (min != i) LeanTween.color(unsortedList[min], Color.white, 0);
                    min = j;
                    // Set lowest value seen sow far to red
                    LeanTween.color(unsortedList[j], Color.red, 0);
                    continue;
                }
                // Set the colour of the compared block back to white after comparison completed.
                LeanTween.color(unsortedList[j], Color.white, 0);
            }

            // Swap to be made, including animation.
            if (min != i)
            {
                // If one of the items in the swap is the block set to blue, set it back to white.
                LeanTween.color(unsortedList[i], Color.white, 1f);

                // Swap places in the array.
                temp = unsortedList[i];
                unsortedList[i] = unsortedList[min];
                unsortedList[min] = temp;

                tempPosition = unsortedList[i].transform.localPosition;

                // Using LeanTween for animations, swaps the cubes
                LeanTween.moveLocalX(unsortedList[i],
                                     unsortedList[min].transform.localPosition.x,
                                     1);

                LeanTween.moveLocalZ(unsortedList[i],
                                     -3,
                                     0.5f).setLoopPingPong(1);

                LeanTween.moveLocalX(unsortedList[min],
                                     tempPosition.x,
                                     1);

                LeanTween.moveLocalZ(unsortedList[min],
                                     3,
                                     0.5f).setLoopPingPong(1);

                LeanTween.color(unsortedList[i], Color.green, 1f);
                yield return new WaitForSeconds(1f);
                continue;
            }
            LeanTween.color(unsortedList[i], Color.green, 1f);
        }
    }
}
