using System;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private Transform wall1;
    [SerializeField] private Transform wall2;
    [SerializeField] private float timeToDestroy=1f;
    [SerializeField] private Transform targetToRotation;
    [SerializeField] private float speedRotation=1f;
    [SerializeField] private Vector3 rotationAxis = Vector3.forward;
    [SerializeField] private TimerBoss boss;
    private void OnValidate()
    {
        timeToDestroy = boss.TimeToSpawn;
    }
    private void Update()
    {
        Behaviour();
    }

    private void Behaviour()
    {
        wall1.RotateAround(targetToRotation.position,rotationAxis,speedRotation*Time.deltaTime);
        wall2.RotateAround(targetToRotation.position, rotationAxis, speedRotation * Time.deltaTime);
        timeToDestroy -= Time.deltaTime;
        if (timeToDestroy <= 0f)
            Destroy(gameObject);
    }
}
