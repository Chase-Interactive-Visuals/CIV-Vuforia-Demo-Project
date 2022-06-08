using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System.IO;

public class EmailComposer 
{
	//public delegate void ScreenShotDelegate(bool screenShotStatus);
	[DllImport("__Internal")]
	private static extern bool _ShowMailComposer();
	public static IEnumerator ShowMailComposer()
	{
		yield return new WaitForEndOfFrame ();
		_ShowMailComposer ();
	}


//===========================================================================Screenshot=============================================================================================================================================

	[DllImport("__Internal")]
	private static extern void _ShowMailComposerWithSubjectBodyCCReceiptentsBCCReceiptentsAndScreenShot(string subject, string content, string receiptent, string ccReceiptent, string bccReceiptent);
	[DllImport("__Internal")]
	private static extern void _ShowMailComposerWithSubjectBodyCCReceiptentsBCCReceiptents(string subject, string content, string receiptent, string ccReceiptent, string bccReceiptent);

	public static IEnumerator ShowMailComposerWithSubjectBodyCCReceiptentsBCCReceiptentsAndScreenShot(string subject, string content, string [] receiptent, string [] ccReceiptent, string [] bccReceiptent, bool isScreenshot)
	{
		string tempCcReceiptents = getListOFReceiptent(ccReceiptent); 
		string tempBccReciptents= getListOFReceiptent(bccReceiptent);
		string tempreciptents= getListOFReceiptent(receiptent);
		if (isScreenshot) 
		{
			yield return new WaitForEndOfFrame ();
			ScreenCapture.CaptureScreenshot ("Screenshot.png");
			yield return new WaitForSeconds (3);
			_ShowMailComposerWithSubjectBodyCCReceiptentsBCCReceiptentsAndScreenShot (subject, content,tempreciptents, tempCcReceiptents, tempBccReciptents);
		} 
		else 
		{
			yield return new WaitForEndOfFrame ();
			_ShowMailComposerWithSubjectBodyCCReceiptentsBCCReceiptents(subject, content,tempreciptents, tempCcReceiptents, tempBccReciptents);
		}
	}


//======================================================================Specific Image==================================================================================================================================================
	[DllImport("__Internal")]
	private static extern void _ShowMailComposerWithSubjectBodyCCReceiptentsBCCReceiptentsAndImageName(string subject, string content, string receiptent, string ccReceiptent, string bccReceiptent, string imageName);
	public static IEnumerator ShowMailComposerWithSubjectBodyCCReceiptentsBCCReceiptentsAndImageName(string subject, string content, string [] receiptent, string [] ccReceiptent, string [] bccReceiptent, string imageName) 
	{
		Debug.Log("yeyey");
		yield return new WaitForEndOfFrame ();
		string tempCcReceiptents = getListOFReceiptent(ccReceiptent); 
		string tempBccReciptents= getListOFReceiptent(bccReceiptent);
		string tempreciptents= getListOFReceiptent(receiptent);
		_ShowMailComposerWithSubjectBodyCCReceiptentsBCCReceiptentsAndImageName(subject, content,tempreciptents, tempCcReceiptents, tempBccReciptents, imageName);
	}

	public static void SaveTextutreToApplicationPath(Texture2D texture, string imageName) 
	{
		string path = Application.persistentDataPath;
		string savePath = path + "/" + imageName;
		File.WriteAllBytes(savePath, texture.EncodeToPNG());
	}


//========================================================================================================================================================================================================================
	

	[DllImport("__Internal")]
	private static extern void _SetCallbackGameObject(string gameObject, string methodName);
	public static void SetCallbackMethod(string gameObject, string methodName) 
	{
		_SetCallbackGameObject(gameObject, methodName);
	}
//=======================================================================CSV File=================================================================================================================================================
	[DllImport("__Internal")]
	private static extern void _ShowMailComposerWithSubjectBodyCCReceiptentsBCCReceiptentsWithFile(string subject, string content, string receiptent, string ccReceiptent, string bccReceiptent, string fileName, string fileType);
	public static IEnumerator ShowMailComposerWithSubjectBodyCCReceiptentsBCCReceiptentsWithCsvFile(string subject, string content, string [] receiptent, string [] ccReceiptent, string [] bccReceiptent, string fileName) {
		yield return new WaitForEndOfFrame ();
		string tempCcReceiptents = getListOFReceiptent(ccReceiptent); 
		string tempBccReciptents= getListOFReceiptent(bccReceiptent);
		string tempreciptents= getListOFReceiptent(receiptent);
		_ShowMailComposerWithSubjectBodyCCReceiptentsBCCReceiptentsWithFile(subject, content,tempreciptents, tempCcReceiptents, tempBccReciptents, fileName, "text/csv");
	}

//=======================================================================Text File=================================================================================================================================================
	public static IEnumerator ShowMailComposerWithSubjectBodyCCReceiptentsBCCReceiptentsWithTextFile(string subject, string content, string [] receiptent, string [] ccReceiptent, string [] bccReceiptent, string fileName) {
		yield return new WaitForEndOfFrame ();
		string tempCcReceiptents = getListOFReceiptent(ccReceiptent); 
		string tempBccReciptents= getListOFReceiptent(bccReceiptent);
		string tempreciptents= getListOFReceiptent(receiptent);
		_ShowMailComposerWithSubjectBodyCCReceiptentsBCCReceiptentsWithFile(subject, content,tempreciptents, tempCcReceiptents, tempBccReciptents, fileName, "text/csv");
	}


//==============================================================================================================================================================================================================================================
	private static string getListOFReceiptent(string [] receiptentArr) {
		string tempreciptents = "";
		if(receiptentArr.GetLength(0) > 0){
			for(int i=0;i<receiptentArr.GetLength(0);i++){
				if(i == 0){
					tempreciptents = receiptentArr[i];
				}
				else{
					tempreciptents = tempreciptents + "/" + receiptentArr[i];
				}
			}
		}
		return tempreciptents;
	}

}
