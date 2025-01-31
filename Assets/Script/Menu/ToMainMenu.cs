using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMainMenu : MonoBehaviour
{

 private void ToWinMenu()
 {
  SceneManager.LoadScene("Menu");
 }

 private void OnTriggerEnter2D(Collider2D other)
 {
  ToWinMenu();
 }
}
