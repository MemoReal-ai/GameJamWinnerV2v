using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;

public class ButtonScripts : MonoBehaviour
{
          private Button _buttonMenu;
          private Button _buttonGame;
    
    
    void Start()
    {
        _buttonMenu.onClick.AddListener(OpenMenu);
        _buttonGame.onClick.AddListener(OpenGame);
    }

    public void OpenMenu ()
    {
        SceneManager.LoadScene("Menu");
    }
    public void OpenGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
