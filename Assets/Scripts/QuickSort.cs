using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickSort : SortingAlgorithm
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
        StartCoroutine(QuickSortAlgorithm(Cubes, 0, Cubes.Length - 1));

    }

    IEnumerator QuickSortAlgorithm(GameObject[] unsortedList, int low, int high)
    {
        if (low < high)
        {
            int pi;
            GameObject temp;
            GameObject pivot = unsortedList[high];
            int i = low - 1;

            for (int j = low; j <= high - 1; j++)
            {
                LeanTween.color(unsortedList[j], Color.red, 0);
                yield return new WaitForSeconds(0.5f);
                LeanTween.color(unsortedList[j], Color.white, 0);
                if (unsortedList[j].transform.localScale.y <= pivot.transform.localScale.y)
                {
                    i++;
                    LeanTween.color(unsortedList[j], Color.blue, 0);
                    LeanTween.color(unsortedList[i], Color.blue, 0);
                    temp = unsortedList[i];
                    unsortedList[i] = unsortedList[j];
                    unsortedList[j] = temp;

                    Vector3 tempPosition = unsortedList[i].transform.localPosition;

                    LeanTween.moveLocalX(unsortedList[i],
                                     unsortedList[j].transform.localPosition.x,
                                     1);

                    LeanTween.moveLocalZ(unsortedList[i],
                                         -3,
                                         0.5f).setLoopPingPong(1);

                    LeanTween.moveLocalX(unsortedList[j],
                                         tempPosition.x,
                                         1);

                    LeanTween.moveLocalZ(unsortedList[j],
                                         3,
                                         0.5f).setLoopPingPong(1);

                    LeanTween.color(unsortedList[j], Color.white, 1);
                    LeanTween.color(unsortedList[i], Color.white, 1);
                    yield return new WaitForSeconds(1);
                }
            }

            temp = unsortedList[i + 1];
            unsortedList[i + 1] = unsortedList[high];
            unsortedList[high] = temp;

            Vector3 tempPosition2 = unsortedList[i + 1].transform.localPosition;

            LeanTween.moveLocalX(unsortedList[i + 1],
                             unsortedList[high].transform.localPosition.x,
                             1);

            LeanTween.moveLocalZ(unsortedList[i + 1],
                                 -3,
                                 0.5f).setLoopPingPong(1);

            LeanTween.moveLocalX(unsortedList[high],
                                 tempPosition2.x,
                                 1);

            LeanTween.moveLocalZ(unsortedList[high],
                                 3,
                                 0.5f).setLoopPingPong(1);

            yield return new WaitForSeconds(1);

            pi = i + 1;

            QuickSortAlgorithm(unsortedList, low, pi - 1);
            QuickSortAlgorithm(unsortedList, pi + 1, high);

        }
    }
}
