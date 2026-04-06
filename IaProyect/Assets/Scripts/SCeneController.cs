using UnityEngine;

public class SceneController : MonoBehaviour
{
   public GameObject npc;
   public GameObject minienemy;
     
    public int spawn;
    
    void Start()
    {
     
        Spawn();
    }
    
    void Update()
    {
       
    }
    
    public void Spawn()
    {
        
        for(int contador = 0; contador <= spawn; contador++)
        {
            int randomx = Random.Range( 26, -26);
            int randomz = Random.Range(26,-26);
            Instantiate(npc, new Vector3(randomx,0,randomz) , Quaternion.identity);

            int random = Random.Range(0, 2);
    //     #if prueba
    //     if(random == 0)
    //     {
         
    //         npc.GetComponent<Seek>().enabled = true;
    //         npc.GetComponent<Flee>().enabled = false;
    //     }
    //     else
    //     {
           
    //         npc.GetComponent<Seek>().enabled = false;
    //         npc.GetComponent<Flee>().enabled = true;
    //     }
    //     npc.GetComponent<Seek>().objetivo = rpc.transform;
    //     npc.GetComponent<Flee>().objetivo = rpc.transform;
    //   #endif
    //     }
        }
    }
}
    




