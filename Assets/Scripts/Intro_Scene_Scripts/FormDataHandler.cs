using UnityEngine;

public class FormDataHandler : MonoBehaviour
{
    private string location;
    private string gender;
    private string age;

    //  Mantém o GameObject após troca de Cena:
    private void Awake()
    {
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    //  Inicia os campos com os valores definidos no Form:
    public void SetFormData(string[] formValues)
    {
        if (formValues.Length != 3)
        {
            Debug.Log("Erro nos valores do Formulário!");
        }
        else
        {
            this.location = formValues[0];
            this.gender = formValues[1];
            this.age = formValues[2];
        }
    }

    //  Retorna os valores definidos no Form:
    public string GetFormData()
    {
        return this.location + "\n" + this.gender + "\n" + this.age;
    }
}
