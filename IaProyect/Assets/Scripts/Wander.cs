using UnityEngine;

public class Wander : Istate
{
    public float circleDistance = 5f;
    public float circleRadius = 1f;
    public float maxSpeed;

    public Wander(float maxEnemySpeed)
    {
        maxSpeed = maxEnemySpeed;
    }

    public Vector3 GetSteeringForce(Vector3 currentPosition, Vector3 currentVelocity, Transform transform, float wanderAngle)
    {
        // dirección base
        Vector3 forward = currentVelocity.normalized;

        if (forward == Vector3.zero)
        {
            forward = transform.forward;
        }

        // centro del círculo
        Vector3 circleCenter = forward * circleDistance;

        // USAR ÁNGULO (ESTO ES LO IMPORTANTE)
        Vector3 displacement = new Vector3(  Mathf.Cos(wanderAngle), 0,Mathf.Sin(wanderAngle)) * circleRadius;

        //target final
        Vector3 target = currentPosition + circleCenter + displacement;

        // velocidad deseada
        Vector3 desiredVelocity = (target - currentPosition).normalized * maxSpeed;

        return desiredVelocity - currentVelocity;
    }
}