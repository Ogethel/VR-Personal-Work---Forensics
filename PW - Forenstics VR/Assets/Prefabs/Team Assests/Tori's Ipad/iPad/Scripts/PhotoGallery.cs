using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoGallery : MonoBehaviour
{
    public ScreenShot screenShotScript;
    public int counter = 0;
    public int maxCount = 0;

    public void LoadFirstPhoto()
    {

        if (screenShotScript.savedImages.Count == 0)
        {
            return;
        }
        else
        {
            screenShotScript.savedImages[counter].SetActive(true);
        }
    }


    public void LoadNextPhoto()
    {

        maxCount = screenShotScript.savedImages.Count - 1;

        if (screenShotScript.savedImages.Count >= 1 && counter != screenShotScript.savedImages.Count - 1)
        {
            screenShotScript.savedImages[counter].SetActive(false);
            counter++;
            screenShotScript.savedImages[counter].SetActive(true);

        }
        else
        {
            Debug.Log("no more pictures to see");
            return;
        }
    }

    public void LoadPreviousPhoto()
    {

        maxCount = screenShotScript.savedImages.Count - 1;

        if (screenShotScript.savedImages.Count >= 1 && counter != 0)
        {
            screenShotScript.savedImages[counter].SetActive(false);
            counter--;
            screenShotScript.savedImages[counter].SetActive(true);

        }
        else
        {
            Debug.Log("this is the first picture");
            return;
        }
    }
    public void TurnOffPhoto()
    {
        if (screenShotScript.savedImages.Count == 0)
        {
            return;
        }
        else
        {
            screenShotScript.savedImages[counter].SetActive(false);
            counter = 0;
        }

    }
}