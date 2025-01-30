using System;
using UnityEngine;

public class Fader : MonoBehaviour
{
    private const string FADER_PATH = "Fader";
    private static Fader _instance;
    
    [SerializeField] private Animator animator;
    public bool isFading {  get; private set; }

    private Action _fadetCallBack;
    private Action _shineCallBack;
    public static Fader instance
    {
        get
        {
            if (_instance == null)
            {
                var prefab = Resources.Load<Fader>(FADER_PATH);
                _instance = Instantiate(prefab);
                DontDestroyOnLoad(_instance);
            }
            return _instance;
        }
    }


    public void FaidIn(Action fadetCallBack)
    {
        if (isFading)
            return;

        isFading = true;
        _fadetCallBack = fadetCallBack;
        animator.SetBool("Faded", true);


    }


    public void ShineIn(Action shineCallBack) 
    {
        if (isFading)
            return;

        isFading = true;
        _shineCallBack = shineCallBack;
        animator.SetBool("Faded", false);
    }

    private void HandleFaid()
    {
        _fadetCallBack.Invoke();
        _fadetCallBack=null;
        isFading=false;

    }
    private void HandleShine()
    {
        _shineCallBack.Invoke();
        _shineCallBack=null;
        isFading=false;
    }
}
