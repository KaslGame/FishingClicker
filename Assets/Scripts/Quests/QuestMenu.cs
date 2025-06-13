using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestMenu : MonoBehaviour
{
    [SerializeField] private GameObject _buttons;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _amount;

    private List<QuestView> _questViews = new List<QuestView>();

    private QuestView _currentQuestView;

    private void Awake()
    {
        _questViews.AddRange(_buttons.GetComponentsInChildren<QuestView>());

        foreach (QuestView questView in _questViews)
        {
            questView.Click += OnClick;
            questView.QuestFinish += OnQuestFinish;
        }
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(MakeAction);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(MakeAction);
    }

    private void OnClick(QuestView questView)
    {
        _currentQuestView = questView;
        UpdateText();
    }

    private void OnQuestFinish(int amount)
    {
        _wallet.AddExp(amount);
    }

    private void MakeAction()
    {
        if (_currentQuestView == null)
            return;

        Fish fish = _currentQuestView.Fish;

        if (_inventory.IsContains(fish) == false)
            return; 

        _inventory.RemoveFish(fish);
        _currentQuestView.AddFish(fish);

        UpdateText();
    }

    private void UpdateText()
    {
        if (_currentQuestView == null)
            return;

        _amount.text = $"{_currentQuestView.FishAmount}/{_currentQuestView.NeedFishAmount}";
    }
}
