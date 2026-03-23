using UnityEngine;

public class Seek
{
    public Vector3 velocity;
    public Vector3 targetPosition;
    public float maxSpeed;

    public bool usarArrival;
    public float slowingDistance = 5f;

    public Seek(Vector3 target, float maxEnemySpeed)
    {
        targetPosition = target;
        maxSpeed = maxEnemySpeed;
    }

    public Vector3 GetSteeringForce(Vector3 currentPosition)
    {
        Vector3 direction = targetPosition - currentPosition;
        float distance = direction.magnitude;

        float speed = maxSpeed;

        if (usarArrival && distance < slowingDistance)
        {
            speed = maxSpeed * (distance / slowingDistance);
        }

        Vector3 desiredVelocity = direction.normalized * speed;

        return desiredVelocity - velocity;
    }
}