using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParticleColorChange : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleSystem;
    [SerializeField] private float range = 5.0f;
    [SerializeField] private ButtonController button; 
    private ParticleSystem.MainModule mainModule;

    private void Start()
    {
        mainModule = particleSystem.main;
    }

    private void Update()
    {
        if (ButtonController.isPressed)
        {
            if (!particleSystem.isPlaying)
            {
                particleSystem.Play();
            }

            bool animalInRange = IsAnimalInRange(range);
            bool monsterInRange = IsMonsterInRange(range);
            mainModule.startColor = animalInRange ? Color.blue : Color.green;
            mainModule.startColor = monsterInRange ? Color.red : Color.green; 
        }
        else
        {
            if (particleSystem.isPlaying)
            {
                particleSystem.Clear();
                particleSystem.Stop();
            }
        }
    }

    private bool IsAnimalInRange(float range)
    {
        GameObject[] animals = GameObject.FindGameObjectsWithTag("Animal");
        float sqrRange = range * range;

        foreach (GameObject animal in animals)
        {
            if ((transform.position - animal.transform.position).sqrMagnitude <= sqrRange)
               return true;            
        }
        return false;
    }


    private bool IsMonsterInRange(float range)
    {
        GameObject[] monsters = GameObject.FindGameObjectsWithTag("Monster");
        float sqrRange = range * range;

        foreach (GameObject monster in monsters)
        {
            if ((transform.position - monster.transform.position).sqrMagnitude <= sqrRange)
                return true;
        }
        return false; 
    }
}
