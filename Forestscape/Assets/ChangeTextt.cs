using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTextt : MonoBehaviour
{
    
    [SerializeField] private PicturesObject picturesList;
    [SerializeField] int i;
    
    public Text changingText;

    private int money = 0;
    private int multiplier = 10;
    private int animalsFound = 0;

    // Start is called before the first frame update
    void Start()
    {
        //CheckCount has to be done only once when the scene is loaded**
        CheckCount();
        TextChange();

        //Debug.Log(picturesList.Photos.Length); //this works but counts null obj
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void TextChange()
    {
        changingText.text = money.ToString();
    }

    public void CheckCount()
    {
        for (int i = 0; i < 20; i++)
        {
            if (picturesList.Photos[i] != null)
            {
                animalsFound++;
            }
        }


        if (animalsFound > 0)
        {
            for (int i = 0; i < animalsFound; i++)
            {
                money += 5;
            }
        }

        if (animalsFound > 4)
        {
            for (int i = 0; i < animalsFound - 4; i++)
            {
                money += 10;
            }
        }

        if (animalsFound > 7)
        {
            for (int i = 0; i < animalsFound - 7; i++)
            {
                money += 15;
            }
        }

        if (animalsFound > 11)
        {
            for (int i = 0; i < animalsFound - 11; i++)
            {
                money += 25;
            }
        }

        if (animalsFound > 14)
        {
            for (int i = 0; i < animalsFound - 14; i++)
            {
                money += 50;
            }
        }

        if (animalsFound > 17)
        {
            for (int i = 0; i < animalsFound - 17; i++)
            {
                money += 75;
            }
        }

        if (animalsFound > 20)
        {
            for (int i = 0; i < animalsFound - 20; i++)
            {
                money += 100;
            }
        }


    }

}
