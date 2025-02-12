using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;

    private Dictionary<string, Quest> activeQuests = new Dictionary<string, Quest>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartQuest(Quest quest)
    {
        if (!activeQuests.ContainsKey(quest.Id))
        {
            activeQuests.Add(quest.Id, quest);
            Debug.Log($"Quest Started: {quest.Title}");
        }
    }

    public void CompleteQuest(string questId)
    {
        if (activeQuests.TryGetValue(questId, out Quest quest))
        {
            quest.IsCompleted = true;
            Debug.Log($"Quest Completed: {quest.Title}");
        }
    }

    public Quest GetQuest(string questId)
    {
        return activeQuests.TryGetValue(questId, out Quest quest) ? quest : null;
    }

    public List<Quest> GetAllQuests()
    {
        return new List<Quest>(activeQuests.Values);
    }
}