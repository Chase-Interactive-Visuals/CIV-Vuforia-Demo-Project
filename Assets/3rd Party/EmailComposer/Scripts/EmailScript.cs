using UnityEngine;
using System.Collections;

public class EmailScript : MonoBehaviour {
	public string subject;
	public string content;
	public string [] ccReceiptents;
	public string [] bccReceiptents;
	public string [] receiptents;
	public Texture2D sampleImage;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){

		if (GUI.Button (new Rect (10, 120, 610, 100), "Show Email Composer")) {
			StartCoroutine( EmailComposer.ShowMailComposer());
		}

		if (GUI.Button (new Rect (10, 230, 610, 100), "Show Mail Composer With Subject Body CcReceiptents BccReceiptents And ScreenShot")) {
			EmailComposer.SetCallbackMethod("UnityCallbackObject", "mailCallback");
			StartCoroutine( EmailComposer.ShowMailComposerWithSubjectBodyCCReceiptentsBCCReceiptentsAndScreenShot(subject, content, receiptents, ccReceiptents, bccReceiptents, true));
		}

		if (GUI.Button (new Rect (10, 340, 610, 100), "Show Mail Composer With Subject Body CcReceiptents BccReceiptents")) {
			EmailComposer.SetCallbackMethod("UnityCallbackObject", "mailCallback");
			StartCoroutine( EmailComposer.ShowMailComposerWithSubjectBodyCCReceiptentsBCCReceiptentsAndScreenShot(subject, content, receiptents, ccReceiptents, bccReceiptents, false));
		}

		if (GUI.Button (new Rect (10, 450, 610, 100), "Send Image In Email With Subject Body CcReceiptents BccReceiptents")) {
			EmailComposer.SetCallbackMethod("UnityCallbackObject", "mailCallback");
			string imageName = "SampleImage.png";
			EmailComposer.SaveTextutreToApplicationPath(sampleImage, imageName);
			StartCoroutine(EmailComposer.ShowMailComposerWithSubjectBodyCCReceiptentsBCCReceiptentsAndImageName(subject, content, receiptents, ccReceiptents, bccReceiptents, "SampleImage.png"));
		}

		if (GUI.Button (new Rect (10, 560, 610, 100), "Send Csv File In Email With Subject Body CcReceiptents BccReceiptents")) {
			EmailComposer.SetCallbackMethod("UnityCallbackObject", "mailCallback");
			StartCoroutine(EmailComposer.ShowMailComposerWithSubjectBodyCCReceiptentsBCCReceiptentsWithCsvFile(subject, content, receiptents, ccReceiptents, bccReceiptents, "Sample.csv"));
		}

		if (GUI.Button (new Rect (10, 670, 610, 100), "Send Text File In Email With Subject Body CcReceiptents BccReceiptents")) {
			EmailComposer.SetCallbackMethod("UnityCallbackObject", "mailCallback");
			StartCoroutine(EmailComposer.ShowMailComposerWithSubjectBodyCCReceiptentsBCCReceiptentsWithTextFile(subject, content, receiptents, ccReceiptents, bccReceiptents, "Log.txt"));
		}
	}
}
