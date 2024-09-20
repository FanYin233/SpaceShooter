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

    public float speed = 1f;

    public float targetSpeed = 3f;
    public float timeToTargetSpeed = 2f;

    private Vector3 velocity = Vector3.zero;
    public float acceleration = 1f;

    private void Start()
    {
        acceleration = targetSpeed / timeToTargetSpeed;
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
    }

    void PlayerMovement()
    {
        velocity = Vector3.zero;
        if (Input.GetKey(KeyCode.A))
        {
            velocity += Vector3.left;
            Debug.Log("aa");
        }

        if (Input.GetKey(KeyCode.D))
        {
            velocity += Vector3.right;
        }

        if (Input.GetKey(KeyCode.W))
        {
            velocity += Vector3.up;
        }

        if (Input.GetKey(KeyCode.S))
        {
            velocity += Vector3.down;
        }

        if (speed <= 3f)
        {
            speed = speed * acceleration * Time.deltaTime;
        }
        else
        {
            return;
        }

        transform.position += velocity * Time.deltaTime;
    }




}
