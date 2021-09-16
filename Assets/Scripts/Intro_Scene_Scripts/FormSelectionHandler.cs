using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class FormSelectionHandler : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;

    //  Chamado pelo 'EventTrigger: Pointer Down' de 'Introduction_Form':
    public void ResetObjectSelection()
    {
        GameObject currentSelected = EventSystem.current.currentSelectedGameObject;
        string inputFieldValue = this.inputField.text.Trim();

        if (currentSelected == null || currentSelected.GetComponent<Button>().IsActive())
        {
            if (inputFieldValue.Equals("") || inputFieldValue.Equals(null))
            {
                EventSystem.current.SetSelectedGameObject(this.inputField.gameObject);
            }
        }
    }
}
