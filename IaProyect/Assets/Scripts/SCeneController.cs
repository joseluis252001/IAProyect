using UnityEngine;

public class SCeneController : MonoBehaviour
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
        }

    }


}
