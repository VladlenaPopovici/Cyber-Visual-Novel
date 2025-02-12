using UnityEngine;
using Naninovel;
using UnityEngine.UI;

public class MapLocation : MonoBehaviour
{
    public string locationName;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnLocationSelected);
    }

    private void OnLocationSelected()
    {
        var variableManager = Engine.GetService<ICustomVariableManager>();
        variableManager.SetVariableValue("selectedLocation", locationName);

        transform.parent.gameObject.SetActive(false);
    }
}