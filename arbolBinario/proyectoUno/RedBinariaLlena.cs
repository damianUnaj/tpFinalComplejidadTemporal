/*
 * Creado por SharpDevelop.
 * Usuario: Primo
 * Fecha: 27/8/2024
 * Hora: 11:46
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace proyectoUno
{
	/// <summary>
	/// Description of RedBinariaLlena.
	/// </summary>
	public class RedBinariaLlena
	{
		private ArbolBinario<int> raiz;
		
		public RedBinariaLlena(ArbolBinario<int> raiz)
		{
			this.raiz=raiz;
		}
		public int retardoReenvio()
		{
			return calcularRetardo(raiz);
		}
		public int calcularRetardo(ArbolBinario<int> arbol)
		{
			if(arbol==null)
			{
				return 0;
			}
			int retardoIzquierdo=calcularRetardo(arbol.getHijoIzquierdo());
			int retardoDerecho=calcularRetardo(arbol.getHijoDerecho());
			return arbol.retardo+Math.Max(retardoIzquierdo,retardoDerecho);
		}
	}
}
