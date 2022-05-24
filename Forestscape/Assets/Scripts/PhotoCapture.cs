using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PhotoCapture : MonoBehaviour
{
    [Header("Photo Taker")]
    [SerializeField] private Image photoDisplayArea;

    //[SerializeField] private Image test;
    [SerializeField] private GameObject photoFrame;

    [Header("Photo Fader Effect")]
    [SerializeField] private Animator fadingAnimation;

    [Header("Camera Frame")]
    [SerializeField] private GameObject cameraFrame;

    [SerializeField] PicturesObject animalPictures;

    [Header("Crosshair")]
    [SerializeField] private GameObject crosshair;

    [SerializeField] private PlayerCurrency money;

    private Texture2D screenCapture;
    private bool viewingPhoto;
    public bool photoMode = false;

    private GameObject objectHit;

    private GameObject emptyObject;

    private RaycastHit hit;

    [SerializeField]
    private Camera cam;

    private void Start()
    {

        photoMode = false;
        

    }

    private void Update()
    {
        

        if (photoMode == true)
        {

            emptyObject = new GameObject("Empty GameObject");
            emptyObject.tag = "Empty";
            objectHit = emptyObject;

            screenCapture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        }


        if (photoMode == true)
        {
            cameraFrame.SetActive(true);

            if (Input.GetMouseButtonDown(0))
            {
                crosshair.SetActive(false);
                if (!viewingPhoto)
                {
                    checkWhatHit();
                    StartCoroutine(CapturePhoto());
                }
                else
                {
                    RemovePhoto();
                }
            }

            IEnumerator CapturePhoto()
            {
                //Camera UI set false
                viewingPhoto = true;

                yield return new WaitForEndOfFrame();

                Rect regionToRead = new Rect(0, 0, Screen.width, Screen.height);

                screenCapture.ReadPixels(regionToRead, 0, 0, false);
                screenCapture.Apply();

                sortPhoto(ShowPhoto());

            }

            //displays the photo
            Sprite ShowPhoto()
            {
                Sprite photoSprite = Sprite.Create(screenCapture, new Rect(0.0f, 0.0f, screenCapture.width, screenCapture.height), new Vector2(0.5f, 0.5f), 100.0f);
                photoDisplayArea.sprite = photoSprite;

                photoFrame.SetActive(true);
                return Sprite.Create(screenCapture, new Rect(0.0f, 0.0f, screenCapture.width, screenCapture.height), new Vector2(0.5f, 0.5f), 100.0f);
            }

            //removes the photo 
            void RemovePhoto()
            {
                crosshair.SetActive(true);
                viewingPhoto = false;
                photoFrame.SetActive(false);
                cameraFrame.SetActive(false);
                photoMode = false;

            }
        }

    }

    // https://answers.unity.com/questions/29764/how-can-i-check-when-the-centre-of-camera-is-looki.html
    void checkWhatHit()
    {

        int layerMask = LayerMask.GetMask("Default");
        Vector3 cameraCenter = cam.ScreenToWorldPoint(new Vector3(Screen.width / 2f, Screen.height / 2f, cam.nearClipPlane));
        if (Physics.Raycast(cameraCenter, cam.transform.forward, out hit, 10000, layerMask))
        {
            objectHit = hit.transform.gameObject;
        }

    }

    void sortPhoto(Sprite sprite)
    {Debug.Log(objectHit.tag);
        //Debug.Log(objectHit.tag);
        switch (objectHit.tag)
        {
            case "Deer":
                addMoney(0,50);
                Texture2D animalCapture0 = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
                captureAnimal(animalCapture0);
                
                animalPictures.Photos[0] = Sprite.Create(animalCapture0, new Rect(0.0f, 0.0f, screenCapture.width, screenCapture.height), new Vector2(0.5f, 0.5f), 100.0f);
                //test.sprite = animalPictures.Photos[0];
                //Debug.Log("Yes");
                break;
            case "biche":
                addMoney(0,50);
                Texture2D animalCapture1 = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
                captureAnimal(animalCapture1);
                Sprite.Create(animalCapture1, new Rect(0.0f, 0.0f, screenCapture.width, screenCapture.height), new Vector2(0.5f, 0.5f), 100.0f);
                animalPictures.Photos[1] = sprite;
                break;
            case "Goose":
                addMoney(0,100);
                Texture2D animalCapture2 = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
                captureAnimal(animalCapture2);
                Sprite.Create(animalCapture2, new Rect(0.0f, 0.0f, screenCapture.width, screenCapture.height), new Vector2(0.5f, 0.5f), 100.0f);
                animalPictures.Photos[2] = sprite;
                break;
            case "bear":
                Texture2D animalCapture3 = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
                captureAnimal(animalCapture3);
                Sprite.Create(animalCapture3, new Rect(0.0f, 0.0f, screenCapture.width, screenCapture.height), new Vector2(0.5f, 0.5f), 100.0f);
                animalPictures.Photos[3] = sprite;
                break;
            case "Rabbit":
                Texture2D animalCapture4 = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
                captureAnimal(animalCapture4);
                Sprite.Create(animalCapture4, new Rect(0.0f, 0.0f, screenCapture.width, screenCapture.height), new Vector2(0.5f, 0.5f), 100.0f);
                animalPictures.Photos[4] = sprite;
                break;
            case "Monarch":
                addMoney(0,100);
                Texture2D animalCapture5 = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
                captureAnimal(animalCapture5);
                Sprite.Create(animalCapture5, new Rect(0.0f, 0.0f, screenCapture.width, screenCapture.height), new Vector2(0.5f, 0.5f), 100.0f);
                animalPictures.Photos[5] = sprite;
                break;
            default:
                break;
        }

        objectHit = emptyObject;
    }

    void captureAnimal(Texture2D capture)
    {
        Rect regionToRead = new Rect(0, 0, Screen.width, Screen.height);
        capture.ReadPixels(regionToRead, 0, 0, false);
        capture.Apply();
    }

    void addMoney(int i, int moneyAdded)
    {
        //Debug.Log(animalPictures.Photos[i] != emptyObject);
        if(animalPictures.Photos[i] == emptyObject || animalPictures.Photos[i] == null){
            money.playerMoney += moneyAdded;
            //Debug.Log(money.playerMoney);
        }  
    }
}
