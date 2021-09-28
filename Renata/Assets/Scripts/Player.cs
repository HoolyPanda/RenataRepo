using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<string> dialogueOptions; 
    public float apathyAgressionMood = 0;

    public float silenceWordsMood = 0;

    public float submissionRevoltMood = 0;

    public float trustParanoiaMood = 0;

    public float agression = 0;
    public float apathy = 0;
    public float words = 0;
    public float silence = 0;
    public float revolt = 0;
    public float submission = 0;
    public float trust  = 0;
    public float paranoia = 0;
    float leadingStat;
    bool statsValChanged = false;
    public UnityEngine.UI.Text agressionLabel;
    public UnityEngine.UI.Text apathyLabel;
    public UnityEngine.UI.Text wordsLabel;
    public UnityEngine.UI.Text silenceLabel;
    public UnityEngine.UI.Text revoltLabel;
    public UnityEngine.UI.Text submissionLabel;
    public UnityEngine.UI.Text trustLabel;
    public UnityEngine.UI.Text paranoiaLabel;

    public void Start()
    {
        
    }

    public void Update()
    {
        if (statsValChanged)
        {

            // var val = apathyAgressionMood;
            // agression = val;
            // apathy = -val;
            // agressionLabel.text = agression.ToString();
            // apathyLabel.text = apathy.ToString();
            // val = silenceWordsMood;
            // words = val;
            // silence = -val;
            // wordsLabel.text = words.ToString();
            // silenceLabel.text = silence.ToString();
            // val = submissionRevoltMood;
            // revolt = val;
            // submission = -val;
            // revoltLabel.text = revolt.ToString();
            // submissionLabel.text = submission.ToString();
            // val = trustParanoiaMood;
            // trust = val;
            // paranoia = -val;
            // trustLabel.text = trust.ToString();
            // paranoiaLabel.text = paranoia.ToString();
            if (Mathf.Abs(apathyAgressionMood) >= Mathf.Abs(apathyAgressionMood) && Mathf.Abs(apathyAgressionMood) >= Mathf.Abs(submissionRevoltMood) && Mathf.Abs(apathyAgressionMood) >= Mathf.Abs(trustParanoiaMood))
            {
                if (apathyAgressionMood > 0)
                {
                    LoadSprite("Agression");
                }
                else if (apathyAgressionMood < 0)
                {
                    LoadSprite("Apathy");
                }
            }
            if (Mathf.Abs(silenceWordsMood) >= Mathf.Abs(apathyAgressionMood) && Mathf.Abs(silenceWordsMood) >= Mathf.Abs(submissionRevoltMood) && Mathf.Abs(silenceWordsMood) >= Mathf.Abs(trustParanoiaMood))
            {
                if (silenceWordsMood > 0)
                {
                    LoadSprite("Word");
                }
                else if (silenceWordsMood < 0)
                {
                    LoadSprite("Silence");
                }
            }
            if (Mathf.Abs(submissionRevoltMood) >= Mathf.Abs(silenceWordsMood) && Mathf.Abs(submissionRevoltMood) >= Mathf.Abs(apathyAgressionMood) && Mathf.Abs(submissionRevoltMood) >= Mathf.Abs(trustParanoiaMood))
            {
                if (submissionRevoltMood > 0)
                {
                    LoadSprite("Riot");
                }
                else if (submissionRevoltMood < 0)
                {
                    LoadSprite("Pokornict");
                }
            }
            if (Mathf.Abs(trustParanoiaMood) >= Mathf.Abs(silenceWordsMood) && Mathf.Abs(trustParanoiaMood) >= Mathf.Abs(submissionRevoltMood) && Mathf.Abs(trustParanoiaMood) >= Mathf.Abs(apathyAgressionMood))
            {
                if (trustParanoiaMood > 0)
                {
                    LoadSprite("Doverie");
                }
                else if (trustParanoiaMood < 0)
                {
                    LoadSprite("Paranoia");
                }
            }
            statsValChanged = false;
        }
    }
    
    void LoadSprite(string spritename)
    {
        var a  = string.Format("Sprites/{0}/{0}_{1}", this.name, spritename);
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(string.Format("Sprites/{0}/{0}_{1}", this.name, spritename));
    }
    public void HandleMoodValueChanges(string sourceName, float val)
    {
        // TODO fix bug with sprites and UI
        if (sourceName == "CommunicationSlider")
        {
            apathyAgressionMood = val;
            agression = val;
            apathy = -val;
            agressionLabel.text = agression.ToString();
            apathyLabel.text = apathy.ToString();
        }
        else if (sourceName == "PhisicalSlider")
        {
            silenceWordsMood = val;
            words = val;
            silence = -val;
            wordsLabel.text = words.ToString();
            silenceLabel.text = silence.ToString();

        }
        else if (sourceName == "KnowledgeSlider")
        {
            submissionRevoltMood = val;
            revolt = val;
            submission = -val;
            revoltLabel.text = revolt.ToString();
            submissionLabel.text = submission.ToString();

        }
        else if (sourceName == "SacralSlider")
        {
            trustParanoiaMood = val;
            trust = val;
            paranoia = -val;
            trustLabel.text = trust.ToString();
            paranoiaLabel.text = paranoia.ToString();

        }
        statsValChanged = true;
    }
    public void ChangeapathyAgressionMoodBy(float val)
    {
        this.apathyAgressionMood += val;
        agression = apathyAgressionMood;
        apathy = -apathyAgressionMood;
        agressionLabel.text = agression.ToString();
        apathyLabel.text = apathy.ToString();
        this.statsValChanged = true;
    }
    public void ChangesilenceWordsMoodBy(float val)
    {
        this.silenceWordsMood += val;
        words = silenceWordsMood;
        silence = -silenceWordsMood;
        wordsLabel.text = words.ToString();
        silenceLabel.text = silence.ToString();
        this.statsValChanged = true;
    }
    public void ChangesubmissionRevoltMoodBy(float val)
    {
        this.submissionRevoltMood += val;
        revolt = submissionRevoltMood;
        submission = -submissionRevoltMood;
        revoltLabel.text = revolt.ToString();
        submissionLabel.text = submission.ToString();
        this.statsValChanged = true;
    }
    public void ChangetrustParanoiaMoodBy(float val)
    {
        this.trustParanoiaMood += val;
        trust = trustParanoiaMood;
        paranoia = -trustParanoiaMood;
        trustLabel.text = trust.ToString();
        paranoiaLabel.text = paranoia.ToString();
        this.statsValChanged = true;
    }
    public void AddDialogueOption(string value)
    {   
        if (!dialogueOptions.Contains(value))
        {
            dialogueOptions.Add(value);
        }
    }
}
