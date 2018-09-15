using System;

public class Objeto
{
    public int valor { get; set; }
    public int anterior { get; set; }
    public int posterior { get; set; }

    // constructor
    public Objeto(int ant, int val, int post)
	{
        valor = val;
        anterior = ant;
        posterior = post;
	}

    // mapeo los valores con los colores
    public getColor(int val)
    {
        switch (val)
        {
            case 1:
                return "ROJO";
                break;
            case 2:
                return "VERDE";
                break;
            case 3:
                return "AMARILLO";
                break;
            case 4:
                return "AZUL";
                break;
            default:
                return "ERROR"; 
                break;
        }
    }

}
