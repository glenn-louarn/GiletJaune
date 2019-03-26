using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatricePlateau : MonoBehaviour
{
    private int[,] plateau = new int[8, 10];
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                plateau[i, j] = 0;
            }
        }
    }

    public void suppresionTour(float i, float j)
    {
        int intI;
        if (i < 0)
        {
            intI = (int)(i) + 3;
        }
        else
        {
            intI = (int)(i) + 4;
        }

        int intJ;
        if (j < 0)
        {
            intJ = (int)(j) + 5;
        }
        else
        {
            intJ = (int)(j) + 6;
        }
        if (intI >= 0 && intI < 8 && intJ >= 0 && intJ < 10)
        {            
            plateau[intI, intJ] = 0;            
        }
    }
  

    public bool ajoutTour(float i, float j)
    {
        int intI;
        if (i < 0)
        {
            intI=(int)(i) + 3;
        }
        else
        {
            intI=(int)(i) + 4;
        }

        int intJ;
        if (j < 0)
        {
            intJ = (int)(j) + 5;
        }
        else
        {
            intJ = (int)(j) + 6;
        }
        if(intI >=0 && intI < 8 && intJ >= 0 && intJ < 10)
        {
            if (plateau[intI, intJ] == 0)
            {
                Debug.Log("Matrice en i = " + intI + " en j = " + intJ);
                plateau[intI, intJ] = 1;
                return true;
            }
        }
        
        Debug.Log("false");
        return false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
