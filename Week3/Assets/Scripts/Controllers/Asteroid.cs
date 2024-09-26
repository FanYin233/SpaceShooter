using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed = 3;
    public float arrivalDistance = 0.1f;
    public float maxFloatDistance = 5f;

    private Vector3 targetPoint;

    // Start is called before the first frame update
    void Start()
    {
        SelectTargetPoint();
    }

    // Update is called once per frame
    void Update()
    {
        AsteroidMovement();
    }
    public void AsteroidMovement()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPoint) < arrivalDistance)
        {
            SelectTargetPoint();
        }
    }

    private void SelectTargetPoint()
    {
        float randomX = Random.Range(-maxFloatDistance, maxFloatDistance);
        float randomY = Random.Range(-maxFloatDistance, maxFloatDistance);

        targetPoint = transform.position + new Vector3(randomX, randomY, 0f);
    }
}
