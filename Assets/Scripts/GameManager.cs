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
    public CanvasGroup initializeNumberTextAlpha;
    public CanvasGroup screen;
    public CanvasGroup[] menu;

    public float initializeNumber;
    public bool initializeGame;

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

            for (int i = 0; i < persons.Length; i++)
            {
                persons[i].SetActive(true);
            }

            LeanTween.alphaCanvas(initializeNumberTextAlpha,0,0.5f);
            LeanTween.alphaCanvas(screen, 0, 1f);
        }
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
}
