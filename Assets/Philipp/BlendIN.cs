using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendIN : MonoBehaviour
{
    public Material thisMaterial;
    public Color color;
    private float increase;

    void Start()
    {
        //thisMaterial = this.gameObject.GetComponent<Material>();
        color = thisMaterial.color;
        increase = 0.001f;


        color.a = 0f;
        thisMaterial.color = color;
    }

    // Update is called once per frame
    void Update()
    {

        if (color.a <= 1)
        {
            color.a = color.a + increase;
            thisMaterial.color = color;
        }
    }
}
