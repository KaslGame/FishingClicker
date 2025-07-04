using UnityEngine;

public class OpenerMenu : MonoBehaviour
{
    private const string LastNameKey = nameof(LastNameKey);

    [SerializeField] private Menu[] _menues;

    private string _lastName;

    public void OpenMenu(string name)
    {
        _lastName = name;

        for (int i = 0; _menues.Length > i; i++)
            _menues[i].gameObject.SetActive(name == _menues[i].NameMenu);

        PlayerPrefs.SetString(LastNameKey, _lastName);
        PlayerPrefs.Save();
    }

    public void OpenLastMenu()
    {
        if (PlayerPrefs.HasKey(LastNameKey))
            _lastName = PlayerPrefs.GetString(LastNameKey, "");

        for (int i = 0; _menues.Length > i; i++)
            _menues[i].gameObject.SetActive(_lastName == _menues[i].NameMenu);
    }
}
