using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class FeedbackHandler : MonoBehaviour
{
    private const string GFormBaseURL = "https://docs.google.com/forms/d/e/1FAIpQLSc768D7SNm_aF4A91uMsa9gbwq36P_ZUD0swQxMnJvTVPWIVw/";
    private const string GFormViewURL = GFormBaseURL + "viewform";
    private const string GFormResponseURL = GFormBaseURL + "formResponse";
    private const string GFormEntryID_Info = "entry.878052216";
    private const string GFormEntryID_Image = "entry.2086769860";

    private FormDataHandler formDataHandler;
    private SceneryImageHandler sceneryImageHandler;

    private void Awake()
    {
        this.formDataHandler = GameObject.FindObjectOfType<FormDataHandler>();
        this.sceneryImageHandler = GameObject.FindObjectOfType<SceneryImageHandler>();
    }

    //  Chamado pelo 'Menu_Button' para enviar informações ao GoogleForms fornecido:
    public void SendFeedback()
    {
        if (this.formDataHandler != null)
        {
            StartCoroutine(SendDataToGForm(this.formDataHandler.GetFormData(), this.sceneryImageHandler.GetImagePathString()));
        }
        else
        {
            Debug.Log("Formulário vazio!");
        }
    }

    //  Envia os valores fornecidos como resposta para o GoogleForms fornecido:
    private IEnumerator SendDataToGForm(string entryResponseInfo, string entryResponseImage)
    {
        WWWForm form = new WWWForm();
        form.AddField(GFormEntryID_Info, entryResponseInfo);
        form.AddField(GFormEntryID_Image, entryResponseImage);
        UnityWebRequest unityWebRequest = UnityWebRequest.Post(GFormResponseURL, form);
        yield return unityWebRequest.SendWebRequest();

        if (unityWebRequest.error == null)
        {
            Debug.Log("Feedback: " + unityWebRequest.result);
        }
        else
        {
            Debug.Log("Feedback: " + unityWebRequest.error);
        }
    }

}
