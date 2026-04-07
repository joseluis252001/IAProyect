using UnityEngine;
using System.Collections;
using UnityEngine.Rendering;
public class WanderController : MonoBehaviour
{
    public  int randomx;
    public  int randomz;
    public GameObject seek;

    public Vector3 target= new Vector3();
    public float tiempo = 5;
    
    public GameObject circle;

    public bool generate;


    public IEnumerator targetchange()
    {
        while (generate)
        {
            int randomx = Random.Range( 26, -26);
            int randomz = Random.Range(26,-26);
            target = new Vector3(randomx,0,randomz);
            transform.position = target;

             Debug.Log($"{target} se esta usando");
            yield return new WaitForSeconds(tiempo);
           
        }

    }

    void Start()
    {
       StartCoroutine(targetchange());
    }

    void Update()
    {
            
    }

    public void RandomObject()
    {
        
         seek = new GameObject();
        
    }
}
