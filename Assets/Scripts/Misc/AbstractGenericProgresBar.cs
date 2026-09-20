using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractGenericProgressBar<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected T targetObject;
    [SerializeField] protected Image progressBar;
    [SerializeField] protected float changeSpeed;      
    protected float targetNormalized;

    protected virtual void Awake()
    {
        progressBar.fillAmount = 0f;
    }

    protected virtual void Update()
    {
        progressBar.fillAmount = Mathf.MoveTowards(progressBar.fillAmount, targetNormalized, changeSpeed * Time.deltaTime);   
    }
}
