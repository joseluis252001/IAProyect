using UnityEngine;

public class Flee
{
    public Vector3 velocity;
    public Vector3 targetPosition;
    public float maxSpeed;

    public bool usarArrival;
    public float stoppingDistance = 10f;

    public Flee(Vector3 target, float maxEnemySpeed)
    {
        targetPosition = target;
        maxSpeed = maxEnemySpeed;
    }

    public Vector3 GetSteeringForce(Vector3 currentPosition)
    {
        Vector3 direction = currentPosition - targetPosition;
        float distance = direction.magnitude;

        float speed = maxSpeed;

        if (usarArrival && distance > stoppingDistance)
        {
            speed = 0;
        }

        Vector3 desiredVelocity = direction.normalized * speed;

        return desiredVelocity - velocity;
    }
}