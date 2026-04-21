using UnityEngine;
using System.Collections;

public enum TipoNPC
{
    Conejo,
    Goblin
}

public class SteeringController : MonoBehaviour
{
    Seek seek;
    Flee flee;
    Wander wander;

    [Header("Tipo de NPC")]
    public TipoNPC tipo;

    [Header("Objetivo (Jugador u otro NPC)")]
    public Transform target;

    [Header("Rangos de detección")]
    public float rangoVision = 10f;
    public float rangoPeligro = 6f;

    [Header("Movimiento")]
    public Vector3 velocity = Vector3.zero;
    public float maxEnemySpeed = 5f;
    public float maxEnemyForce = 10f;
    public float mass = 1f;

    [Header("Límites del mapa")]
    public float limiteMapa = 26f;

    [Header("Wander (Movimiento natural)")]
    public float circleDistance = 2f;
    public float circleRadius = 3f;

    [Header("Control de Wander")]
    public float wanderAngle;
    public float cambioAngulo = 10f;   // qué tanto gira
    public float tiempoWander = 0.3f;  // cada cuánto cambia

    Vector3 steering;
    bool generate;

    void Start()
    {
        seek = new Seek(transform.position, maxEnemySpeed);
        seek.usarArrival = true;

        flee = new Flee(transform.position, maxEnemySpeed);

        wander = new Wander(maxEnemySpeed);

        StartCoroutine(TiempoWander());
    }
    void FixedUpdate()
    {
        float distancia = Vector3.Distance(transform.position, target.position);

        if (tipo == TipoNPC.Conejo)
        {
            // CONEJO → HUIR
            if (distancia < rangoVision)
            {
                flee.targetPosition = target.position;
                flee.velocity = velocity;
                flee.maxSpeed = maxEnemySpeed;

                steering = flee.GetSteeringForce(transform.position);
            }
            else
            {
                steering = wander.GetSteeringForce(transform.position, velocity, transform, wanderAngle);
            }
        }
        else if (tipo == TipoNPC.Goblin)
        {
            // GOBLIN → PERSEGUIR
            if (distancia < rangoVision)
            {
                seek.targetPosition = target.position;
                seek.velocity = velocity;
                seek.maxSpeed = maxEnemySpeed;

                steering = seek.GetSteeringForce(transform.position);
            }
            else
            {
                steering = wander.GetSteeringForce(transform.position, velocity, transform, wanderAngle);
            }
        }

        MovimientoNpc();
    }
    //MOVIMIENTO DEL NPC
    void MovimientoNpc()
    {
        steering = Vector3.ClampMagnitude(steering, maxEnemyForce);
        steering /= mass;

        velocity = Vector3.ClampMagnitude(velocity + steering, maxEnemySpeed);

        transform.position += velocity * Time.fixedDeltaTime;

        // Rotación
        if (velocity != Vector3.zero)
        {
            transform.forward = velocity.normalized;
        }

        // Limitar dentro del mapa
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -limiteMapa, limiteMapa);
        pos.z = Mathf.Clamp(pos.z, -limiteMapa, limiteMapa);
        transform.position = pos;
    }

    // DEBUG (GIZMOS)
    void OnDrawGizmos()
    {
        // rango visión
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, rangoVision);

        // rango peligro
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoPeligro);

        // círculo wander
        Gizmos.color = Color.blue;
        Vector3 circleCenter = transform.position + transform.forward * circleDistance;
        Gizmos.DrawWireSphere(circleCenter, circleRadius);
    }

   
    // CORRUTINA WANDER
    IEnumerator TiempoWander()
    {
        generate = true;

        while (generate)
        {
            wanderAngle += UnityEngine.Random.Range(-cambioAngulo, cambioAngulo);

            yield return new WaitForSeconds(tiempoWander);
        }
    }
}