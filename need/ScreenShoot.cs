using System.Collections;
using System.Collections.Generic;
using TMPro;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ScreenShoot : MonoBehaviour
{
    public RawImage image;
    public int Num;
    private string url;
    public Transform fpc;

  public void SavePos()
 
    {
      StreamWriter sw = File.CreateText(Application.persistentDataPath + "/save" + Num + ".txt");
      sw.Write(fpc.position);
      sw.Close(); 
    }

    private void Start()
    {
        url = Application.persistentDataPath.ToString();
        WWW www = new WWW(url+"/SavedScreen.png");
        image.texture = www.texture;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int width = Screen.width;
            int height = Screen.height;
            var texture = ScreenCapture.CaptureScreenshotAsTexture();
            Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);
            tex = texture;
            image.texture = tex;
            byte[] bytes = tex.EncodeToPNG();
            File.WriteAllBytes(Application.persistentDataPath + "/SavesScreen.png", bytes);
        }
    }
}



