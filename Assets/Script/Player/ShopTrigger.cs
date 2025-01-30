using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTriggerAndKeyInteraction : MonoBehaviour
{
    [Header("Objects to Control")]
    [SerializeField] private GameObject objectInTrigger; 
    [SerializeField] private GameObject objectByKey; 

    [Header("Settings")]
    [SerializeField] private KeyCode activationKey = KeyCode.F;
    
    [SerializeField] private Player _player;

    private bool isPlayerInTrigger = false;
    private bool isObjectByKeyActive = false;

    void Start()
    {
        if (objectInTrigger != null)
        {
            objectInTrigger.SetActive(false);
        }

        if (objectByKey != null)
        {
            objectByKey.SetActive(false);
        }
    }

    void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(activationKey))
        {
            if (objectByKey != null)
            {
                isObjectByKeyActive = !isObjectByKeyActive;

                if (isObjectByKeyActive)
                {
                    _player.enabled = false;
                    objectByKey.SetActive(true);
                }
                else
                {
                    _player.enabled = true;
                    objectByKey.SetActive(false); 
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && objectInTrigger != null)
        {
            objectInTrigger.SetActive(true);
            isPlayerInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && objectInTrigger != null)
        {
            objectInTrigger.SetActive(false);
            isPlayerInTrigger = false;
        }
    }
}