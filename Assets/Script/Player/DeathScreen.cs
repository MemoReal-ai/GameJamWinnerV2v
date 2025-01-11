using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    [SerializeField] private PlayerStats player;
    [SerializeField] private GameObject conteiner;

    private bool flagLose=false;

    private void Start()
    {
        conteiner.SetActive(false);
    }

    private void Update()
    {
        if (flagLose)
        { 
            if (Input.GetKey(KeyCode.Space))
            { 
                SceneManager.LoadScene(0);
            } 
        } 
    }
    private void OnEnable()
    {
        player.OnDead += DeathScreenView;
    }

    private void OnDisable()
    {
        player.OnDead -= DeathScreenView;
    }

    private void DeathScreenView()
    {
        Time.timeScale = 0f;
        conteiner.SetActive(true);
        flagLose = true;    
       
           
 
    }
}
