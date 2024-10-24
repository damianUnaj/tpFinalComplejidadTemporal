
using System;
using System.Collections.Generic;
using System.Numerics; 


namespace estrategia
{

	public class Estrategia
	{
		
		//retorna un texto con las hojas de las heaps utilizadas en los metodos -shortesJobFirst y -PreemptivePriority
		public String Consulta1(List<Proceso> datos)
		{
			List<Proceso> collectedTiempo = new List<Proceso>();
			List<Proceso> collectedPrioridad = new List<Proceso>();
			ShortesJobFirst( datos,  collectedTiempo);//saco una lista de procesos ordenados por el minHeap tiempo
			PreemptivePriority(datos,  collectedPrioridad);//saco una lista de procesos ordenados por el maxHeap prioridad
			string mensaje="hojas de la  minHeap Tiempo: "+obtenerHojas(collectedTiempo)+
				"\n hojas de la maxHeap Prioridad: "+ obtenerHojas(collectedPrioridad);//\n salto de linea
			return mensaje;
		}
		//metodo obtener hojas:
		public string obtenerHojas(List<Proceso>Heap)
		{
			string result="";
			for (int i =Heap.Count/2 ; i < Heap.Count; i++)
			{
				result+=Heap[i].ToString()+" ";//el resultado lo paso a string pero es redundante lo hace implicito
			}
			return result;
		}

		
		//retorna un texto con las alturas de las heaps utilizadas en los metodos -shortesJobFirst y -PreemptivePriority
		public String Consulta2(List<Proceso> datos)
		{
			List<Proceso> collectedTiempo = new List<Proceso>();
			List<Proceso> collectedPrioridad = new List<Proceso>();
			ShortesJobFirst( datos,  collectedTiempo);//saco el min tiempo
			PreemptivePriority(datos,  collectedPrioridad);//saco el max prioridad
			int indice=0;
			string resultado="altura heap tiempo= "+altura(collectedTiempo,indice)+ "\n altura heap prioridad= "+altura(collectedPrioridad,indice);
			return resultado;
		}
		public int  altura(List<Proceso>coleccion,int indice)
		{
			
			if(indice>=coleccion.Count||coleccion[indice]==null)
				return 0;
			int hijoIzquierdo=2*indice+1; int hijoDerecho=2*indice+2;
			int alturaIzq=altura(coleccion,hijoIzquierdo);int alturaDer=altura(coleccion,hijoDerecho);
			if(alturaIzq>alturaDer)
				return 1+alturaIzq;
			else
				return 1+alturaDer;

		}


		//retorna los datos de los niveles de las heap utilizadas en los metodos -shortesJobFirst y -PreemptivePriority
		public String Consulta3(List<Proceso> datos)
		{

			List<Proceso> collectedTiempo = new List<Proceso>();
			List<Proceso> collectedPrioridad = new List<Proceso>();
			ShortesJobFirst( datos,  collectedTiempo);//saco el min tiempo
			PreemptivePriority(datos,  collectedPrioridad);//saco el max prioridad
			
			string resultadoTiempo="niveles minheap tiempo: \n"+niveles(collectedTiempo);
			string resultadoPrioridad="niveles maxheap prioridad: \n"+niveles(collectedPrioridad);
			return resultadoTiempo +"\n\n"+resultadoPrioridad;
			
		}
		public static string niveles(List<Proceso>colleccion)
		{
			if(colleccion.Count==0)
			{
				return "heap vacia";
			}
			//cola para la heap
			Cola<Proceso> c=new Cola<Proceso>();
			c.encolar(colleccion[0]);//encolamos el primer elemento(la raiz)
			string resultado="";int nivel=0;int indice=0;
			
			
			while(c.cantidadElementos()>0)
			{
				// Guardamos el tamaño del nivel actual en la cola
				int tamañoNivel=c.cantidadElementos();
				resultado+="nivel"+nivel+": \n";
				
				// Recorremos todos los elementos del nivel actual
				for (int i = 0; i < tamañoNivel; i++)
				{// Desencolamos el proceso actual
					Proceso procesoActual=c.desencolar();
					//verifico que el nivel existe
					if(procesoActual!=null)
					{
						resultado+="nivel"+nivel+": "+procesoActual.ToString()+"\n";
						
						// Obtenemos los índices de los hijos izquierdo y derecho
						int hijoIzquierdo=2*indice+1;int hijoDerecho=2*indice+2;
						if(hijoIzquierdo<colleccion.Count && colleccion[hijoIzquierdo]!=null)
						{// Encolamos los hijos si están dentro del rango y no son nulos
							c.encolar(colleccion[hijoIzquierdo]);
						}//también con el hijo derecho
						if(hijoDerecho<colleccion.Count && colleccion[hijoDerecho]!=null)
						{
							c.encolar(colleccion[hijoDerecho]);
						}
					}
					indice++;
				}
				nivel++;
				
			}
			return resultado;
		}



		//metodo trabajos cortos primero Retorna en la variable collected los procesos ordenados del
		//de menor tiempo de uso de la CPU al de mayor de la lista datos utilizando una MinHeap
		public void ShortesJobFirst(List<Proceso> datos, List<Proceso> collected)
		{
			//limpio lista recollected para evitar que el metodo PreemptivePriority sobreescriba este
			collected.Clear();
			// Clonamos la lista de datos para no modificar la lista original
			List<Proceso> heap = new List<Proceso>(datos);
			int cantidadDatos = heap.Count;

			// Construimos la MinHeap (comenzamos desde la mitad hacia atrás para arrancar desde los nodos internos)
			for (int i = cantidadDatos / 2 - 1; i >= 0; i--)
			{
				MinHeap(heap, cantidadDatos, i);
			}

			// Extraemos el mínimo repetidamente y lo agregamos a la lista collected
			for (int i = cantidadDatos - 1; i >= 0; i--)
			{
				// Movemos el elemento mínimo (heap[0]) al final de la lista
				Proceso aux = heap[0];
				heap[0] = heap[i];
				heap[i] = aux;

				// Agregamos el elemento mínimo al final de la lista ordenada
				collected.Add(aux);

				// Llamamos a MinHeap para el subárbol reducido
				MinHeap(heap, i, 0);
			}
			
		}

		// Función auxiliar para reorganizar el subárbol
		private void MinHeap(List<Proceso> heap, int tamaño, int i)
		{
			int Padre = i; // Inicializamos el nodo más pequeño como el padre
			int HijoIzquierdo = 2 * i + 1; // Hijo izquierdo
			int HijoDerecho = 2 * i + 2; // Hijo derecho

			// Si el hijo izquierdo es más pequeño que el nodo padre y menor que n (tamaño heap)
			if (HijoIzquierdo < tamaño && heap[HijoIzquierdo].tiempo < heap[Padre].tiempo)
			{
				Padre = HijoIzquierdo;
			}

			// Si el hijo derecho es más pequeño que el nodo más pequeño actual
			if (HijoDerecho < tamaño && heap[HijoDerecho].tiempo < heap[Padre].tiempo)
			{
				Padre = HijoDerecho;
			}

			// Si el nodo más pequeño no es el nodo padre
			if (Padre != i)
			{
				// Intercambiamos el nodo padre con el más pequeño
				Proceso aux = heap[i];
				heap[i] = heap[Padre];
				heap[Padre] = aux;

				// Aplicamos MinHeap al subárbol afectado
				MinHeap(heap, tamaño, Padre);
			}
		}

		//Retorna en la variable collected los procesos ordenados del de mayor prioridad al de menor prioridad de la
		//lista datos utilizando una MaxHeap
		public void PreemptivePriority(List<Proceso> datos, List<Proceso> collected)
		{
			
			//limpio lista recollected para evitar que el metodo ShortesJobFirst sobreescriba este
			collected.Clear();
			// Clonamos la lista de datos para no modificar la lista original
			List<Proceso> heap = new List<Proceso>(datos);
			int cantidadDatos = heap.Count;

			// Construimos la MaxHeap (comenzamos desde la mitad hacia atrás)
			for (int i = cantidadDatos / 2 - 1; i >= 0; i--)
			{
				MaxHeap(heap, cantidadDatos, i);
			}

			// Extraemos el máximo repetidamente y lo agregamos a la lista collected
			for (int i = cantidadDatos - 1; i >= 0; i--)
			{
				// Movemos el elemento Máximo (heap[0]) al final de la lista
				Proceso aux = heap[0];
				heap[0] = heap[i];
				heap[i] = aux;

				// Agregamos el elemento Máximo al final de la lista ordenada
				collected.Add(aux);

				// Llamamos a MaxHeap para el subárbol reducido
				MaxHeap(heap, i, 0);
			}
			
			
		}
		private void MaxHeap(List<Proceso> heap, int n, int i)
		{
			int Padre = i; // Inicializamos el nodo más pequeño como el padre
			int HijoIzquierdo = 2 * i + 1; // Hijo izquierdo
			int HijoDerecho = 2 * i + 2; // Hijo derecho

			// Si el hijo izquierdo es más grande que el nodo padre y más pequeño que n
			if (HijoIzquierdo < n && heap[HijoIzquierdo].prioridad > heap[Padre].prioridad)
			{
				Padre = HijoIzquierdo;
			}

			// Si el hijo derecho es más grande que el nodo más grande actual
			if (HijoDerecho < n && heap[HijoDerecho].prioridad > heap[Padre].prioridad)
			{
				Padre = HijoDerecho;
			}

			// Si el nodo más grande no es el nodo padre
			if (Padre != i)
			{
				// Intercambiamos el nodo padre con el más grande
				Proceso aux = heap[i];
				heap[i] = heap[Padre];
				heap[Padre] = aux;

				// Aplicamos MaxHeap al subárbol afectado
				MaxHeap(heap, n, Padre);
			}
		}

		





	}
}