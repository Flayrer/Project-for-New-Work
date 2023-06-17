using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject[] persons;

    public TextMeshProUGUI initializeNumberText;
    public TextMeshProUGUI[] nameIngredients;
    public TextMeshProUGUI[] BorderAccept;
    public CanvasGroup initializeNumberTextAlpha;
    public CanvasGroup screen;
    public CanvasGroup[] menu;

    public RectTransform menuIngredients;

    public float initializeNumber;
    public bool initializeGame;
    public bool[] buttonBool;

    // Start is called before the first frame update
    void Start()
    {
        initializeNumber = 6f;

        for (int i = 0; i < persons.Length; i++)
        {
            persons[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (initializeGame)
        {
            Timer();
        }
    }

    void Timer()
    {
        initializeNumberTextAlpha.alpha = 1f;
        initializeNumber -= Time.deltaTime;

        if (initializeNumber <= 6f)
        {
            initializeNumberText.text = $"{(int)initializeNumber}";
        }

        if (initializeNumber <= 1)
        {
            initializeNumberText.text = $"Go!";
        }

        if (initializeNumber <= 0)
        {
            initializeNumber = 0;

            StartGame();
        }
    }

    void StartGame()
    {
        for (int i = 0; i < persons.Length; i++)
        {
            persons[i].SetActive(true);
        }

        LeanTween.alphaCanvas(initializeNumberTextAlpha, 0, 0.5f);
        LeanTween.alphaCanvas(screen, 0, 1f);

        LeanTween.move(menuIngredients, new Vector2(0, 75f), 1f);
    }

    public void ButtonPlay()
    {
        initializeGame = true;

        for (int i = 0; i < menu.Length; i++)
        {
            LeanTween.alphaCanvas(menu[i], 0, 0.5f);
            menu[i].blocksRaycasts = false;
            menu[i].interactable = false;
        }
    }

    public void ButtonInteraction(int numberSelection)
    {
        

        for (int i = 0; i < 3; i++)
        {
            buttonBool[numberSelection] = !buttonBool[numberSelection];
        }

        if (buttonBool[numberSelection])
        {
            BorderAccept[numberSelection].text = "x";
        }
        else
        {
            BorderAccept[numberSelection].text = "";
        }

        switch (numberSelection)
        {
            case 0:
                break;

            case 1:
                break;

            case 2:
                break;

            case 3:
                break;

            case 4:
                break;
        }
    }
}
