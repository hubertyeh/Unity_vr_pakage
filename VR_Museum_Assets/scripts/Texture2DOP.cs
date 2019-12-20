using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;



public class Texture2DOP : MonoBehaviour
{


    int[,] array2Da = new int[2048, 2048];
    Texture2D texture;
    Color color;
    void Start()
    {
        color = new Color(10, 60, 30, 0.3f);

        texture = new Texture2D(GetComponent<RawImage>().texture.width, GetComponent<RawImage>().texture.height, TextureFormat.BGRA32, false);
        texture = GetComponent<RawImage>().texture as Texture2D;
        texture.Apply();


        print("texture.width=" + texture.width+ "    texture.height=" + texture.height);


        for (int y = 0; y < texture.height; y++)
        {
            for (int x = 0; x < texture.width; x++)
            {
                array2Da[x, y] = (int)((texture.GetPixel(x, y).r + texture.GetPixel(x, y).g*0 + texture.GetPixel(x, y).b*0)*255/20);
                Debug.Log("x=" + x+"  y=" + y+"  "+array2Da[x, y]);
                if (texture.GetPixel(x, y).r == 0 && texture.GetPixel(x, y).g == 0 && texture.GetPixel(x, y).b == 0 && 1 == 0)
                {
                    texture.SetPixel(x, y + texture.height / 2, color);
                }
            }
        }

    }


    public GameObject copyGameObject;//要被複製的物件
    public GameObject superGameObject;//要被放置在哪個物件底下



    private GameObject childGameObject;//被複製出來的物件





    float[,] Realization = new float[,] { { 1f, 2f, 0f }, { 2f, 3f, 0f }, { 1f, 4f, 0f } };

    int timece = 0;

    private void OnGUI()
    {




        if ( 1 == 1 && timece < 1)//GUILayout.Button("動態產生物件") == true && timece < 1)
        {



            timece++;
            int cot = 0;
            for (int y = 0; y < texture.height; y++)
            {
                for (int x = 0; x < texture.width; x++)
                {
                    int z = 0;
                    for (z = 0; z < array2Da[x,y]; z++)
                    {

                        cot++;
                        childGameObject = Instantiate(copyGameObject);//複製copyGameObject物件(連同該物件身上的腳本一起複製)
                        childGameObject.transform.parent = superGameObject.transform;//放到superGameObject物件內
                        Debug.Log("!!! x=" + x + "  y= " + y + "  z= " + z);
                        childGameObject.transform.localPosition = new Vector3(x*10, z*10, y*10); ;//複製出來的物件放置的座標為superGameObject物件內的原點
                    }


                }
            }

            print(cot);

            //childGameObject.AddComponent<NullScript>();//動態增加名為"NullScript"的腳本到此物件身上

            //下面這一行的功能為將複製出來的子物件命名為CopyObject

            //childGameObject.name = "CopyObject";



            //產生一個Object的物件，並指定子物件上要被刪除的腳本
            //Object script = childGameObject.GetComponent<NullScript>();
            //Destroy(script);//刪除腳本
        }
        if (GUILayout.Button("動態移除物件") == true)
        {
            timece--;
            //Destroy(superGameObject);//刪除複製出來的子物件

            for (int i = 0; i < superGameObject.transform.childCount; i++)
            {
                GameObject go = superGameObject.transform.GetChild(i).gameObject;
                Destroy(go);
            }
        }
    }


}


