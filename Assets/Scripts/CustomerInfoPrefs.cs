using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Michsky.UI.ModernUIPack;
public class CustomerInfoPrefs : MonoBehaviour
{
    [SerializeField] TMP_InputField clientName;
    [SerializeField] TMP_InputField clientEmail;
    [SerializeField] TMP_InputField clientPhone;
    [SerializeField] TMP_InputField mailingAdress1;
    [SerializeField] TMP_InputField mailingAddress2;

    [SerializeField] TMP_InputField installAddress1;
    [SerializeField] TMP_InputField installAddress2;
    [SerializeField] TMP_Text placeholderInstallAddress1;
    [SerializeField] TMP_Text placeholderInstallAddress2;
    [SerializeField] TMP_InputField locationType;

    [SerializeField] TMP_InputField notes;


    float averageTideLevel;
    bool installAddressSameAsMailing = false;

    public void AddressIsSame()
    {
        installAddressSameAsMailing = true;
        installAddress1.text = PlayerPrefs.GetString("MailingAddress1");
        installAddress2.text = PlayerPrefs.GetString("MailingAddress2");
        placeholderInstallAddress1.text = "";
        placeholderInstallAddress2.text = "";
    }
    public void AddressIsDifferent()
    {
        installAddressSameAsMailing = false;
        installAddress1.text = "";
        installAddress2.text = "";

    }
    public void SaveClientData()
    {
        PlayerPrefs.SetString("ClientName", clientName.text);
        PlayerPrefs.SetString("ClientEmail", clientEmail.text);
        PlayerPrefs.SetString("ClientPhone", clientPhone.text);
        PlayerPrefs.SetString("MailingAddress1", mailingAdress1.text);
        PlayerPrefs.SetString("MailingAddress2", mailingAddress2.text);
    }
    public void SaveLocationData()
    {
        PlayerPrefs.SetString("LocationType", locationType.text);
        if (installAddressSameAsMailing)
        {
            PlayerPrefs.SetString("installAddress1", mailingAdress1.text);
            PlayerPrefs.SetString("installAddress2", mailingAddress2.text);
        }
        else
        {
            PlayerPrefs.SetString("installAddress1", installAddress1.text);
            PlayerPrefs.SetString("installAddress2", installAddress2.text);
        }
    }
    public void SaveNotes()
    {
        PlayerPrefs.SetString("Notes", notes.text);
    }

    public void SetDockSpecs(float averageDistance)
    {
        averageTideLevel = averageDistance;
    }
}
