using UnityEngine;

public class BallMove : MonoBehaviour
{
    private float speed = .33f;

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed);
    }
}
