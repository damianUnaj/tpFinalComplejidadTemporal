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
			ArbolBinario<int> arbolBinarioA=new ArbolBinario<int>(1,2);
			ArbolBinario<int> hijoIzquierdo=new ArbolBinario<int>(2,3);
			hijoIzquierdo.agregarHijoIzquierdo(new ArbolBinario<int>(3,4));
			hijoIzquierdo.agregarHijoDerecho(new ArbolBinario<int>(4,5));
			ArbolBinario<int> hijoDerecho=new ArbolBinario<int>(5,1);
			hijoDerecho.agregarHijoIzquierdo(new ArbolBinario<int>(6,6));
			hijoDerecho.agregarHijoDerecho(new ArbolBinario<int>(7,7));
			arbolBinarioA.agregarHijoIzquierdo(hijoIzquierdo);
			arbolBinarioA.agregarHijoDerecho(hijoDerecho);
			
			Console.WriteLine("====Metodo=incluye===="); 
			bool encontrado=arbolBinarioA.incluye(8); //ejercicio 4 metodo incluye
			Console.WriteLine(encontrado?"encontrado": "no encontrado");
			Console.WriteLine("====inorden====");
			arbolBinarioA.inorden(); //ejercicio 4 inorden
			Console.WriteLine("====preorden====");
			arbolBinarioA.preorden(); //ejercicio 4 preorden
			Console.WriteLine("====postorden====");
			arbolBinarioA.postorden(); //ejercicio 5 postorden
			Console.WriteLine("====contarHojas====");
			arbolBinarioA.contarHojas();
			Console.WriteLine("el arbol tiene {0} hojas",arbolBinarioA.contarHojas());//ejercicio 5 contarHojas
			Console.WriteLine("====recorridoPorNiveles====");
			arbolBinarioA.recorridoPorNiveles();
			Console.WriteLine("====entreNiveles N y M===="); //ejercicio 5 entreNiveles
			arbolBinarioA.recorridoEntreNiveles( 0, 2);
			
			
			RedBinariaLlena red=new RedBinariaLlena(arbolBinarioA); //agrego el arbolbinario a la redbinaria para determinar 
			int mayorRetardo=red.retardoReenvio();					//el mayor retardo
			Console.WriteLine("el mayor retardo del arbol es: {0}",mayorRetardo);
			ArbolBinario<int> arbolbinarioB=arbolBinarioA.nuevo(arbolBinarioA);
			
			arbolbinarioB.recorridoPorNiveles();
			
			Console.WriteLine("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}