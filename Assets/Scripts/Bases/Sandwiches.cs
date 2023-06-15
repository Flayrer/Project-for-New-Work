using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Sandwiches", order = 1)]
public class Sandwiches : ScriptableObject
{
    public Sprite icon;

    public string nameSandwich;

    public Ingredients[] ingredients;
}

public enum Ingredients {Bread, Ham, Cheese, Lettuce, Ketchup}