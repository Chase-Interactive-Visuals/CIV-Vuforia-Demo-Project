using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmailManager : MonoBehaviour
{
    string subject;
    string content;
    [SerializeField] string[] ccReceiptents;
    [SerializeField] string[] bccReceiptents;
    [SerializeField] string[] receiptents;

    public void SendEmail()
    {
        string time = System.DateTime.UtcNow.ToLocalTime().ToString("M/d/yy_hh:mm tt");

        subject = PlayerPrefs.GetString("ClientName" + " " + time);
        content = "Client Name: \n" + PlayerPrefs.GetString("ClientName") + "\n"
            + "Client Email: \n" + PlayerPrefs.GetString("ClientEmail") + "\n"
            + "Client Phone: \n" + PlayerPrefs.GetString("ClientPhone") + "\n\n"
            + "Client Address: \n" + PlayerPrefs.GetString("MailingAddress1") + "\n\n"
            + "Client Address 2: \n" + PlayerPrefs.GetString("MailingAddress2") + "\n\n"
            + "Location Type: \n" + PlayerPrefs.GetString("LocationType") + "\n"
            + "Installation Address: \n" + PlayerPrefs.GetString("installAddress1") + "\n"
            + "Installation Address 2: \n" + PlayerPrefs.GetString("installAddress2") + "\n\n"
            + "Notes: \n" + PlayerPrefs.GetString("Notes") + "\n\n";
        EmailComposer.SetCallbackMethod("UnityCallbackObject", "mailCallback");
        StartCoroutine(EmailComposer.ShowMailComposerWithSubjectBodyCCReceiptentsBCCReceiptentsAndScreenShot
            (subject, content, receiptents, ccReceiptents, bccReceiptents, false));
    }
}