using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class FormSelectionHandler : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;

    //  Chamado pelo 'EventTrigger: Pointer Down' de 'Introduction_Form':
    public void ResetObjectSelection()
    {
        if (EventSystem.current.currentSelectedGameObject == null || EventSystem.current.currentSelectedGameObject.name == "Form_Button")
        {
            if (this.inputField.text.Trim().Equals("") || this.inputField.text.Trim().Equals(null))
            {
                EventSystem.current.SetSelectedGameObject(this.inputField.gameObject);
            }
        }
    }
}
