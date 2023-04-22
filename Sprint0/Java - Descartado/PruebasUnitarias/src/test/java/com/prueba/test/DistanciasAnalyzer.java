package com.prueba.test;

import org.junit.jupiter.api.Test;
import static org.hamcrest.MatcherAssert.assertThat;
import static org.hamcrest.Matchers.equalTo;
import static org.hamcrest.Matchers.closeTo;


public class DistanciasAnalyzer {

    @Test
    void Origen() {
        var distancia = new Distancia();
        var punto = new Coordenada(0,0);
        var resultado = distancia.calcularDistancia(punto);
        assertThat(resultado,equalTo(0.0));
    }

    @Test
    void PrimerCuadrante() {
        var distancia = new Distancia();
        var punto = new Coordenada(3,4);
        var resultado = distancia.calcularDistancia(punto);
        assertThat(resultado,equalTo(5.0));
    }

    @Test
    void SegundoCuadrante() {
        var distancia = new Distancia();
        var punto = new Coordenada(-6,8);
        var resultado = distancia.calcularDistancia(punto);
        assertThat(resultado,equalTo(10.0));
    }

    @Test
    void TercerCuadrante() {
        var distancia = new Distancia();
        var punto = new Coordenada(-12,-5);
        var resultado = distancia.calcularDistancia(punto);
        assertThat(resultado,equalTo(13.0));
    }

    @Test
    void CuartoCuadrante() {
        var distancia = new Distancia();
        var punto = new Coordenada(1,-1);
        var resultado = distancia.calcularDistancia(punto);
        assertThat(resultado, closeTo(1.4142, 0.0001));
    }

}
