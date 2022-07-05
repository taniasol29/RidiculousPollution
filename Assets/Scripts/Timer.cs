using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    #region Fields

    // timer duration
    float totalSeconds = 0.0f; // total seconds thet the timer should run every time we run it

    // timer execution
    float elapsedSeconds = 0.0f; //counter for seconds as the timer runs
    bool running = false; // whether or not the timer is currently running

    // support for Finished property
    bool started = false;

    #endregion

    #region Properties

    // Sets the duration of the timer 
    // The duration can only be set if the timer isn't currently running
    public float Duration
    {
        set
        {
            if (!running)
            {
                totalSeconds = value;
            }
        }
    }

    // Gets whether or not the timer has finished running
    // This property returns false if the timer has never been started
    // true if finished; otherwise, false
    public bool Finished
    {
        get { return started && !running; }
    }

    // Gets whether or not the timer is currently running
    // true if running; otherwise, false
    public bool Running
    {
        get { return running; }
    }

    #endregion

    #region Methods

    // Update is called once per frame
    void Update()
    {
        // update timer and check for finished
        if (running)
        {
            elapsedSeconds += Time.deltaTime;
            if (elapsedSeconds >= totalSeconds)
            {
                running = false;
            }
        }
    }

    /// <summary>
    /// Runs the timer
    /// Because a timer of 0 duration doesn't really makes sense, 
    /// the timer only runs if the total seconds is larger than 0.
    /// This also makes sure the consumer of the class has actually
    /// set the duration to something higher than 0
    /// </summary>

    public void Run() // call this method when we run the timer
    {
        // only run with valid duration
        if (totalSeconds > 0.0f)
        {
            started = true;
            running = true;
            elapsedSeconds = 0.0f; // we just started this, that's why 0
        }
    }

    #endregion
}
