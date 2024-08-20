/*
 * Creado por SharpDevelop.
 * Usuario: Primo
 * Fecha: 18/8/2024
 * Hora: 20:13
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;

namespace proyectoUno
{
	/// <summary>
	/// Description of Cola.
	/// </summary>
	public class Cola<T>
	{
		private List<T> datos=new List<T>();
		
		public void encolar(T elem)
		{
			this.datos.Add(elem);
		}
		public T desencolar()
		{
			T temp=this.datos[0];
			this.datos.RemoveAt(0);
			return temp;
		}
		public T tope()
		{
			return this.datos[0];
		}
		public bool estaVacia()
		{
			return this.datos.Count==0;
		}
	}
}
