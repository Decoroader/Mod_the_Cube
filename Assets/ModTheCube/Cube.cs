using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    private float speedRotation;
    private float rangeX = 1.0f;
    private float rangeY_Z = 5.0f;
    private float startScale;
    private int dinamicScale = 100;
    [SerializeField] private int additionalParameter = 0;
    private Material material;

    void Start()
    {
        transform.position = new Vector3(Random.Range(-rangeX, rangeX),
            Random.Range(-rangeY_Z, rangeY_Z), Random.Range(-rangeY_Z, rangeY_Z));

        startScale = Random.Range(1.0f, 5.0f);
        
        material = Renderer.material;
        material.color = Random.ColorHSV();

        speedRotation = Random.Range(11.0f, 33.0f);
    }
    
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            additionalParameter++;
        if (Input.GetKey(KeyCode.DownArrow))
            additionalParameter--;
        transform.Rotate(speedRotation * Time.deltaTime + additionalParameter, 0.5f, 0.5f);
        
        dinamicScale++;

        transform.localScale = Vector3.one * startScale * dinamicScale/100;
        Coloring(additionalParameter);

        
    }
    private void Coloring(int addParameter)
    {
        if (transform.localScale.x > 7)
        {
            dinamicScale = 10;

            material.color = Random.ColorHSV();

            material.color = new Color(Random.Range(0.1f, 1.0f), Random.Range(0.1f, 1.0f), Random.Range(0.1f, 1.0f),
                0.9f);

        }
        if (addParameter < 0)
            addParameter *= -1;
        if (addParameter > 90)
            addParameter = 90;

        float trigArg = (float)(addParameter / 57.29578);
        material.color = new Color((float)(System.Math.Cos(trigArg)), 
            material.color.g * (float)(System.Math.Sin(trigArg * 2)),
            (float)System.Math.Sin(trigArg));

        if (Input.GetKey(KeyCode.C))
        {
            Debug.Log("Sin addParameter is " + (System.Math.Sin(addParameter / 57.29578)));
            Debug.Log("Cos addParameter is " + (System.Math.Cos(addParameter / 57.29578)));
            Debug.Log("material.color.r " + material.color.r + ", material.color.g " + material.color.g +
                ", material.color.b " + material.color.b);
        }
    }
}
