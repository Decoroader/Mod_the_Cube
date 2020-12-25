using UnityEngine;

public class BallShot : MonoBehaviour
{
    public GameObject mainCube;
    public GameObject ballPrefab;

    private GameObject currBall;
    private float speed = 33.0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currBall = Instantiate(ballPrefab, mainCube.transform.position, mainCube.transform.rotation) as GameObject;
            currBall.transform.localScale = Vector3.one * Random.Range(1.0f, 3.0f);
            currBall.GetComponent<Renderer>().material.color = 
                new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
            Destroy(currBall, 1.5f);
        }
        if(currBall != null)
            currBall.transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
