using UnityEngine;
using System.Collections;
using UnityEngine.Rendering;
public class WanderController : MonoBehaviour
{
    //punto que se movera el npc
    public Vector3 target;
    //bucle de movimiento
    public bool generate = true;
    //discncia del circulo al npc
    float circleDistance = 5f;
    //tamaño del circulo
    float circleRadius = 5f;
    //tiempo maximo para la espera del bucle
    float tiempoMax = 3f;
    //tiempo de espera
    float tiempo = 1f;
    void Start()
    {
       StartCoroutine(targetchange());
    }

     public IEnumerator targetchange()
    {
        while (generate)
        {
            Vector3 circleCenter = transform.forward * circleDistance;
            Vector3 randomPoint = new Vector3(Random.Range(-1f, 1f),0,Random.Range(-1f, 1f)).normalized * circleRadius;
            target = transform.position + circleCenter + randomPoint;
             Debug.Log($"Nuevo targert {target}.");
           yield return new WaitForSeconds(15f);
        }

    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Vector3 circleCenter = transform.position + transform.forward * circleDistance;
        Gizmos.DrawWireSphere(circleCenter, circleRadius);

        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(target, 0.3f);
    }
}
