# Memoria de Práctica 2: Físicas 3D en Unity

**Asignatura:** Interfaces Inteligentes  
**Proyecto:** P02  
**Titulación:** Grado en Ingeniería Informática - Universidad de La Laguna  

---

## 1. Resumen de Ejercicios Desarrollados (Bloque de Introducción)

En este bloque se implementaron los scripts en C# localizados en la carpeta `Assets/Scripts/` del proyecto, orientados al control del personaje y la gestión de interacciones mediante el motor de físicas de Unity (PhysX).

* **Ejercicio 1 (`MovimientoPersonajeRB.cs`):** Control del jugador mediante `Rigidbody` utilizando `FixedUpdate()` y `rb.MovePosition()` en lugar de modificar directamente el `Transform`. Se configuraron las restricciones de rotación (*Constraints* en los ejes $X$ y $Z$) para mantener la estabilidad del personaje.
* **Ejercicio 2 (`DeteccionColisiones.cs`):** Implementación del evento `OnCollisionEnter()` para registrar colisiones sólidas con objetos dinámicos, mostrando logs en consola y modificando dinámicamente el color del material impactado mediante su componente `Renderer`.
* **Ejercicio 3 (`ControlTriggers.cs`):** Uso de zonas de detección (*Triggers*). Se programó la alteración del color e iluminación global al entrar y salir (`OnTriggerEnter` y `OnTriggerExit`) en la zona de luz, así como la acumulación continua de daño (`OnTriggerStay`) en función del tiempo transcurrido ($Time.deltaTime$).
* **Ejercicio 4 (`GestionCapas.cs`):** Optimización de la simulación mediante la matriz de colisiones por capas (*Layer Collision Matrix*). Se aislaron las capas `Jugador`, `Enemigos` y `Recolectables`, permitiendo que los recolectables actúen como *Triggers* y que los enemigos solo colisionen físicamente con el jugador.
* **Ejercicio 5 (`LanzadorFuerza.cs`):** Creación e integración de `Physic Materials` (Hielo/Resbaladizo, Caucho/Rugoso y Pelota/Rebote). Aplicación de impulsos físicos mediante `rb.AddForce()` con `ForceMode.Impulse` al presionar una tecla, evaluando el comportamiento del rozamiento y la restitución elástica.
* **Ejercicio 6 (`MovimientoEsferaEj6.cs`):** Desplazamiento y detección cinemática entre tres objetos equipados únicamente con `Collider` (sin `Rigidbody`). Al no generarse eventos en el motor de físicas, la interacción se resolvió por código mediante `Vector3.MoveTowards()` y `Vector3.Distance()`.

---

## 2. Análisis y Conclusiones de las 9 Situaciones Experimentales

A continuación se expone el análisis individualizado de cada una de las situaciones probadas en la escena experimental `Escena_Experimentos`.

### Situación 1
* **Configuración:** Plano con `MeshCollider` (estático), Cubo con `BoxCollider` y `Rigidbody` (dinámico), Esfera con `SphereCollider` sin `Rigidbody` (estática).
* **Resultado Observado:** El cubo cae por gravedad e impacta contra el plano. La esfera permanece flotando e inmóvil en el aire. Si el cubo choca contra ella, la esfera actúa como un obstáculo sólido e inamovible.
* **Conclusión / Justificación Física:** El plano y la esfera actúan como *Static Colliders*. PhysX los considera infinitamente masivos e inamovibles. El cubo es el único objeto dinámico afectado por la aceleración de la gravedad ($g = 9.81 \text{ m/s}^2$).

### Situación 2
* **Configuración:** Plano con `MeshCollider` (estático), Cubo y Esfera equipados con `Collider` y `Rigidbody` dinámicos.
* **Resultado Observado:** Ambos objetos caen por efecto de la gravedad. La esfera impacta sobre el cubo, transmitiéndole movimiento y haciendo que ambos reboten o rueden sobre el plano hasta alcanzar el reposo.
* **Conclusión / Justificación Física:** Ambos elementos se comportan como *Dynamic Rigidbodies*. El motor de físicas calcula las fuerzas normales, la conservación del momento lineal ($p = m \cdot v$) y el rozamiento en los puntos de contacto de ambos cuerpos.

### Situación 3
* **Configuración:** Plano estático, Cubo con `Rigidbody` dinámico, Esfera con `Rigidbody` en modo `Is Kinematic = true`.
* **Resultado Observado:** El cubo cae sobre el plano. La esfera permanece suspendida en el aire, actuando como un muro impenetrable cuando el cubo colisiona con ella.
* **Conclusión / Justificación Física:** Un `Rigidbody` cinemático (`IsKinematic = true`) queda fuera de la simulación de fuerzas (gravedad, fricción o impulsos externados), pero conserva la capacidad de colisionar contra objetos dinámicos afectando a sus trayectorias.

### Situación 4
* **Configuración:** Plano, Cubo y Esfera equipados individualmente con `Rigidbody` dinámico.
* **Resultado Observado:** Todos los objetos de la escena (incluido el plano) caen indefinidamente hacia el vacío.
* **Conclusión / Justificación Física:** Al dotar al plano de un `Rigidbody` dinámico sin restricciones de posición ni uniones (*Joints*), deja de ser un suelo estático. La gravedad actúa sobre toda la masa del sistema desplazándolo verticalmente.

### Situación 5
* **Configuración:** Plano, Cubo ($Masa = 1$) y Esfera ($Masa = 10$), todos con `Rigidbody` dinámico.
* **Resultado Observado:** Todo el conjunto cae por la gravedad. Al colisionar la esfera con el cubo durante la caída, la esfera desplaza al cubo con gran facilidad debido a la diferencia de masa.
* **Conclusión / Justificación Física:** Aunque la gravedad acelera por igual a todos los cuerpos independientemente de su masa, la fuerza de impacto resultante ($F = m \cdot a$) e impulso en la colisión es 10 veces mayor en la esfera, alterando significativamente la velocidad del cubo.

### Situación 6
* **Configuración:** Plano, Cubo ($Masa = 1$) y Esfera ($Masa = 100$), todos con `Rigidbody` dinámico.
* **Resultado Observado:** La esfera masiva aparta o aplasta el cubo instantáneamente en el impacto sin desviarse de su trayectoria descendente.
* **Conclusión / Justificación Física:** Una relación de masa 100:1 genera una inercia dominante en la esfera. La resistencia a alterar su estado de movimiento absorbe el impacto del cubo con un efecto insignificante sobre su propio vector de velocidad.

### Situación 7
* **Configuración:** Plano y Cubo con `Rigidbody` dinámico. Esfera con `Rigidbody` dinámico y un `Physic Material` con alto rozamiento asignado a su collider.
* **Resultado Observado:** Al caer el sistema, la esfera muestra un agarre y fricción notable sobre la superficie del cubo o plano, reduciendo el deslizamiento.
* **Conclusión / Justificación Física:** El `Physic Material` modifica las propiedades de fricción estática y dinámica. PhysX aplica ecuaciones de rozamiento tangencial que frenan el movimiento relativo entre las superficies en contacto.

### Situación 8
* **Configuración:** Plano y Cubo con `Rigidbody` dinámico. Esfera únicamente con `SphereCollider` (sin `Rigidbody`) y con la opción `Is Trigger = true` activada.
* **Resultado Observado:** El plano y el cubo caen por la gravedad. La esfera se queda flotando en el aire. Cuando el cubo pasa por la posición de la esfera, la atraviesa por completo sin reducir su velocidad ni chocar.
* **Conclusión / Justificación Física:** Al marcar `Is Trigger = true` y no poseer `Rigidbody`, se elimina la respuesta física (fuerza normal de reacción) y la gravedad sobre la esfera. El objeto queda relegado a un área de detección geométrica transparente a los impactos.

### Situación 9
* **Configuración:** Plano y Cubo con `Rigidbody` dinámico. Esfera con `Rigidbody` dinámico y `Is Trigger = true`.
* **Resultado Observado:** La esfera cae al mismo tiempo que el cubo y el plano por la gravedad, pero atraviesa al cubo sin interactuar ni colisionar físicamente con él durante la caída.
* **Conclusión / Justificación Física:** Poseer un `Rigidbody` dinámico hace que la esfera responda a la gravedad, pero mantener `Is Trigger = true` anula la resolución de colisiones sólidas, impidiendo que ejerza o reciba fuerzas de contacto de otros *Colliders*.

---

## 3. Conclusiones Generales

1. **Gestión de Cuerpos en PhysX:** Para construir plataformas o escenarios estáticos, los objetos deben permanecer como *Static Colliders* (sin `Rigidbody`) o configurarse como cinemáticos (`IsKinematic`). Un `Rigidbody` dinámico asignado por error a un terreno provoca la caída de la superficie.
2. **Rol de los Triggers:** La casilla `Is Trigger` desactiva completamente la solidez física de un collider, transformándolo en un volumen de detección útil para recolectables, zonas de daño o sensores por código.
3. **Masa e Inercia:** La masa en Unity no influye en la velocidad de caída libre por gravedad, pero es determinante al resolver choques, transferencias de momento e inercias físicas entre objetos dinámicos.