using System.Collections;
using UnityEngine;
using Assets.LSL4Unity.Scripts.AbstractInlets;
using Assets.LSL4Unity.Scripts;

public class newScriptInletForDemo : InletFloatSamples
{

    private bool pullSamplesContinuously = false;

    // Use this for initialization
    void Start () {
		
	}

    protected override bool isTheExpected(LSLStreamInfoWrapper stream)
    {
        // the base implementation just checks for stream name and type
        var predicate = base.isTheExpected(stream);
        // add a more specific description for your stream here specifying hostname etc.
        //predicate &= stream.HostName.Equals("Expected Hostname");
        return predicate;
    }
    /// <summary>
    /// Override this method to implement whatever should happen with the samples...
    /// IMPORTANT: Avoid heavy processing logic within this method, update a state and use
    /// coroutines for more complexe processing tasks to distribute processing time over
    /// several frames
    /// </summary>
    /// <param name="newSample"></param>
    /// <param name="timeStamp"></param>
    protected override void Process(float[] newSample, double timeStamp)
    {
        Debug.Log(timeStamp);
        string text = "";
        // What should this process do with what its given?
        for(int index = 0; index < newSample.Length; index++)
        {
            text += newSample[index];
            if (index != newSample.Length - 1)
            {
                text += ", ";
            }
        }

        Debug.Log(text);
    }
    
    protected override void OnStreamAvailable()
    {
        pullSamplesContinuously = true;
    }
    
    protected override void OnStreamLost()
    {
        pullSamplesContinuously = false;
    }

    private void Update()
    {
        if (pullSamplesContinuously)
        {
            pullSamples();
            Debug.Log("SamplesPulled");
        }
    }
}
