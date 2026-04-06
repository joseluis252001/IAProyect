using UnityEngine;

public class Seek
{
    //velocidad actual
    public Vector3 velocity;
    //donde quiero ir
    public Vector3 targetPosition;
    //que tan rapido me muevo
    public float maxSpeed;
    //freno cuando se acerca al objetivo
    public bool usarArrival;
    //desde que distancia empieza a frenar
    public float slowingDistance = 5f;

    //constructor crea el comportamiento
    public Seek(Vector3 target, float maxEnemySpeed)
    {
        targetPosition = target;
        maxSpeed = maxEnemySpeed;
    }
    //funcion 
    public Vector3 GetSteeringForce(Vector3 currentPosition)
    {
        //donde se encuentra el objetivo desde mi posision
        Vector3 direction = targetPosition - currentPosition;
        //que tan lejos esta
        float distance = direction.magnitude;
        //velocidad base
        float speed = maxSpeed;
        //campo frenar al acercarse
        if (usarArrival && distance < slowingDistance)
        {
            speed = maxSpeed * (distance / slowingDistance);
        }
        //velocidad deseada
        Vector3 desiredVelocity = direction.normalized * speed;
        //fuerza final
        return desiredVelocity - velocity;
    }
}