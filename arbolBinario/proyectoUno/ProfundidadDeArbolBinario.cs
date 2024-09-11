/*
 * Creado por SharpDevelop.
 * Usuario: Primo
 * Fecha: 3/9/2024
 * Hora: 10:26
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace proyectoUno
{
	/// <summary>
	/// Description of ProfundidadDeArbolBinario.
	/// </summary>
	public class ProfundidadDeArbolBinario
	{
		ArbolBinario <int>arbol;
		
		public ProfundidadDeArbolBinario(ArbolBinario<int> arbol)
		{
			this.arbol=arbol;
		}
		public int sumaElementosProfundidad(int objetivo)
		{
			return sumaElementosProfundidad(objetivo,arbol,0);
		}
		private int sumaElementosProfundidad(int profundidadObjetivo,ArbolBinario<int> nodo,int profundidadActual)
		{
			if (nodo==null)
				return 0;
			
			if (profundidadObjetivo==profundidadActual)
				return nodo.getDatoRaiz();
			int sumaIzquierda=sumaElementosProfundidad(profundidadObjetivo,nodo.getHijoIzquierdo(),profundidadActual+1);
			int sumaDerecha=sumaElementosProfundidad(profundidadObjetivo,nodo.getHijoDerecho(),profundidadActual+1);
			return sumaIzquierda+sumaDerecha;
		}
	}
}
