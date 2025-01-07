using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Experimental.AI;


public class Spawn : MonoBehaviour
{
    [SerializeField] private Vector3 test;
    [SerializeField] private GameObject prefab;
   
    private void Start()
    {
        Instantiate(prefab,test,Quaternion.identity);
    }
}
