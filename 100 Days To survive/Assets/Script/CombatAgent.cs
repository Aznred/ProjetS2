using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;
using UnityEngine.UI;

public class CombatAgent : Agent
{
    public PlayerData playerdata;
    public GameObject target;
    private bool hasWon = false;
    public Ennemy bot;
    public Slider HealthPlayer;
    public Slider MobHealth;
    public float winReward = 1.0f;
    public float losePenalty = -1.0f;
    public float noKillPenalty = -0.5f;

    public override void Initialize()
    {
        HealthPlayer.maxValue = playerdata.health * 10;
        HealthPlayer.value = playerdata.health * 10;
    }

    public override void OnEpisodeBegin()
    {
        hasWon = false;
    }

    public override void CollectObservations(VectorSensor sensor)
    {
       
        sensor.AddObservation(HealthPlayer.value);
        sensor.AddObservation(MobHealth.value);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        float actionScore = actions.ContinuousActions[0]; 

        if (actionScore > 0.5f)
        {
            MobHealth.value -= playerdata.damage*10;
          
            HealthPlayer.value -= bot.Damage * 10;

       
            if (target.GetComponent<Slider>().value <= 0)
            {
                hasWon = true;
            }
        }
    }

    public void OnEpisodeEnd()
    {
        float reward = 0f;

        if (hasWon)
        {
            reward = winReward; 
        }
        else
        {
            reward = losePenalty; 
        }

        SetReward(reward);
        EndEpisode();
    }
}
