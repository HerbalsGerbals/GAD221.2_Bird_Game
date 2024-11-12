using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float Happiness;
    public float Cleanliness;
    public float Health;
    public float HealRate = 0.01f;
    public float Clean = 1.0f;
    public float dirtyRate;
    public float HappinessRate;
    float petIncreaseHappiness = 0.2f;
    public float CleaningHappinessCost = 0.1f;
    float cleanHappinessThreshold = 0.6f;
    float cleanUnhappyThreshold = 0.25f;
    public bool IsInjured = true;
    public int InjuryTreatmentsRequired;
    public float InjuryHeal = 0.2f;

    //public enum BirdPersonalities { Quiet = 1, Intelligent = 2, Quirky = 3, Normal = 4}
    //public BirdPersonalities currentPersonality;

    public float TreatmentTimer;
    public float TreatmentTime;

    private void Start()
    {
        Cleanliness = Random.Range(0.2f, 0.8f);
        Happiness = Random.Range(0.2f, 0.8f);
        InjuryTreatmentsRequired = Random.Range(1, 5);
    }


    private void Update()
    {
        if (!IsInjured)
        {
            Happiness = 1.0f; return;
        }
        else if (IsInjured)
        {
            Happiness = Mathf.Clamp(Happiness, 0f, 0.75f);
            Cleanliness -= dirtyRate * Time.deltaTime;
            if (Cleanliness < 0f)
            {
                Cleanliness = 0f;
            }

            if (Cleanliness > cleanHappinessThreshold)
            {
                Happiness += HappinessRate * Time.deltaTime;
            }
            if (Cleanliness < cleanUnhappyThreshold)
            {
                Happiness -= HappinessRate * Time.deltaTime;
            }
        }
    }



    public void TreatInjury()
    {
        if (TreatmentTimer > 0) return;
        if (!IsInjured) return; 
        InjuryTreatmentsRequired--;
        Health += InjuryHeal;
        if(InjuryTreatmentsRequired <= 0)
        {
            IsInjured = false;
        }
        ResetTreatmentTimer();
    }

    public void PetBird()
    {
        Happiness += petIncreaseHappiness;
    }
    public void CleanBird()
    {
        Cleanliness = Clean;
        Happiness -= CleaningHappinessCost;
    }
    void ResetTreatmentTimer()
    {
        TreatmentTimer = TreatmentTime;
    }
}
