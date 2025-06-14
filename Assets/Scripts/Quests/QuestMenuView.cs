using UnityEngine;
using UnityEngine.UI;

public class QuestMenuView : MenuView<QuestView>
{
    [SerializeField] private Image _icon;

    protected override void OnClick(QuestView questView)
    {
        base.OnClick(questView);
        _icon.sprite = questView.Icon;
    }
}
