using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class oTexture2DOP : MonoBehaviour
{

    Texture2D texture;
    Color color;
    void Start()
    {
        color = new Color(10, 60, 30, 0.3f);

        texture = new Texture2D(GetComponent<RawImage>().texture.width, GetComponent<RawImage>().texture.height, TextureFormat.BGRA32, false);
        texture = GetComponent<RawImage>().texture as Texture2D;
        texture.Apply();
        for (int y = 0; y < texture.height / 2; y++)
        {
            for (int x = 0; x < texture.width; x++)
            {
                if (texture.GetPixel(x, y).r == 0 && texture.GetPixel(x, y).g == 0 && texture.GetPixel(x, y).b == 0)
                {
                    texture.SetPixel(x, y + texture.height / 2, color);
                }
            }
        }

    }

}