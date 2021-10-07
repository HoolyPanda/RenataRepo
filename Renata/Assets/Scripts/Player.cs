using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Reflection;
// fdasfdsafasd
public class Player : MonoBehaviour
{
    public class s
    {
        public string[] dialogueOptions; 
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
        public float Dispute = 0;
        public float Courtesy = 0;
        public float Lies = 0;
        public float Endurance = 0; 
        public float Dexterity = 0;
        public float Exposure = 0; 
        public float Fight= 0; 
        public float Power= 0;
        public float Bookwisdom = 0;
        public float Worldlywisdom= 0; 
        public float Naturalsciences= 0;
        public float Literature= 0;
        public float Insight = 0;
        public float Morality= 0; 
        public float Intuition= 0; 
        public float Patriotism= 0;
        public string currentState = "";
        public float skillPoints = 0;
    }
    float leadingStat;
    public s stats;
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
        stats = new s();
        Load();
        
    }

    public s Load()
    {
        string dialoguesDir = Application.dataPath+"/Saves/"+this.name;
        s CFG  = JsonUtility.FromJson<s>(File.ReadAllText(dialoguesDir));
        this.stats = CFG;
        statsValChanged = true;
        return CFG;
    }

    public bool Save()
    {
        string dialoguesDir = Application.dataPath+"/Saves/"+this.name;
        string[] a = JsonUtility.ToJson(this.stats, true).Split('\n');
        File.WriteAllText(dialoguesDir, JsonUtility.ToJson(this.stats, true));
        return true;
    }

    public void Update()
    {
        if (statsValChanged)
        {
            if (Mathf.Abs(stats.apathyAgressionMood) >= Mathf.Abs(stats.apathyAgressionMood) && Mathf.Abs(stats.apathyAgressionMood) >= Mathf.Abs(stats.submissionRevoltMood) && Mathf.Abs(stats.apathyAgressionMood) >= Mathf.Abs(stats.trustParanoiaMood))
            {
                agressionLabel.text = stats.agression.ToString();
                apathyLabel.text = stats.apathy.ToString();
                if (stats.apathyAgressionMood > 0)
                {
                    LoadSprite("Agression");
                }
                else if (stats.apathyAgressionMood < 0)
                {
                    LoadSprite("Apathy");
                }
            }
            if (Mathf.Abs(stats.silenceWordsMood) >= Mathf.Abs(stats.apathyAgressionMood) && Mathf.Abs(stats.silenceWordsMood) >= Mathf.Abs(stats.submissionRevoltMood) && Mathf.Abs(stats.silenceWordsMood) >= Mathf.Abs(stats.trustParanoiaMood))
            {
                wordsLabel.text = stats.words.ToString();
                silenceLabel.text = stats.silence.ToString();
                if (stats.silenceWordsMood > 0)
                {
                    LoadSprite("Word");

                }
                else if (stats.silenceWordsMood < 0)
                {
                    LoadSprite("Silence");
                }
            }
            if (Mathf.Abs(stats.submissionRevoltMood) >= Mathf.Abs(stats.silenceWordsMood) && Mathf.Abs(stats.submissionRevoltMood) >= Mathf.Abs(stats.apathyAgressionMood) && Mathf.Abs(stats.submissionRevoltMood) >= Mathf.Abs(stats.trustParanoiaMood))
            {
                revoltLabel.text = stats.revolt.ToString();
                submissionLabel.text = stats.submission.ToString();
                if (stats.submissionRevoltMood > 0)
                {
                    LoadSprite("Riot");
                }
                else if (stats.submissionRevoltMood < 0)
                {
                    LoadSprite("Pokornict");
                }
            }
            if (Mathf.Abs(stats.trustParanoiaMood) >= Mathf.Abs(stats.silenceWordsMood) && Mathf.Abs(stats.trustParanoiaMood) >= Mathf.Abs(stats.submissionRevoltMood) && Mathf.Abs(stats.trustParanoiaMood) >= Mathf.Abs(stats.apathyAgressionMood))
            {
                trustLabel.text = stats.trust.ToString();
                paranoiaLabel.text = stats.paranoia.ToString();
                if (stats.trustParanoiaMood > 0)
                {
                    LoadSprite("Doverie");
                }
                else if (stats.trustParanoiaMood < 0)
                {
                    LoadSprite("Paranoia");
                }
            }
            statsValChanged = false;
        }
    }
    
    void LoadSprite(string spritename)
    {
        // var a  = string.Format("Sprites/{0}/{0}_{1}", this.name, spritename);
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(string.Format("Sprites/{0}/{0}_{1}", this.name, spritename));
    }

    public float GetStatByName(string name)
    {
        if (stats != null)
        {
            var a = (float)typeof(s).GetField(name).GetValue(stats);
            return (float)typeof(s).GetField(name).GetValue(stats);
        }
        else
        {
            return 0;
        }
    }
    public float GetStatForBuffsByName(string name)
    {
        if (name != null)
        {
            if(stats != null)
            {
                var a = (float)typeof(s).GetField(name).GetValue(stats);
                return (float)typeof(s).GetField(name).GetValue(stats);
            }
        }
        return 0;
    }
    public bool SetStatByName(string name, float val)
    {
        // TODO internal finction to get stats
        float statCap = 4;
        System.Reflection.FieldInfo myTypeInfo = typeof(s).GetField(name);
        if ((float)myTypeInfo.GetValue(this.stats) + val < statCap)
        {
            myTypeInfo.SetValue(this.stats, val);
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool LevelUpSkillByName(string name)
    {
        float statCap = 4;
        if (this.stats.skillPoints > 0)
        {
            System.Reflection.FieldInfo myTypeInfo = typeof(s).GetField(name);
            if ((float)myTypeInfo.GetValue(this.stats) + 1*CheckIfSkillBuffed(name) <= statCap)
            {
                // var a = CheckIfSkillBuffed(name);
                myTypeInfo.SetValue(this.stats, (float)myTypeInfo.GetValue(this.stats) + 1*CheckIfSkillBuffed(name));
                this.stats.skillPoints -= 1;
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }
    public void HandleMoodValueChanges(string sourceName, float val)
    {
        if (sourceName == "CommunicationSlider")
        {
            stats.apathyAgressionMood = val;
            stats.agression = val;
            stats.apathy = -val;
            agressionLabel.text = stats.agression.ToString();
            apathyLabel.text = stats.apathy.ToString();
        }
        else if (sourceName == "PhisicalSlider")
        {
            stats.silenceWordsMood = val;
            stats.words = val;
            stats.silence = -val;
            wordsLabel.text = stats.words.ToString();
            silenceLabel.text = stats.silence.ToString();

        }
        else if (sourceName == "KnowledgeSlider")
        {
            stats.submissionRevoltMood = val;
            stats.revolt = val;
            stats.submission = -val;
            revoltLabel.text = stats.revolt.ToString();
            submissionLabel.text = stats.submission.ToString();
        }
        else if (sourceName == "SacralSlider")
        {
            stats.trustParanoiaMood = val;
            stats.trust = val;
            stats.paranoia = -val;
            trustLabel.text = stats.trust.ToString();
            paranoiaLabel.text = stats.paranoia.ToString();

        }
        statsValChanged = true;
    }

    public void ChangeapathyAgressionMoodBy(float val)
    {
        if ( Mathf.Abs(stats.apathyAgressionMood + val) <= 4)
        {
            this.stats.apathyAgressionMood += val;
            stats.agression = stats.apathyAgressionMood;
            stats.apathy = -stats.apathyAgressionMood;
            agressionLabel.text = stats.agression.ToString();
            apathyLabel.text = stats.apathy.ToString();
            this.statsValChanged = true;
        }
    }

    public void ChangesilenceWordsMoodBy(float val)
    {
        if ( Mathf.Abs(stats.silenceWordsMood + val) <= 4)
        {
            this.stats.silenceWordsMood += val;
            stats.words = stats.silenceWordsMood;
            stats.silence = -stats.silenceWordsMood;
            wordsLabel.text = stats.words.ToString();
            silenceLabel.text = stats.silence.ToString();
            this.statsValChanged = true;
        }
    }

    public void ChangesubmissionRevoltMoodBy(float val)
    {
        if ( Mathf.Abs(stats.submissionRevoltMood + val) <= 4)
        {
            this.stats.submissionRevoltMood += val;
            stats.revolt = stats.submissionRevoltMood;
            stats.submission = -stats.submissionRevoltMood;
            revoltLabel.text = stats.revolt.ToString();
            submissionLabel.text = stats.submission.ToString();
            this.statsValChanged = true;
        }
    }

    public void ChangetrustParanoiaMoodBy(float val)
    {
        if ( Mathf.Abs(stats.trustParanoiaMood + val) <= 4)
        {
            this.stats.trustParanoiaMood += val;
            stats.trust = stats.trustParanoiaMood;
            stats.paranoia = -stats.trustParanoiaMood;
            trustLabel.text = stats.trust.ToString();
            paranoiaLabel.text = stats.paranoia.ToString();
            this.statsValChanged = true;
        }
    }
    public string[] GetBuffs(string skillname)
    {
        string[] vals = null;
        string[] ws = {"words", "silence"};
        string[] apag = {"apathy", "agression"};
        string[] suag = {"submission", "agression"};
        string[] agap = {"agression", "apathy"};
        string[] reag = {"revolt", "agression"};
        string[] resi = {"revolt", "silence"};
        string[] pare = {"paranoia", "revolt"};
        string[] trag = {"trust", "agression"};
        string[] sure = {"submission", "revolt"};

        switch (skillname)
        {
            case "Dispute":
                vals = ws;
                break;
            case "Courtesy":
                vals = apag;
                break;
            case "Lies":
                vals = ws;
                break;
            case "Exposure":
                vals = suag;
                break;
            case "Dexterity":
                vals = agap;
                break;
            case "Endurance":
                vals = reag;
                break;
            case "Fight":
                vals = agap;
                break;
            case "Power":
                vals = agap;
                break;
            case "Bookwisdom":
                vals = ws;
                break;
            case "Worldlywisdom":
                vals = ws;
                break;
            case "Naturalsciences":
                vals = ws;
                break;
            case "Literature":
                vals = resi;
                break;
            case "Insight":
                vals = pare;
                break;
            case "Morality":
                vals = trag;
                break;
            case "Intuition":
                vals = pare;
                break;
            case "Patriotism":
                vals = sure;
                break;
            default:
                break;
        }
        return vals;
    }
    public int CheckIfSkillBuffed(string skillname)
    {
        string[] subvals = GetBuffs(skillname);
        float bVal = GetStatByName(subvals[0]);
        float dbVal = GetStatByName(subvals[1]);
        if (bVal > 0 && bVal >dbVal)
        {
            return 2;
        }
        else if (dbVal >0 && dbVal >bVal)
        {
            return 0;
        }
        return 1;   
    }
    public void AddDialogueOption(string value)
    {   
        List<string> tmp = new List<string>();
        foreach (var item in stats.dialogueOptions)
        {
            if (!tmp.Contains(value))
            {
                tmp.Add(value);
            }    
        }

    }
}
