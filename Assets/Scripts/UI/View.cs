using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class View<T> : MonoBehaviour, IView where T : View<T>
{
    [SerializeField] private GameObject _frame;

    public event Action<T> Click;

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

    private void Clicked()
    {
        Click?.Invoke((T)this);
    }

    public void ChangeActiveFrame(bool value)
    {
        _frame.SetActive(value);
    }
}
