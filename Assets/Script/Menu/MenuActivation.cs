using System;
using UnityEngine;
using UnityEngine.UI;

public class MenuActivation : MonoBehaviour
{
   [SerializeField] private GameObject menu;
   private bool flag = false;

   private void Update()
   {
      Activation();
   }

   
   private void Activation()
   {
      
      if (Input.GetKeyDown(KeyCode.Escape) && flag == false)
      {
         menu.SetActive(true);
         flag = !flag;
         Time.timeScale = 0.00001f;
      }
      else if (Input.GetKeyDown(KeyCode.Escape))
      {
         menu.SetActive(false);  
         flag = !flag;
         Time.timeScale = 1f;
      }
   }
}
