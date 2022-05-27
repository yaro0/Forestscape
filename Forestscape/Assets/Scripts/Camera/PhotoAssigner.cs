using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoAssigner : MonoBehaviour
{
    private Image image;

    [SerializeField] private PicturesObject picturesList;
    [SerializeField] int i;
    void Start()
    {
        image = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(picturesList.Photos[i] != null){
            image.sprite = picturesList.Photos[i];
        }
    }
}
