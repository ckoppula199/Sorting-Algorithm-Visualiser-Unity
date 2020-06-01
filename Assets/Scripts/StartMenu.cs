using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public SelectionSort SelectionSort;
    public BubbleSort BubbleSort;
    public QuickSort QuickSort;
    public SortingAlgorithm ActiveSort;
    public InputField ArraySize;
    public Button StartButton;
    public Button SlowButton;
    public Button MediumButton;
    public Button FastButton;
    public Button SelectionSortButton;
    public Button BubbleSortButton;
    public Button QuickSortButton;
    public Button Reset;
    public Text ArraySizeText;
    public Text SpeedText;
    public Text AlgorithmText;
    
    

    public void StartSort()
    {
        int numOfItems;
        if (int.TryParse(this.ArraySize.text, out numOfItems))
        {
            if (numOfItems > 9 && numOfItems < 51)
            {
                AlgorithmDetails.ArraySize = numOfItems;
                DisableMenu();
                InstantiateSort();
                ActiveSort.ArraySize = numOfItems;
                ActiveSort.StartSort();
            }
        }
    }

    public void ChooseSelectionSort()
    {
        AlgorithmDetails.Algorithm = 1;

    }

    public void ChooseBubbleSort()
    {
        AlgorithmDetails.Algorithm = 2;
    }

    public void ChooseQuickSort()
    {
        AlgorithmDetails.Algorithm = 3;
    }

    public void ChooseSlowSpeed()
    {
        AlgorithmDetails.Speed = 2.0f;
    }

    public void ChooseMediumSpeed()
    {
        AlgorithmDetails.Speed = 1.0f;
    }

    public void ChooseFastSpeed()
    {
        AlgorithmDetails.Speed = 0.5f;
    }

    /*
     * Method used to make the menu bttons and text invisible so that the sorting visualisation can be seen.
     */
    public void DisableMenu()
    {
        ArraySize.gameObject.SetActive(false);
        StartButton.gameObject.SetActive(false);
        SlowButton.gameObject.SetActive(false);
        MediumButton.gameObject.SetActive(false);
        FastButton.gameObject.SetActive(false);
        SelectionSortButton.gameObject.SetActive(false);
        QuickSortButton.gameObject.SetActive(false);
        BubbleSortButton.gameObject.SetActive(false);
        SpeedText.gameObject.SetActive(false);
        AlgorithmText.gameObject.SetActive(false);
        ArraySizeText.gameObject.SetActive(false);
        Reset.gameObject.SetActive(true);
    }

    /*
     * Method used to re-enable menu buttons and text so that a different sort or different settings can be used.
     */
    public void EnableMenu()
    {
        Destroy(ActiveSort.gameObject);
        ArraySize.gameObject.SetActive(true);
        StartButton.gameObject.SetActive(true);
        SlowButton.gameObject.SetActive(true);
        MediumButton.gameObject.SetActive(true);
        FastButton.gameObject.SetActive(true);
        SelectionSortButton.gameObject.SetActive(true);
        QuickSortButton.gameObject.SetActive(true);
        BubbleSortButton.gameObject.SetActive(true);
        SpeedText.gameObject.SetActive(true);
        AlgorithmText.gameObject.SetActive(true);
        ArraySizeText.gameObject.SetActive(true);
        Reset.gameObject.SetActive(false);
    }

    /*
     * Depending on what button the user pressed, this method instantiates the corresponding algorithm.
     */
    private void InstantiateSort()
    {
        switch(AlgorithmDetails.Algorithm)
        {
            case 1:
                ActiveSort = Instantiate(SelectionSort);
                break;
            case 2:
                ActiveSort = Instantiate(BubbleSort);
                break;
            case 3:
                ActiveSort = Instantiate(QuickSort);
                break;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        Reset.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
