using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public SelectionSort SelectionSort;
    public SelectionSort ActiveSort;
    public InputField ArraySize;
    public Button StartButton;
    public Button ResetButton;

    public void StartSort()
    {
        int numOfItems;
        if (int.TryParse(this.ArraySize.text, out numOfItems))
        {
            if (numOfItems > 9 && numOfItems < 51)
            {
                StartButton.interactable = false;
                ResetButton.interactable = true;
                ActiveSort = Instantiate(SelectionSort);
                ActiveSort.ArraySize = numOfItems;
                ActiveSort.StartSelectionSort();

            }
        }        
    }

    public void ResetSort()
    {
        Destroy(ActiveSort.gameObject);
        StartButton.interactable = true;
        ResetButton.interactable = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        ResetButton.interactable = false;        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
