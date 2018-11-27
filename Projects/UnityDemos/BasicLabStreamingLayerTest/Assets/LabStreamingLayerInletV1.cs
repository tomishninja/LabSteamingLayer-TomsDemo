using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LSL;

public class LabStreamingLayerInletV1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        // wait until an EEG stream shows up
        liblsl.StreamInfo[] results = liblsl.resolve_stream("type", "Markers");

        // open an inlet and print meta-data
        liblsl.StreamInlet inlet = new liblsl.StreamInlet(results[0]);
        System.Console.Write(inlet.info().as_xml());

        // read samples
        string[] sample = new string[1];
        while (true)
        {
            inlet.pull_sample(sample);
            Debug.Log(sample[0]);
        }
    }
}
