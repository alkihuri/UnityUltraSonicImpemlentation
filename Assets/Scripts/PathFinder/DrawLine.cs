using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

using ProtoTurtle.BitmapDrawing;
using UnityEngine.UI;

public class DrawLine : MonoBehaviour
{
    [SerializeField] GameObject rawImage;
    Texture2D texture;

    private void Start()
    {
        Material material = rawImage.GetComponent<RawImage>().material;
        texture = new Texture2D(1024, 1024, TextureFormat.RGB24, false);
        texture.wrapMode = TextureWrapMode.Clamp;
        material.SetTexture(0, texture);
    }

    // Start is called before the first frame update
    public void DrawPoint(Vector2 point)
    {

        point += new Vector2(512, 512);
   
        texture.DrawFilledCircle((int)point.x, (int)point.y, 5,Random.ColorHSV());
         

        texture.Apply();
        rawImage.GetComponent<RawImage>().texture = texture;
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
