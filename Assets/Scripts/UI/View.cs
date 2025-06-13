using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class View : MonoBehaviour, IView
{
    [SerializeField] private GameObject _frame;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(Clicked);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(Clicked);
    }

    protected abstract void Clicked();

    public void ChangeActiveFrame(bool value)
    {
        _frame.SetActive(value);
    }
}
