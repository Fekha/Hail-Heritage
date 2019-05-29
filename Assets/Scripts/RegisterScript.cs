using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RegisterScript : MonoBehaviour
{
    // Start is called before the first frame update
    public InputField UserField;
    public InputField PassField;

    public Button submitButton;
   public void callRegister()
    {
        StartCoroutine(Register());
    }
    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", UserField.text);
        form.AddField("password", PassField.text);
        UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/register.php", form);
        yield return www.SendWebRequest();
        if (!www.isNetworkError)
        {
            Debug.Log("User created successfully.");
            Debug.Log(www.error);
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);

        }
        else
        {
            Debug.Log("User creation failed. Error: " + www.error);
        }
    }
    public void VerifyInputs()
    {
        submitButton.interactable = (UserField.text.Length >= 8 && PassField.text.Length >= 8);
    }
}
