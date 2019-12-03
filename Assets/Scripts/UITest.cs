using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITest : MonoBehaviour
{
    // testValue - value that is going to change when AddTest() or SubstractTest() is called
    public float testValue = 2137f;
    // multiplier - value that is going to change when TestMultiplier() is called
    public float multiplier = 1f;
    // anotherMultiplier - value that is going to change when TestAnotherMultiplier() is called
    public float anotherMultiplier = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // TestAdd adds 1 to testValue
    public void TestAdd()
    {
        this.testValue += this.multiplier * this.anotherMultiplier;
        return;
    }

    // TestAdd substracts 1 from testValue
    public void TestSubstract()
    {
        this.testValue -= this.multiplier * this.anotherMultiplier;
        return;
    }

    // TestMultiplier changes multiplier
    public void TestMultiplier()
    {
        if (this.multiplier != 1f) this.multiplier = 1f;
        else this.multiplier = 2f;
        return;
    }

    // TestAnotherMultiplier changes anotherMultiplier
    public void TestAnotherMultiplier(float value)
    {
        this.anotherMultiplier = value;
        return;
    }

}
