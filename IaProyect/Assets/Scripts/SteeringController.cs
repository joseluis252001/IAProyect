using JetBrains.Annotations;
using UnityEngine;
public enum TipoNPC
{
    Conejo,
    Goblin
}
public class SteeringController : MonoBehaviour
{
    //comportamiento seguir
    Seek seek;
    //comportamiento huir
    Flee flee;
    //Comportamiento adelante natural
    Wander wander;
    public TipoNPC tipo;
    //rango del npc
    public float rango = 5f;
    public float rangoPeligro = 6;
    public float rangoVision = 10;
    //que persige
    public Transform target;
    public GameObject player;
    //velocidad actual
    public Vector3 velocity = Vector3.zero;
    // velocidad maxima del npc
    public float maxEnemySpeed = 5f;
    //fuerza mazima del npc
    public float maxEnemyForce = 10;
    //masa maxima del npc
    public float mass = 1f;

    public float circleDistance = 2f;
    public float circleRadius = 3f;

    public float lineGizmo; 
    public float distance;

    public Vector3 steering;
    public float limiteMapa;


    void Start()
    {
        seek = new Seek(transform.position, maxEnemySpeed);
        seek.usarArrival = true; 

        flee = new Flee(transform.position, maxEnemySpeed);

        wander = new Wander(maxEnemySpeed);

    }

    void FixedUpdate()
    {
        // //donde esta el objetivo
        // seek.targetPosition = target.position;
        // //que tan rapido va el npc
        // seek.velocity = velocity;
        // //que velocidad puede tener el npc
        // seek.maxSpeed = maxEnemySpeed;
        // //muevete de esta manera
        // Vector3 steering = seek.GetSteeringForce(transform.position);
        // //limito la fuerza
        // steering = Vector3.ClampMagnitude(steering, maxEnemyForce);
        // steering /= mass;
        // //calcula la nueva velocidad
        // velocity = Vector3.ClampMagnitude(velocity + steering, maxEnemySpeed);
        // //mueve al npc
        // transform.position += velocity * Time.fixedDeltaTime;
        //float distancia = Vector3.Distance(transform.position, target.position);
       
    float distancia = Vector3.Distance(transform.position, target.position);

        if (tipo == TipoNPC.Conejo)
        {
    
        if (distancia < rangoVision)
        {
        flee.targetPosition = target.position;
        flee.velocity = velocity;
        flee.maxSpeed = maxEnemySpeed;
        steering = flee.GetSteeringForce(transform.position);
        }

            else
             {
             steering = wander.GetSteeringForce(transform.position, velocity, transform);
             }
        }

        else if (tipo == TipoNPC.Goblin)
        {
    
            if (distancia < rangoVision)
            {
            seek.targetPosition = target.position;
            seek.velocity = velocity;
            seek.maxSpeed = maxEnemySpeed;
            steering = seek.GetSteeringForce(transform.position);
            }

            else
            {
             steering = wander.GetSteeringForce(transform.position, velocity, transform);
            }
        }

        MovimientoNpc();
    }

    public void MovimientoNpc()
    {
        //aplicar fisica
        steering = Vector3.ClampMagnitude(steering, maxEnemyForce);
        steering /= mass;

        //nueva velocidad
        velocity = Vector3.ClampMagnitude(velocity + steering, maxEnemySpeed);

        //mover NPC
        transform.position += velocity * Time.fixedDeltaTime;
        if (velocity != Vector3.zero)
    {
        transform.forward = velocity.normalized;
    }
    Vector3 pos = transform.position;

    pos.x = Mathf.Clamp(pos.x, -limiteMapa, limiteMapa);
    pos.z = Mathf.Clamp(pos.z, -limiteMapa, limiteMapa);

    transform.position = pos;

    // rotación
    if (velocity != Vector3.zero)
    {
        transform.forward = velocity.normalized;
    }
    }
    void OnDrawGizmos()
    {
         // rango vision
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, rangoVision);

        // rango peligro
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoPeligro);

        // circulo wander
        Gizmos.color = Color.blue;
        Vector3 circleCenter = transform.position + transform.forward * circleDistance;
        Gizmos.DrawWireSphere(circleCenter, circleRadius);
    }

}