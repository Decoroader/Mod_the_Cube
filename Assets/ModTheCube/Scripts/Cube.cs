using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    private float speedRotation;
    private float speedMove = 1.10f;
    private float horizontal;
    private float rangeX = 1.0f;
    private float rangeY_Z = 5.0f;

    private int mainParameter;

    private Material material;
    private float rad = 57.29578f;
    private float piNumb = Mathf.PI;
    private int witeThreshold = 500;

    private Color cubeColor;
    public float componentA;

    void Start()
    {
        transform.position = new Vector3(Random.Range(-rangeX, rangeX),
            Random.Range(-rangeY_Z, rangeY_Z), Random.Range(-rangeY_Z, rangeY_Z));

        material = Renderer.material;
        cubeColor = material.color;

        speedRotation = 1.5f;
        mainParameter = Random.Range(1, 180);
    }
    
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        transform.position = new Vector3(transform.position.x + horizontal * speedMove, 
            transform.position.y, transform.position.z);

        if (Input.GetKey(KeyCode.UpArrow))
            mainParameter++;
        if (Input.GetKey(KeyCode.DownArrow))
            mainParameter--;
        transform.Rotate(speedRotation * Time.deltaTime * mainParameter, 
            speedRotation * Time.deltaTime * mainParameter, speedRotation * Time.deltaTime * mainParameter);

        //Coloring(mainParameter);
        material.color = new Color(.1f, 0, .99f);
        cubeColor = material.color;
        cubeColor.a = componentA;
        material.color = cubeColor;

        if (Input.GetKey(KeyCode.Q))
            Application.Quit();
    }

    private void Coloring(int colorControl)
    {
        if (colorControl < 0)
            colorControl *= -1;

        float sectionR = colorControl / rad;
        float sectionG = 0;
        float sectionB = 0;
        float sectionA = .01f;

        if ((colorControl >= 45))
            sectionG = (colorControl / rad - piNumb / 4) * 2;
        if (colorControl >= 90)
            sectionB = (colorControl / rad - piNumb / 2);
        if ((colorControl < witeThreshold)&&(colorControl >= 180))
            sectionA = (float)180 / (colorControl * 1);
        else if (colorControl >= witeThreshold)
        {
            sectionA = 1;
            sectionR = 0;
            sectionG = piNumb / 2;
            sectionB = piNumb / 2;
        }

        material.color = new Color((Mathf.Cos(sectionR)), (Mathf.Sin(sectionG)),
            Mathf.Sin(sectionB), sectionA);

        if (Input.GetKey(KeyCode.C))
        {
            Debug.Log("material.color.r " + material.color.r + ", material.color.g " + material.color.g +
                ", material.color.b " + material.color.b + ", material.color.a " + material.color.a);
        }
    }
}

