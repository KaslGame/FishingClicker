using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestMenuView : MonoBehaviour
{
    [SerializeField] private Image _icon;

    private List<QuestView> _questViews = new List<QuestView>();

    private void Awake()
    {
        _questViews.AddRange(gameObject.GetComponentsInChildren<QuestView>());

        foreach (QuestView questView in _questViews)
            questView.Click += OnClick;
    }

    private void OnClick(QuestView questView)
    {
        ActivateFrame(questView);
        _icon.sprite = questView.Icon;
    }

    private void ActivateFrame(IView newQuestView)
    {
        foreach (QuestView questView in _questViews)
            questView.ChangeActiveFrame(false);

        newQuestView.ChangeActiveFrame(true);
    }
}
