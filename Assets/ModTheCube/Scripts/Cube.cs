using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    private float speedRotation;
    private float speedMove = 1.10f;
    private float rangeX = 1.0f;
    private float rangeY_Z = 5.0f;

    private float currentScale;
    private float scaleDiscret = 0.055f;
    private int scaleAmass = 1;

    private int mainParameter;

    private Material material;
    private float rad = 57.29578f;
    private float horizontal;
    private int witeThreshold = 500;
    private float piNumb = Mathf.PI;

    void Start()
    {
        transform.position = new Vector3(Random.Range(-rangeX, rangeX),
            Random.Range(-rangeY_Z, rangeY_Z), Random.Range(-rangeY_Z, rangeY_Z));

        currentScale = Random.Range(1.0f, 5.0f);
        transform.localScale = Vector3.one * currentScale;
        
        material = Renderer.material; 

        speedRotation = 1.5f;
        mainParameter = Random.Range(1, 91);
    }
    
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        // this line doesn't work the way i want:
        //transform.Translate(Vector3.right * Time.deltaTime * horizontal * speedMove);
        transform.position = new Vector3(transform.position.x + horizontal * speedMove, 
            transform.position.y, transform.position.z);

        if (Input.GetKey(KeyCode.UpArrow))
            mainParameter++;
        if (Input.GetKey(KeyCode.DownArrow))
            mainParameter--;
        transform.Rotate(speedRotation * Time.deltaTime * mainParameter, 
            speedRotation * Time.deltaTime * mainParameter, speedRotation * Time.deltaTime * mainParameter);

        Coloring(mainParameter);

        ScalingCube();

        if (Input.GetKey(KeyCode.Q))
            Application.Quit();
    }
    private void ScalingCube()
	{
        if ((transform.localScale.x > 7) || (transform.localScale.x < 1))
            scaleAmass *= -1;

        currentScale += scaleDiscret * scaleAmass;
        transform.localScale = Vector3.one * currentScale;
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
