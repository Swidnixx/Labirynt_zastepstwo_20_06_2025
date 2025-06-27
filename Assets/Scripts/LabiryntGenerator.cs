using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class LabiryntGenerator : MonoBehaviour
{
    public Texture2D mapImg;
    public ColorToPrefab[] mappings;
    public float offset = 5;

    public void Clean()
    {
        for(int i= transform.childCount-1; i >= 0 ; i--)
        {
            DestroyImmediate(transform.GetChild(i).gameObject);
        }
    }

    public void Generate()
    {
        Clean();

        for(int x=0; x < mapImg.width; x++)
        {
            for(int y=0; y < mapImg.height; y++)
            {
                Color c = mapImg.GetPixel(x, y );

                foreach(var m in mappings)
                {
                    if (m.color == c)
                    {
                        Vector3 pos = new Vector3(x, 0, y) * offset;
                        Transform fragment = Instantiate(m.prefab, transform).transform;
                        fragment.localPosition  = pos;
                    }
                }
            }
        }
    }
}

[Serializable]
public class ColorToPrefab
{
    public Color color;
    public GameObject prefab;
}
