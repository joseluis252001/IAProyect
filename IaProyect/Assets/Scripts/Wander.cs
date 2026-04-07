using UnityEngine;

public class Wander : Istate
{
    public Vector3 velocity;
    public float circleDistance = 5f;
    public float circleRadius = 1f;
    public float maxSpeed;

    public Wander(float maxEnemySpeed)
    {
        maxSpeed = maxEnemySpeed;
    }

    public Vector3 GetSteeringForce(Vector3 currentPosition, Vector3 currentVelocity, Transform transform)
{
    //dirección base
    Vector3 forward = currentVelocity.normalized;

    //si esta detenido
    if (forward == Vector3.zero)
    {
        forward = transform.forward;
    }

    //centro del círculo
    Vector3 circleCenter = forward * circleDistance;

    //punto aleatorio
    Vector3 randomPoint = new Vector3(Random.Range(-1f, 1f),0,Random.Range(-1f, 1f)).normalized * circleRadius;

    //target final
    Vector3 target = currentPosition + circleCenter + randomPoint;

    //velocidad deseada
    Vector3 desiredVelocity = (target - currentPosition).normalized * maxSpeed;

    return desiredVelocity - currentVelocity;
}
}