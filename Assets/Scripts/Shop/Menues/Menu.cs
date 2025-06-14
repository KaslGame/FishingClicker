using UnityEngine;
using UnityEngine.UI;

public abstract class Menu : MonoBehaviour
{
    [SerializeField] protected Button ButtonMenu;
    [SerializeField] private string _nameMenu;

    public string NameMenu => _nameMenu;

    protected virtual void OnEnable()
    {
        ButtonMenu.onClick.AddListener(MakeAction);
    }

    private void OnDisable()
    {
        ButtonMenu.onClick.RemoveListener(MakeAction);
    }

    protected abstract void MakeAction();
}
