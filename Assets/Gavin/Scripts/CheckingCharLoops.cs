using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckingCharLoops : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
        Dog dog = new Dog("Bob", 7);
        Cat cat = new Cat("Joe", 3);

        dog.Intro();
        cat.Intro();
    }

    // Update is called once per frame
    void Update()
    {
    }
}

class Animal
{
    public string name = "George";
    public int age = 5;

    public Animal(string name1, int age1)
    {
        name = name1;
        age = age1;
    }

    public void Intro()
    {
        Debug.Log("Hi my name is " + name + " and I'm " + age + " years old. \n Nice to meet you!");
    }
}

class Dog : Animal
{
    public Dog(string name1, int age1) : base(name1, age1)
    {

    }
}

class Cat : Animal
{
    public Cat(string name1, int age1) : base(name1, age1)
    {

    }
}
