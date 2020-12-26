using UnityEngine;

public class Scaling : MonoBehaviour
{
    private float currentScale;
    private float scaleDiscret = 0.055f;
    private int scaleAmass = 1;
    
    void Start()
    {
        currentScale = Random.Range(1.0f, 5.0f);
        transform.localScale = Vector3.one * currentScale;
    }

    void Update()
    {
        if ((transform.localScale.x > 7) || (transform.localScale.x < 1))
            scaleAmass *= -1;

        currentScale += scaleDiscret * scaleAmass;
        transform.localScale = Vector3.one * currentScale;
    }
}
