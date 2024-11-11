using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TextSpawner : MonoBehaviour
{
    [SerializeField] GameObject textObject;
    TextMesh textMesh;
    // Start is called before the first frame update
    void Start()
    {
        textMesh = textObject.GetComponent<TextMesh>();
    }
    private void Awake() {
        //textObject.GetComponent<Renderer>().sortingLayerID=99;
    }
    public void SetText(string text, Vector3 pos) {
        textMesh.text=text;
        var instantiatedText = Instantiate(textObject, pos, Quaternion.identity);
        Destroy(instantiatedText, 0.4f);
    }
}
