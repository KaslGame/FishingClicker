using System.Collections.Generic;
using UnityEngine;

public abstract class MenuView<T> : MonoBehaviour where T : View<T>
{
    private List<View<T>> _views = new List<View<T>>();

    private void Awake()
    {
        _views.AddRange(gameObject.GetComponentsInChildren<View<T>>());

        foreach (View<T> view in _views)
            view.Click += OnClick;
    }

    protected virtual void OnClick(T view)
    {
        ActivateFrame(view);
    }

    private void ActivateFrame(IView newView)
    {
        foreach (View<T> view in _views)
            view.ChangeActiveFrame(false);

        newView.ChangeActiveFrame(true);
    }
}
