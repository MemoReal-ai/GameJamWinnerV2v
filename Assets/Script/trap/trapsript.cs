using Unity.VisualScripting;
using UnityEngine;

public class trapsript : MonoBehaviour
{
   
       void Update()
       {
           
       } 
       
       private void OnTriggerEnter2D(Collider2D other)
       {
              if(other.gameObject.TryGetComponent<PlayerStats>(out PlayerStats playerStats))
              Destroy(gameObject);
       }
}
