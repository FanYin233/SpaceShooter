using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    public float CurrentSpeed = 0f;

    public float MaxSpeed = 5f;
    public float timeToTargetSpeed = 2f;

    private Vector3 velocity = Vector3.zero;
    public float acceleration;

    private void Start()
    {
        acceleration = MaxSpeed / timeToTargetSpeed;
        List<string> words = new List<string>();
        words.Add("Dog");
        words.Add("Cat");
        words.Add("Log");

        words.Insert(1, "Rat");

        words.Remove("Dog");

        Debug.Log("Index of the cat is: " + words.IndexOf("Cat"));

        for (int i = 0; i < words.Count; i++)
        {
            Debug.Log(words[i]);
        }
    }

    void Update()
    {
        //transform.position = transform.position + velocity;
        //transform.position = transform.position + Vector3.right * 0.001f;

        PlayerMovement();

        Debug.Log("CurrentSpeed" + CurrentSpeed);
    }

    void PlayerMovement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        if (moveX != 0 || moveY != 0)
        {
            if (CurrentSpeed < MaxSpeed)
            {
                CurrentSpeed += acceleration * Time.deltaTime;
                CurrentSpeed = Mathf.Min(CurrentSpeed, MaxSpeed);
            }
        }
        else
        {
            CurrentSpeed -= acceleration * Time.deltaTime;
            CurrentSpeed = Mathf.Max(CurrentSpeed, 0f);
        }

        Vector3 direction = new Vector3(moveX, moveY, 0f).normalized;

        velocity = direction * CurrentSpeed;
        transform.position += velocity * Time.deltaTime;
    }




}
