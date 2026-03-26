using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float speed = 5f;

      public float velocidad = 5f;
    Rigidbody rb;
    float movimientoHorizontal, movimientoVertical;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        movimientoHorizontal = Input.GetAxisRaw("Horizontal");
        movimientoVertical = Input.GetAxisRaw("Vertical");

    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(movimientoHorizontal * velocidad, rb.linearVelocity.y);
    }
}