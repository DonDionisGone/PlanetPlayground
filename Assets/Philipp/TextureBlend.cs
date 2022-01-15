using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureBlend : MonoBehaviour
{
    public Material thisMaterial;
    public Color color;
    private float increase;

    void Start()
    {
        //thisMaterial = this.gameObject.GetComponent<Material>();
        color = thisMaterial.color;
        increase = 0.001f;


        color.a = 1f;
        thisMaterial.color = color;
    }

    // Update is called once per frame
    void Update()
    {

        if (color.a >= 0)
        {
            color.a = color.a - increase;
            thisMaterial.color = color;
        }
    }
}
