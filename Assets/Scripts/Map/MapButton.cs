using UnityEngine;
using UnityEngine.UI;

public class MapButton : MonoBehaviour
{
    public GameObject mapPanel;

    private void Start()
    {
        mapPanel.SetActive(false);

        GetComponent<Button>().onClick.AddListener(ToggleMap);
    }

    private void ToggleMap()
    {
        mapPanel.SetActive(!mapPanel.activeSelf);
    }
}