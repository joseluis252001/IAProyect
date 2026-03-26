using JetBrains.Annotations;
using UnityEngine;

public class SteeringController : MonoBehaviour
{
    Seek seek;

    public Transform target;
    public GameObject player;
    Vector3 velocity = Vector3.zero;

    public float maxEnemySpeed = 5f;
    public float maxEnemyForce = 10;
    public float mass = 1f;

    public float lineGizmo; 
    public float distance;

    void Start()
    {
        
        seek = new Seek(target.position, maxEnemySpeed);
        seek.usarArrival = true; 
    }

    void FixedUpdate()
    {
        
        seek.targetPosition = target.position;
        seek.velocity = velocity;
        seek.maxSpeed = maxEnemySpeed;

        Vector3 steering = seek.GetSteeringForce(transform.position);

        steering = Vector3.ClampMagnitude(steering, maxEnemyForce);
        steering /= mass;

        velocity = Vector3.ClampMagnitude(velocity + steering, maxEnemySpeed);

        transform.position += velocity * Time.fixedDeltaTime;
        drollVectors();
    }
    void drollVectors()
    {
       target = new Transform.position();
       
       lineGizmo = (velocity.normalized) * discance;


    }

}