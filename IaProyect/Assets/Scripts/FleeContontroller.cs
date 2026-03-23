using UnityEngine;

public class FleeContontroller : MonoBehaviour
{
    Flee Flee;

    public Transform target;

    Vector3 velocity = Vector3.zero;

    public float maxEnemySpeed = 5f;
    public float maxEnemyForce = 10;
    public float mass = 1f;

    public float dangerDistance = 5f;
    public float maxFleeDistance = 10f;

    void Start()
    {
        Flee = new Flee(target.position, maxEnemySpeed);
        Flee.usarArrival = true;
    }

    void FixedUpdate()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, target.position);

        if (distanceToPlayer < dangerDistance)
        {
            Flee.targetPosition = target.position;
            Flee.velocity = velocity;
            Flee.maxSpeed = maxEnemySpeed;

            Vector3 steering = Flee.GetSteeringForce(transform.position);

            steering = Vector3.ClampMagnitude(steering, maxEnemyForce);
            steering /= mass;

            velocity = Vector3.ClampMagnitude(velocity + steering, maxEnemySpeed);
        }
        else
        {
            velocity = Vector3.zero;
        }

        float distanceFromPlayer = Vector3.Distance(transform.position, target.position);

        if (distanceFromPlayer > maxFleeDistance)
        {
            velocity = Vector3.zero;
        }

        transform.position += velocity * Time.fixedDeltaTime;
    }
}