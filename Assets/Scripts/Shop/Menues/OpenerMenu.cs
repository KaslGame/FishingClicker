using UnityEngine;

public class OpenerMenu : MonoBehaviour
{
    [SerializeField] private Menu[] _menues;

    private string _lastName;

    public void OpenMenu(string name)
    {
        _lastName = name;

        for (int i = 0; _menues.Length > i; i++)
            _menues[i].gameObject.SetActive(name == _menues[i].NameMenu);
    }

    public void OpenLastMenu()
    {
        for (int i = 0; _menues.Length > i; i++)
            _menues[i].gameObject.SetActive(_lastName == _menues[i].NameMenu);
    }
}
