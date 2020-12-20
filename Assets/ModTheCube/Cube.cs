using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    private float speedRotation;
    private float rangeX = 1.0f;
    private float rangeY_Z = 5.0f;
    private float startScale;
    private int dinamicScale = 100;


    void Start()
    {
        transform.position = new Vector3(Random.Range(-rangeX, rangeX),
            Random.Range(-rangeY_Z, rangeY_Z), Random.Range(-rangeY_Z, rangeY_Z));

        startScale = Random.Range(1.0f, 5.0f);
        
        Material startMaterial = Renderer.material;
        
        startMaterial.color = Random.ColorHSV();
        speedRotation = Random.Range(5.0f, 25.0f);
    }
    
    void Update()
    {
        transform.Rotate(speedRotation * Time.deltaTime, 0.5f, 0.5f);
        dinamicScale++;
        transform.localScale = Vector3.one * startScale * dinamicScale/100;
        if (transform.localScale.x > 7)
        {
            dinamicScale = 100;
            Material material = Renderer.material;
            material.color = Random.ColorHSV();
        }
    }
}
