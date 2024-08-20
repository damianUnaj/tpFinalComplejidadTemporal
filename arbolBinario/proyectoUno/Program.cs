/*
 * Creado por SharpDevelop.
 * Usuario: Primo
 * Fecha: 18/8/2024
 * Hora: 17:16
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace proyectoUno
{
	class Program
	{
		public static void Main(string[] args)
		{
			ArbolBinario<int> arbolBinarioA=new ArbolBinario<int>(1);
			ArbolBinario<int> hijoIzquierdo=new ArbolBinario<int>(2);
			hijoIzquierdo.agregarHijoIzquierdo(new ArbolBinario<int>(3));
			hijoIzquierdo.agregarHijoDerecho(new ArbolBinario<int>(4));
			ArbolBinario<int> hijoDerecho=new ArbolBinario<int>(5);
			hijoDerecho.agregarHijoIzquierdo(new ArbolBinario<int>(6));
			hijoDerecho.agregarHijoDerecho(new ArbolBinario<int>(7));
			arbolBinarioA.agregarHijoIzquierdo(hijoIzquierdo);
			arbolBinarioA.agregarHijoDerecho(hijoDerecho);
			
			Console.WriteLine("====inorden====");
			arbolBinarioA.inorden();
			Console.WriteLine("====preorden====");
			arbolBinarioA.preorden();
			Console.WriteLine("====postorden====");
			arbolBinarioA.postorden();
			Console.WriteLine("====contarHojas====");
			Console.WriteLine("el arbol tiene {0} hojas",arbolBinarioA.contarHojas());
			Console.WriteLine("====recorridoPorNiveles====");
			arbolBinarioA.recorridoPorNiveles();
			Console.WriteLine("====entreNiveles N y M====");
			arbolBinarioA.recorridoEntreNiveles( 0, 2);
			Console.WriteLine("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}