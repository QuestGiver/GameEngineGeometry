using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public struct Item
{
    public int price;
    public string name;
    public Image image;
}

public class Inventory : MonoBehaviour
{

    public int stockSize;

    public ScrollRect scrollRect;
    public Image potionImage;
    public Dictionary<int,Item> AvailibleItems = new Dictionary<int,Item>();

    //dictionaries wil not show up in editor, but arrays can
    [SerializeField]
    public Item[] items;


    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < stockSize; i++)
        {
            AvailibleItems.Add(i, PotionGenerator()); 

        }
    }

    // Update is called once per frame
    void Update()
    {

    }




    Item PotionGenerator()
    {
        Item newItem = new Item();


        char[] letters = new char[10];

        for (int i = 0; i < 10; i++)
        {
           letters[i] = (char)UnityEngine.Random.Range(65,90);
        }


        newItem.name = "Potion Of" + letters;

        newItem.price = UnityEngine.Random.Range(100,900);

        newItem.image = potionImage;

        return newItem;
    }
}
