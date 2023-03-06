using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingPlatform : MonoBehaviour
{

    [SerializeField] private Transform pointA; // точка A
    [SerializeField] private Transform pointB; // точка B
    private Vector3 platformPosition;
    private Rigidbody platformRigidbody;
    private float speed = 1f;
    private Transform target;


    private void Awake()
    {
        platformRigidbody = GetComponent<Rigidbody>();
        platformRigidbody.isKinematic = true;
    }

    private void FixedUpdate()
    {
        MovePlatform();
    }

    /// <summary>
    /// Метод движения платформы
    /// </summary>
    /// <param name="flag"></param>
    private void MovePlatform()
    {
        // Определяем где находится платформа и в каком направление будет осуществлять движение
        if (platformRigidbody.position == pointB.position) target = pointA;
        if (platformRigidbody.position == pointA.position) target = pointB;

        // Определяем вектор направленя движения платформы
        platformPosition = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);

        // Передвигаем платформк
        platformRigidbody.MovePosition(platformPosition);
    }
}
