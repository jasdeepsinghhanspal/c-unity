using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 moveDirection = new Vector3(horizontalInput, 0, 0);
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }
}
------------------------------------------------------------------------------------
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public float fallSpeed = 2f;

    void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
}

