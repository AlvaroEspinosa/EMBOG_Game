using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Credits : MonoBehaviour {

	public Text text;
	public string sourceFile = "Credits";
	public int speed = 70;
    public float autocloseTime = 20f;

	private string messageContent;
	private Vector2 initialPosition;

	void Start() {
		this.initialPosition = this.text.rectTransform.anchoredPosition;
		TextAsset file = Resources.Load(this.sourceFile) as TextAsset;
		this.messageContent = file.text;
		this.text.text = this.messageContent;
        StartCoroutine("autoClose");
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			this.closeCredits ();
		}

		this.text.transform.Translate (Vector3.up * Time.deltaTime * speed);
	}

	public void closeCredits() {
		this.text.rectTransform.anchoredPosition = new Vector2 (this.initialPosition.x, this.initialPosition.y);
		this.gameObject.SetActive (false);
	}

    IEnumerator autoClose()
    {
        yield return new WaitForSeconds(this.autocloseTime);
        this.closeCredits();
    }
}