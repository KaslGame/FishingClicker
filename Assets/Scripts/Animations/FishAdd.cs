using UnityEngine;
using UnityEngine.UI;

public class FishAdd : MonoBehaviour
{
    [SerializeField] private Image _icon;

    public void Init(Sprite icon)
    {
        _icon.sprite = icon;
    }

    private void Release()
    {
        Destroy(gameObject);
    }
}
