using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginScript : MonoBehaviour
{
    public InputField UserField;
    public InputField PassField;
    public void LoadIntoGame(int scene)
    {
        if (UserField.text == "A" && PassField.text == "B" || UserField.text == "" && PassField.text == "")
        {
            SceneManager.LoadScene(scene);
        }
    }
}
