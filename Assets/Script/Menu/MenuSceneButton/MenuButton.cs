using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour

{
    private Button _buttonGame;
    private void Start()
    {
        _buttonGame=GetComponent<Button>();
        _buttonGame.onClick.AddListener(OpenGame);

    }

    public void OpenGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
