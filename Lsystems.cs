using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class Local
{
    public Vector3 Pos;
    public Quaternion Rot;
}

public class Lsystems : MonoBehaviour
{
    private GameObject tree;

    public Vector3 inn = Vector3.zero;

    [SerializeField]
    [Range(1,7)]
    private int iteration;

    [SerializeField]
    [Range(1, 10)]
    private float lenght; 
    
    [SerializeField]
    private float angle;

    [SerializeField]
    private GameObject stick;

    private const string axiom = "X";
    private Stack<Local> transformStack;
    private Dictionary<char, string> rules;

    private string currentString = string.Empty;

    void Start()
    {
        transformStack = new Stack<Local>();
    }

    public void Generate() // function that generate multiple lines using specific rules
    {
        currentString = axiom;

        StringBuilder SB = new StringBuilder();

        for (int i = 1; i < iteration; i++)
        {
            foreach (char c in currentString)
            {
                SB.Append(rules.ContainsKey(c) ? rules[c] : c.ToString());
            }
            currentString = SB.ToString();     

            SB = new StringBuilder();    
        }

        foreach (char c in currentString)
        {
            switch(c)
            {
                case 'F': //Create a stright line and draws it
                    inn = transform.position;
                    transform.Translate(Vector3.up * lenght);

                    tree = Instantiate(stick) as GameObject;
                    tree.GetComponent<LineRenderer>().SetPosition(0, inn);
                    tree.GetComponent<LineRenderer>().SetPosition(1, transform.position);
                    break;

                case 'X':
                    break;

                case '+': //Rotate right
                    transform.Rotate(Vector3.back * angle);
                    break;

                case '-': //rotate left
                    transform.Rotate(Vector3.forward * angle);
                    break;

                case '[': //saves a current location
                    transformStack.Push(new Local()
                    {
                        Pos = transform.position,
                        Rot = transform.rotation
                    }); 
                    break;

                case ']': //loads a saved location
                    Local Lo = transformStack.Pop();
                    transform.position = Lo.Pos;
                    transform.rotation = Lo.Rot;
                    break;
            }   
        }
    }

    public void Button1()
    {
        TreeA();
    }
    public void Button2()
    {
        TreeB();
    }
    public void Button3()
    {
        TreeC();
    }
    public void Button4()
    {
        TreeD();
    }
    public void Button5()
    {
        TreeE();
    }
    public void Button6()
    {
        TreeF();
    }
    public void Button7()
    {
        TreeG();
    }
    public void Button8()
    {
        TreeH();
    }


    void TreeA()
    {
        iteration = 6;
        lenght = 6.81f;
        angle = -30;
        //Tree number 'A'
        rules = new Dictionary<char, string>
        {
            {'F', "F[+F]F[-F]F"},

            {'X', "F" }
        };
        Generate();
    }
    void TreeB()
    {
        iteration = 7;
        lenght = 9.6f;
        angle = -20;
        //Tree number'B'
        rules = new Dictionary<char, string>
        {
            {'F', "F[+F]F[-F][F]"},

            {'X', "F" }
        };
        Generate();
    }
    void TreeC()
    {
        iteration = 6;
        lenght = 8.85f;
        angle = -25.7f;
        rules = new Dictionary<char, string>
        {
             {'F', "FF-[-F+F+F]+[+F-F-F]"},

             {'X', "F" }
        };
        Generate();
    }
    void TreeD()
    {
        iteration = 7;
        lenght = 5.56f;
        angle = -20;
        //Tree number'D'
        rules = new Dictionary<char, string>
        {
             {'X', "F[+X]F[-X]+X"},

             {'F', "FF" }
        };
        Generate();
    }
    void TreeE()
    {
        iteration = 7;
        lenght = 6.75f;
        angle = -25.7f;
        //Tree number'E'
        rules = new Dictionary<char, string>
        {
             {'X', "F[+X][-X]FX"},

             {'F', "FF" }
        };
        Generate();
    }
    void TreeF()
    {
        iteration = 7;
        lenght = 5f;
        angle = -22.5f;
        //Tree number'F'
        rules = new Dictionary<char, string>
        {
            {'X', "F-[[X]+X]+F[+FX]-X"},

            {'F', "FF" }
        };
        Generate();
    }

    //My variation of a tree
    void TreeG()
    {
        iteration = 6;
        lenght = 8f;
        angle = -15f;
        rules = new Dictionary<char, string>
        {
            {'F', "FF-[F-F+F]+[F-F]"},

            {'X', "F" }
        };
        Generate();
    }
    void TreeH()
    {
        iteration = 7;
        lenght = 4.9f;
        angle = -18f;
        rules = new Dictionary<char, string>
        {
            {'X', "F+[-F-XF-X][+FF][--XF[+X]][++F-X]"},

            {'F', "FF" }
        };
        Generate();
    }

}
