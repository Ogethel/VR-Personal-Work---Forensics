using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenShot : MonoBehaviour
{
    public Camera ui_Camera;
    
    public Texture2D screenshot;
    public Texture2D image;
    public GameObject photo_GameObject;
    public RenderTexture rt;   
    public List<GameObject> savedImages;
    public Canvas imageGallery_Canvas;
    public string savedPhoto;
    public string fileName;
    public int i = 001;
    public int j = 001;
    public int resWidth = 2550;
    public int resHeight = 3300;

    /// <summary>
    /// this script goes on a button and CaptureScreen() is run on click. 
    /// </summary>
    public void CaptureScreen()
    {
        //**************** not needed ***************
        //save the image that will be taken to a texture2D
        //screenshot = RTImage(ui_Camera);
        // **************


        //save a hi-res version to the assets folder
        Sprite sprite = SaveImage(ui_Camera);
        //instantiante the game object as a child of the imageGallery_canvas
        GameObject photo = Instantiate(photo_GameObject, imageGallery_Canvas.transform);
        //change the name of the photo incrementaly
        photo.name = ("Photo" + j);
        //increment the counter
        j++;
        //apply the hi-res sprite to the photo
        photo.GetComponentInChildren<RawImage>().texture = sprite.texture;
        ////add the photo to the lis of photos
        savedImages.Add(photo);
      
    }
    /// <summary>
    /// creating the save path and seting it to increment each time
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    public string ScreenShotName(int width, int height)
    {
        //creating an incrementing save path and placing it in the assets menu
        savedPhoto = "Assets/Resources/SavedPhotos/" + "Picture" + i + ".png";
        i++;
        return savedPhoto;
        

    }
    /// <summary>
    /// saving a hi-res image to assets/recources for later use
    /// </summary>
    /// <param name="camera"></param>
    public Sprite SaveImage(Camera camera)
    {
        // create a new rendertexture for hi res photos
        RenderTexture hr = new RenderTexture(resWidth, resHeight, 24);
        //set the camera's rt to the new hi-res rt
        camera.targetTexture = hr;
        //take the picture
        Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
        camera.Render();
        RenderTexture.active = hr;
        screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);

        RenderTexture.active = null; // added to avoid errors
        //encode the screen capture to .png
        byte[] bytes = screenShot.EncodeToPNG();
        //write the screen shot to the file system using the ScreenShotName() function
        fileName = ScreenShotName(resWidth, resHeight);
        Texture2D temp = new Texture2D(2, 2);
        temp.LoadImage(bytes);

        System.IO.File.WriteAllBytes(fileName, bytes);
        //Debug.Log(string.Format("Took screenshot to: {0}", fileName));
        
        
        var spritePicture = Sprite.Create(temp, new Rect(0.0f, 0.0f, resWidth, resHeight), new Vector2(0.5f, 0.5f), 100.0f);
        camera.targetTexture = rt;
        return spritePicture;

    }
    /// <summary>
    /// creating a texture2d low res image to use as a place holder icon for a button to load the 
    /// hi-res image.
    /// </summary>
    /// <param name="camera"></param>
    /// <returns></returns>
    Texture2D RTImage(Camera camera)
    {
        // The Render Texture in RenderTexture.active is the one
        // that will be read by ReadPixels.

        var currentRT = RenderTexture.active;
        RenderTexture.active = camera.targetTexture;

        // Render the camera's view.
        camera.Render();

        // Make a new texture and read the active Render Texture into it.
        image = new Texture2D(camera.targetTexture.width, camera.targetTexture.height);
        image.ReadPixels(new Rect(0, 0, camera.targetTexture.width, camera.targetTexture.height), 0, 0);
        image.Apply();

        //reset the camera's rendertexture
        camera.targetTexture = rt;
        return image;
    }
 


}
