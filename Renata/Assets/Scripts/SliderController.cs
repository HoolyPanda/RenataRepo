using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class SliderController : MonoBehaviour
{
    public GameObject target;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void HandleValue(float val)
    {
        this.target.GetComponent<Player>().HandleMoodValueChanges(this.name, val);
    }
// fdsafasd
}
