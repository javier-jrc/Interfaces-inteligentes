# Entrega de la practica 1
- Assets/ScriptCubo.cs
- Assets/ScriptEsfera.cs
- GIFPO1II.gif

En el entorno se crearon 3 Objetos 1 cubo 1 esfera y 1 cilindro

## Assets/ScriptCubo.cs
La clase del cubo contiene
- Variables del objeto
- Funcion para cambiar el color
- En el Update logica para cambiar el color

## Assets/ScriptEsfera.cs
La clase de la Esfera contiene
- Los vectores Vector3 necesarios para los ejercicios
- Variables para las magnitudes
- En la función Update() se encuentra la logica y impresión por consola

## GIFPO1II.gif
Gif con el funcionamiento del cambio de color del cubo y consola

# Entreja de la practica 1 5-13
- Se ha creado ScriptCubo2.cs
- Se ha creado ScriptEsfera2.cs
- Se ha creado ScriptDesplazamiento.cs

## Ejercicio 8
a. Duplicar coordenadas de moveDirection: Al duplicar la magnitud del vector de dirección, la velocidad efectiva de desplazamiento se duplica.   

b. Duplicar speed manteniendo la dirección: Tiene exactamente el mismo efecto matemático que duplicar el vector; el objeto avanza el doble de rápido por frame.   

c. Usar una speed < 1: El movimiento se vuelve sensiblemente más lento pero mantiene la misma trayectoria.   

d. Posición inicial con $y > 0$: El cubo mantendrá su elevación mientras se desplaza, moviéndose en paralelo al plano del suelo si $y$ de moveDirection es $0$.   

e. Intercambiar entre sistema Local (Space.Self) y Mundial (Space.World):
- En World, el cubo se moverá siempre en los ejes globales de la escena sin importar hacia dónde esté rotado.   
- En Self, el cubo se moverá relativo a su propia orientación y ejes locales.  
