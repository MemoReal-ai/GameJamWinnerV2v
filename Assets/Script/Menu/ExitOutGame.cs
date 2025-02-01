using UnityEngine;
using UnityEngine.UI;

public class ExitOutGame : MonoBehaviour
{
    [SerializeField] private Button buttonExit;

    private void Start()
    {
        buttonExit.onClick.AddListener(()=>ExitGame());
    }
    private void OnDisable()
    {
        buttonExit?.onClick.RemoveListener(() => ExitGame());
    }
    private void ExitGame()
    {
       
       Application.Quit();
    }
}
