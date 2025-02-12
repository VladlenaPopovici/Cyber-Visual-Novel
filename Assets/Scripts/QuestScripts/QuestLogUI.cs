using Naninovel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestLogUI : MonoBehaviour
{
    public GameObject questPanel;
    public TMP_Text QuestLogText;

    private void OnEnable()
    {
        var variableManager = Engine.GetService<ICustomVariableManager>();
        variableManager.OnVariableUpdated += UpdateQuestLog;
    }

    private void OnDisable()
    {
        var variableManager = Engine.GetService<ICustomVariableManager>();
        variableManager.OnVariableUpdated -= UpdateQuestLog;
    }

    private void UpdateQuestLog(CustomVariableUpdatedArgs args)
    {
        if (args.Name == "questLog")
        {
            QuestLogText.text = args.Value;
        }
    }
    

    private void UpdateQuestLog()
    {
        var variableManager = Engine.GetService<ICustomVariableManager>();
        if (variableManager.TryGetVariableValue<string>("questLog", out var questLog))
        {
            QuestLogText.text = questLog;
        }
    }
    
    public void ShowQuest(Quest quest)
    {
        questPanel.SetActive(true);
    }

    public void HideQuestLog()
    {
        questPanel.SetActive(false);
    }
}