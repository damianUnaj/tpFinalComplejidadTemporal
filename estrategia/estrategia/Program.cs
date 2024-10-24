/*
 * Creado por SharpDevelop.
 * Usuario: Primo
 * Fecha: 22/10/2024
 * Hora: 19:45
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;using System.Collections.Generic; 

namespace estrategia
{
	class Program
	{
		public static void Main(string[] args)
		{
			Proceso proc1=new Proceso("proc1",1,10);//Proceso string nombre, int tiempo, int prioridad
			Proceso proc2=new Proceso("proc2",10,8);
			Proceso proc3=new Proceso("proc3",5,55);
			Proceso proc4=new Proceso("proc4",20,9);
			Proceso proc5=new Proceso("proc5",15,3);
			Proceso proc6=new Proceso("proc6",60,14);
			Proceso proc7=new Proceso("proc7",40,20);
			Proceso proc8=new Proceso("proc8",10,80);
			Proceso proc9=new Proceso("proc9",30,100);
			Proceso proc10=new Proceso("proc10",81,19);
			List<Proceso> lista1=new List<Proceso>{proc1,proc2,proc3,proc4,proc5,proc6,proc7,proc8,proc9,proc10};
			List<Proceso>lista2=new List<Proceso>();
			Estrategia min =new Estrategia();
			Estrategia max=new Estrategia();
			Estrategia consulta1=new Estrategia();Estrategia consulta2=new Estrategia();Estrategia consulta3=new Estrategia();
			//max llama al método principal envía por parámetro lista1 con la lista de procesos y lista2 vacía
			//luego una vez ordenada lista2 imprimo la maxheap de prioridad
			Console.WriteLine();
			Console.WriteLine("max llama al método principal envía por parámetro lista1 con la lista de procesos y ");
			Console.WriteLine("lista2 vacía luego una vez ordenada lista2 imprimo la maxheap de prioridad");
			Console.WriteLine();Console.WriteLine();
			max.PreemptivePriority(lista1,lista2);
			foreach (var element in lista2) {
				Console.Write("nombre: "+element.nombre+" ");
				Console.Write("tiempo: "+element.tiempo+" ");
				Console.Write("prioridad: "+element.prioridad+" ");
			}
			//max llama al método principal envía por parámetro lista1 con la lista de procesos y lista2 vacía
			//luego una vez ordenada lista2 imprimo la minheap de tiempo
			Console.WriteLine();Console.WriteLine();
			Console.WriteLine("max llama al método principal envía por parámetro lista1 con la lista de procesos y lista2 vacía ");
			Console.WriteLine("luego una vez ordenada lista2 imprimo la minheap de tiempo");
			Console.WriteLine();
			min.ShortesJobFirst(lista1,lista2);
			Console.WriteLine();
			Console.WriteLine("------------------------");
			foreach (var element in lista2) {
				Console.Write("nombre: "+element.nombre+" ");
				Console.Write("tiempo: "+element.tiempo+" ");
				Console.Write("prioridad: "+element.prioridad+" ");
			}
			Console.WriteLine();Console.WriteLine();
			Console.WriteLine("------------------------");
			//retorna un texto con las hojas de las heaps utilizadas en los metodos -shortesJobFirst y -PreemptivePriority
			Console.WriteLine("retorna un texto con las hojas de las heaps ");
			Console.WriteLine();
			string consul1=consulta1.Consulta1(lista1);
			Console.WriteLine(consul1);
			Console.WriteLine("------------------------");
			Console.WriteLine();Console.WriteLine();
			Console.WriteLine("retorna un texto con las alturas de las heaps");
			Console.WriteLine();
			//retorna un texto con las alturas de las heaps utilizadas en los metodos -shortesJobFirst y -PreemptivePriority
			string consul2=consulta2.Consulta2(lista1);
			Console.WriteLine(consul2);
			Console.WriteLine("------------------------");
			//retorna los datos de los niveles de las heap utilizadas en los metodos -shortesJobFirst y -PreemptivePriority
			Console.WriteLine();Console.WriteLine();
			Console.WriteLine("retorna los datos de los niveles de las heap");
			Console.WriteLine();
			string consul3=consulta3.Consulta3(lista1);
			Console.WriteLine(consul3);
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);

		}
	}
}