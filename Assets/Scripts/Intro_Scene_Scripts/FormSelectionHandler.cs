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
        if (currentSelected == null || currentSelected.GetComponent<Button>().IsActive())
        {
            if (this.inputField.text.Trim().Equals("") || this.inputField.text.Trim().Equals(null))
            {
                EventSystem.current.SetSelectedGameObject(this.inputField.gameObject);
            }
        }
    }
}
