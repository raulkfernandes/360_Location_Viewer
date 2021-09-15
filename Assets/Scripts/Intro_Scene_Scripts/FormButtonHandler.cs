using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

public class FormButtonHandler : MonoBehaviour
{
    [SerializeField] private TMP_InputField locationField;
    [SerializeField] private TMP_Dropdown genderField;
    [SerializeField] private TMP_Dropdown ageField;
    [SerializeField] private GameObject alertPanel;

    private FormDataHandler formDataHandler;
    private bool isAlertActive = false;

    private void Awake()
    {
        this.formDataHandler = GameObject.FindObjectOfType<FormDataHandler>();
    }

    //  Chamado pelo botão de 'Introduction_Form' para Salvar valores do formulário e mudar de cena:
    public void StartMainScene()
    {
        if (!this.isAlertActive)
        {
            string inputFieldValue = this.GetFormValues()[0].Trim();
            if (inputFieldValue.Equals("") || inputFieldValue.Equals(null))
            {
                StartCoroutine(this.ToogleAlertPanel());
            }
            else
            {
                this.formDataHandler.SetFormData(this.GetFormValues());
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    //  Chamado caso o 'Input_Field' não tiver sido preenchido, exibindo alerta:
    private IEnumerator ToogleAlertPanel()
    {
        this.SetAlertActive(true);
        yield return new WaitForSeconds(1.25f);
        this.SetAlertActive(false);
    }

    private void SetAlertActive(bool isAlertActive)
    {
        this.isAlertActive = isAlertActive;
        this.alertPanel.SetActive(isAlertActive);
    }

    //  Retorna os valores dos 'Form_Items':
    private string[] GetFormValues()
    {
        return new string[] { this.GetInputValue(this.locationField), this.GetDropdownValue(this.genderField), this.GetDropdownValue(this.ageField) };
    }

    //  Retorna o valor fornecido no InputField:
    private string GetInputValue(TMP_InputField inputField)
    {
        return inputField.text;
    }

    //  Retorna o valor escolhido no Dropdown:
    private string GetDropdownValue(TMP_Dropdown dropdown)
    {
        int menuIndex = dropdown.value;
        List<TMP_Dropdown.OptionData> menuOptions = dropdown.options;
        return menuOptions[menuIndex].text;
    }
}
