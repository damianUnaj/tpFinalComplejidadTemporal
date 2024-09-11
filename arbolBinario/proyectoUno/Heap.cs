/*
 * Creado por SharpDevelop.
 * Usuario: Primo
 * Fecha: 10/9/2024
 * Hora: 09:57
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace proyectoUno
{
	/// <summary>
	/// Description of Heap.
	/// </summary>
	public class Heap
	{
		private int[]arregloHeap;
		private int numeroDeElementos;
		private int capacidadTotalDelArreglo;
		
		public Heap(int capacidadInicial=10)
		{
			arregloHeap=new int[capacidadInicial];
			numeroDeElementos=0;
			capacidadTotalDelArreglo=capacidadInicial;
		}
		// Nuevo constructor que acepta un array
		public Heap(int[]elementosIniciales)
		{
			capacidadTotalDelArreglo=elementosIniciales.Length*2;// Ajustar capacidad inicial
			arregloHeap=new int[capacidadTotalDelArreglo];
			numeroDeElementos=0;
			//inserto todos los elementos del array en el heap
			foreach(int elemento in elementosIniciales)
			{
				insertar(elemento);//reutilizo el metodo insertar
			}
		}
		public int GetNumeroDeElementos()  //agrego un descritor de acceso para obtener el tamaño del arreglo
		{return numeroDeElementos;}
		public int GetElemento(int indice) //método para obtener elemento de una posición específica
		{//aseguro que si el valor indice recibido esta fuera de rango no rompa la ejecuciòn del codigo
			if(indice>=numeroDeElementos|| indice<0)
				throw new IndexOutOfRangeException("ìndice fuera de rango");
			return arregloHeap[indice];
		}
		public void insertar(int elemento)
		{
			//verificar si el arreglo necesita ser redimensionado
			if (numeroDeElementos==capacidadTotalDelArreglo)
			{
				redimensionarHeap();
			}
			//agregrar nuevo elemento al final
			arregloHeap[numeroDeElementos]=elemento;
			numeroDeElementos++;
			//ajustar la posición del nuevo elemento
			ordenarMinHeap(numeroDeElementos-1);
			
		}
		private void ordenarMinHeap(int indice)
		{
			int padreIndice=indice/2;
			//mientras que no estemos en la raiz y el elemento actual sea menor que su padre
			while(indice>0&&arregloHeap[indice]<arregloHeap[padreIndice])
			{
				swap(indice,padreIndice);
				//actualizar el indice actual y el del padre
				indice=padreIndice;
				padreIndice=indice/2;
			}
		}
		private void swap(int indice1,int indice2)
		{
			int auxiliar=arregloHeap[indice1];
			arregloHeap[indice1]=arregloHeap[indice2];
			arregloHeap[indice2]=auxiliar;
		}
		private void redimensionarHeap()
		{
			int nuevaCapacidad=capacidadTotalDelArreglo*2;
			int[]nuevaHeap=new int[nuevaCapacidad];
			//copiar los elementos del viejo arreglo al nuevo arreglo
			for(int i=0;i<numeroDeElementos;i++)
			{
				nuevaHeap[i]=arregloHeap[i];
			}
			arregloHeap=nuevaHeap; //reemplazar el viejo arreglo por el nuevo
			capacidadTotalDelArreglo=nuevaCapacidad;//actualizar la capacidad
		}
	}
}
