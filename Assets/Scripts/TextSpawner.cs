using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TextSpawner : MonoBehaviour
{
    [SerializeField] GameObject textObject;

    public void SetText(string text, Vector3 pos) {
        var instantiatedText = Instantiate(textObject, pos, Quaternion.identity);
        instantiatedText.GetComponent<TextMesh>().text=text;
        Destroy(instantiatedText, 0.7f);
    }
}
