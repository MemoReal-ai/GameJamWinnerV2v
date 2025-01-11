using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScripts : MonoBehaviour
{
     private Button _buttonMenu;
    
    void Start()
    {
        _buttonMenu=GetComponent<Button>();
        _buttonMenu.onClick.AddListener(OpenMenu);
       
    }

    public void OpenMenu ()
    {
        SceneManager.LoadScene("Menu");
    }
   
}
