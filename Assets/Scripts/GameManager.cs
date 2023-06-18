using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject[] persons;
    public Sandwiches[] sandwiches;

    public TextMeshProUGUI initializeNumberText;
    public TextMeshProUGUI[] nameIngredients;
    public TextMeshProUGUI[] BorderAccept;
    public TextMeshProUGUI nameSandwich;
    public TextMeshProUGUI timerGameText;
    public TextMeshProUGUI moneyText;
    public CanvasGroup initializeNumberTextAlpha;
    public CanvasGroup screen;
    public CanvasGroup[] menu;
    public GameObject moneyObject;
    public RectTransform menuIngredients;
    public RectTransform menuInformations;
    public GameObject buttonInformations;
    public Image iconSandwiches;
    public Button buttonSandwiches;

    public float initializeNumber;
    public float timerGame;
    public bool initializeGame;
    public bool[] buttonBool;
    public int money;

    public int id;

    // Start is called before the first frame update
    void Start()
    {
        timerGameText.gameObject.SetActive(false);
        moneyObject.SetActive(false);
        buttonInformations.SetActive(false);
        timerGame = 120f;
        initializeNumber = 6f;
        money = 0;

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

        if (money <= 0)
        {
            money = 0;
            moneyText.text = $": {money}";
        }
    }

    void StartGame()
    {
        timerGameText.gameObject.SetActive(true);
        moneyObject.SetActive(true);
        buttonInformations.SetActive(true);
        timerGame -= Time.deltaTime;
        timerGameText.text = $"{(int)timerGame}";

        if (timerGame <= 0)
        {
            timerGame = 0;
        }

        Persons();

        LeanTween.alphaCanvas(initializeNumberTextAlpha, 0, 0.5f);
        LeanTween.alphaCanvas(screen, 0, 1f);

        LeanTween.move(menuIngredients, new Vector2(0, 75f), 1f);
    }

    void Persons()
    {
        for (int i = 0; i < persons.Length; i++)
        {
            persons[i].SetActive(true);
        }
    }

    void Conditions()
    {
        if (buttonBool[0] == true && buttonBool[1] == true && buttonBool[2] == true)
        {
            id = 0;
            buttonBool[3] = false;
            buttonBool[4] = false;
            BorderAccept[3].text = "";
            BorderAccept[4].text = "";
            nameIngredients[0].text = $"1- {sandwiches[0].ingredients[0].ToString()}";
            nameIngredients[1].text = $"2- {sandwiches[0].ingredients[1].ToString()}";
            nameIngredients[2].text = $"3- {sandwiches[0].ingredients[2].ToString()}";
            nameSandwich.text = sandwiches[0].nameSandwich;
            iconSandwiches.sprite = sandwiches[0].icon;
            buttonSandwiches.interactable = true;
        }
        else if (buttonBool[0] == true && buttonBool[1] == true && buttonBool[3] == true)
        {
            id = 1;
            buttonBool[2] = false;
            buttonBool[4] = false;
            BorderAccept[2].text = "";
            BorderAccept[4].text = "";
            nameIngredients[0].text = $"1- {sandwiches[1].ingredients[0].ToString()}";
            nameIngredients[1].text = $"2- {sandwiches[1].ingredients[1].ToString()}";
            nameIngredients[2].text = $"3- {sandwiches[1].ingredients[2].ToString()}";
            nameSandwich.text = sandwiches[1].nameSandwich;
            iconSandwiches.sprite = sandwiches[1].icon;
            buttonSandwiches.interactable = true;
        }
        else if (buttonBool[0] == true && buttonBool[1] == true && buttonBool[4] == true)
        {
            id = 2;
            buttonBool[2] = false;
            buttonBool[3] = false;
            BorderAccept[2].text = "";
            BorderAccept[3].text = "";
            nameIngredients[0].text = $"1- {sandwiches[2].ingredients[0].ToString()}";
            nameIngredients[1].text = $"2- {sandwiches[2].ingredients[1].ToString()}";
            nameIngredients[2].text = $"3- {sandwiches[2].ingredients[2].ToString()}";
            nameSandwich.text = sandwiches[2].nameSandwich;
            iconSandwiches.sprite = sandwiches[2].icon;
            buttonSandwiches.interactable = true;
        }
        else if (buttonBool[0] == true && buttonBool[2] == true && buttonBool[3] == true)
        {
            id = 3;
            buttonBool[1] = false;
            buttonBool[4] = false;
            BorderAccept[1].text = "";
            BorderAccept[4].text = "";
            nameIngredients[0].text = $"1- {sandwiches[3].ingredients[0].ToString()}";
            nameIngredients[1].text = $"2- {sandwiches[3].ingredients[1].ToString()}";
            nameIngredients[2].text = $"3- {sandwiches[3].ingredients[2].ToString()}";
            nameSandwich.text = sandwiches[3].nameSandwich;
            iconSandwiches.sprite = sandwiches[3].icon;
            buttonSandwiches.interactable = true;
        }
        else if (buttonBool[0] == true && buttonBool[2] == true && buttonBool[4] == true)
        {
            id = 4;
            buttonBool[1] = false;
            buttonBool[3] = false;
            BorderAccept[1].text = "";
            BorderAccept[3].text = "";
            nameIngredients[0].text = $"1- {sandwiches[4].ingredients[0].ToString()}";
            nameIngredients[1].text = $"2- {sandwiches[4].ingredients[1].ToString()}";
            nameIngredients[2].text = $"3- {sandwiches[4].ingredients[2].ToString()}";
            nameSandwich.text = sandwiches[4].nameSandwich;
            iconSandwiches.sprite = sandwiches[4].icon;
            buttonSandwiches.interactable = true;
        }
        else if (buttonBool[0] == true && buttonBool[3] == true && buttonBool[4] == true)
        {
            id = 5;
            buttonBool[1] = false;
            buttonBool[2] = false;
            BorderAccept[1].text = "";
            BorderAccept[2].text = "";
            nameIngredients[0].text = $"1- {sandwiches[5].ingredients[0].ToString()}";
            nameIngredients[1].text = $"2- {sandwiches[5].ingredients[1].ToString()}";
            nameIngredients[2].text = $"3- {sandwiches[5].ingredients[2].ToString()}";
            nameSandwich.text = sandwiches[5].nameSandwich;
            iconSandwiches.sprite = sandwiches[5].icon;
            buttonSandwiches.interactable = true;
        }
        else if (buttonBool[1] == true && buttonBool[2] == true && buttonBool[3] == true)
        {
            buttonBool[0] = false;
            buttonBool[4] = false;
            BorderAccept[0].text = "";
            BorderAccept[4].text = "";
        }
        else if (buttonBool[1] == true && buttonBool[2] == true && buttonBool[4] == true)
        {
            buttonBool[0] = false;
            buttonBool[3] = false;
            BorderAccept[0].text = "";
            BorderAccept[3].text = "";
        }
        else if (buttonBool[1] == true && buttonBool[3] == true && buttonBool[4] == true)
        {
            buttonBool[0] = false;
            buttonBool[2] = false;
            BorderAccept[0].text = "";
            BorderAccept[2].text = "";
        }
        else if (buttonBool[2] == true && buttonBool[3] == true && buttonBool[4] == true)
        {
            buttonBool[0] = false;
            buttonBool[1] = false;
            BorderAccept[0].text = "";
            BorderAccept[1].text = "";
        }
        else
        {
            nameSandwich.text = "-";
            iconSandwiches.sprite = null;
            buttonSandwiches.interactable = false;
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

    public void ButtonMenuInformations(bool selection)
    {
        selection = !selection;

        if (selection)
        {
            LeanTween.move(menuInformations, new Vector2(0, 0), 1f);
        }
        else
        {
            LeanTween.move(menuInformations, new Vector2(0, 500f), 1f);
        }
    }

    public void ButtonInteraction(int numberSelection)
    {
        buttonBool[numberSelection] = !buttonBool[numberSelection];

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
                if (buttonBool[0])
                {
                    nameIngredients[0].text = "1- Bread";
                }
                else
                {
                    nameIngredients[0].text = "1- -";
                }
                break;

            case 1:
                if (buttonBool[1])
                {
                    nameIngredients[1].text = "2- Ham";
                }
                else
                {
                    nameIngredients[1].text = "2- -";
                }
                break;

            case 2:
                if (buttonBool[2])
                {
                    if (nameIngredients[1].text == "2- Ham")
                    {
                        nameIngredients[2].text = "3- Cheese";
                    }
                    else
                    {
                        nameIngredients[1].text = "2- Cheese";
                    }
                }
                else
                {
                    if (nameIngredients[1].text == "2- Ham")
                    {
                        nameIngredients[2].text = "3- -";
                    }
                    else
                    {
                        nameIngredients[1].text = "2- -";
                    }
                }
                break;

            case 3:
                if (buttonBool[3])
                {
                    if (nameIngredients[1].text == "2- Ham")
                    {
                        nameIngredients[2].text = "3- Lettuce";
                    }
                    else if (nameIngredients[1].text == "2- Cheese")
                    {
                        nameIngredients[2].text = "3- Lettuce";
                    }
                    else
                    {
                        nameIngredients[1].text = "2- Lettuce";
                    }
                }
                else
                {
                    if (nameIngredients[1].text == "2- Ham")
                    {
                        nameIngredients[2].text = "3- -";
                    }
                    else if (nameIngredients[1].text == "2- Cheese")
                    {
                        nameIngredients[2].text = "3- -";
                    }
                    else
                    {
                        nameIngredients[1].text = "2- -";
                    }
                }
                break;

            case 4:
                if (buttonBool[4])
                {
                    nameIngredients[2].text = "3- Ketchup";
                }
                else
                {
                    nameIngredients[2].text = "3- -";
                }
                break;
        }

        Conditions();
    }

    public void ButtonConfirm()
    {
        for (int i = 0; i < buttonBool.Length; i++)
        {
            buttonBool[i] = false;
            BorderAccept[i].text = "";
        }

        nameIngredients[0].text = "1- -";
        nameIngredients[1].text = "2- -";
        nameIngredients[2].text = "3- -";

        nameSandwich.text = "-";
        iconSandwiches.sprite = null;
        buttonSandwiches.interactable = false;

        persons[0].GetComponent<Persons>().buySandwich = true;

        if (id == persons[0].GetComponent<Persons>().numberRandomSandwiches)
        {
            money++;
            moneyText.text = $": {money}";
            Debug.Log("Acertou!");
        }
        else
        {
            money--;
            moneyText.text = $": {money}";
            Debug.Log("Errou!");
        }
    }
}
