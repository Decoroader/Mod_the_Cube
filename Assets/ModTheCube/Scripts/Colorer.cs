using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colorer : MonoBehaviour
{
    public Cube cubeData;

    public MeshRenderer Renderer;

    public int colorControl;
    private Material material;
    private float rad = 57.29578f;
    private int witeThreshold = 500;
    private double piNumb = System.Math.PI;
    // Start is called before the first frame update
    void Start()
    {
        //colorControl = cubeData.mainParameter;
        //material = Renderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        if (colorControl < 0)
            colorControl *= -1;

        double sectionR = colorControl / rad;
        double sectionG = 0;
        double sectionB = 0;
        float sectionA = 1;

        if ((colorControl >= 45))
            sectionG = (colorControl / rad - piNumb / 4) * 2;
        if (colorControl >= 90)
            sectionB = (colorControl / rad - piNumb / 2);
        if ((colorControl < witeThreshold) && (colorControl >= 180))
            sectionA = (float)180 / (colorControl * 5);
        else if (colorControl >= witeThreshold)
        {
            sectionA = 1;
            sectionR = 0;
            sectionG = piNumb / 2;
            sectionB = piNumb / 2;
        }

        material.color = new Color((float)(System.Math.Cos(sectionR)), (float)(System.Math.Sin(sectionG)),
            (float)System.Math.Sin(sectionB), sectionA);

        if (Input.GetKey(KeyCode.C))
        {
            Debug.Log("material.color.r " + material.color.r + ", material.color.g " + material.color.g +
                ", material.color.b " + material.color.b + ", material.color.a " + material.color.a);
            Debug.Log("colorControl " + colorControl);
        }
    }
}
