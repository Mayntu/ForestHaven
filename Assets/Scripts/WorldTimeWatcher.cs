using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WorldTimeWatcher : MonoBehaviour
{
    [SerializeField] private WorldTime worldTime;
    [SerializeField] private List<Schedule> _schedule;
    private void Start()
    {
        worldTime.WorldTimeChanged += CheckSchedule;
    }
    private void OnDestroy()
    {
        worldTime.WorldTimeChanged -= CheckSchedule;
    }
    private void CheckSchedule(object sender, TimeSpan newTime)
    {
        var schedule = 
            _schedule.FirstOrDefault(s => s.Hour == newTime.Hours && s.Minute == newTime.Minutes);
                            
        schedule?.action?.Invoke();
    }

    [Serializable]
    private class Schedule
    {
        public int Hour;
        public int Minute;
        public UnityEvent action;
    }
}
