package com.prueba.test;
import java.lang.Math;

public class Distancia {
    // Función que calcula la distancia de un punto al Origen
    public double calcularDistancia(Coordenada punto){
        return Math.sqrt(Math.pow(punto.x,2)+Math.pow(punto.y,2));
    }
}
