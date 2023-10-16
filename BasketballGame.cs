using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBgame : MonoBehaviour
{
    public Transform hoop;
    public Transform player;
    public float shootingForce = 10f;

    private bool isShooting = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isShooting)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 shootDirection = (hit.point - player.position).normalized;
                ShootBall(shootDirection);
            }
        }
    }

    private void ShootBall(Vector3 direction)
    {
        isShooting = true;
        GameObject basketball = new GameObject("Basketball");
        Rigidbody rb = basketball.AddComponent<Rigidbody>();
        basketball.transform.position = player.position;
        rb.AddForce(direction * shootingForce, ForceMode.Impulse);
        StartCoroutine(CheckScore(basketball));
    }

    private IEnumerator CheckScore(GameObject basketball)
    {
        yield return new WaitForSeconds(2f); 
        float distanceToHoop = Vector3.Distance(basketball.transform.position, hoop.position);
        if (distanceToHoop < 2f)
        {
            Debug.Log("Score!");
        }
        else
        {
            Debug.Log("Miss!");
        }
        Destroy(basketball);

        isShooting = false;
    }
}
